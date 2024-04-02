﻿using Microsoft.AspNetCore.Identity;
using System.Text;
using ValhallaVaultCyberAwareness.Data;

namespace ValhallaVaultCyberAwareness.Authentication
{
    public class BasicAuthHandler
    {
        private readonly RequestDelegate _next;
        private readonly string _realm;
        private string? _username;
        private string? _password;
        private bool _isVerifiedCredentials;
        private bool _isAdmin;
        private string? _providedRouteUserId = null;

        public BasicAuthHandler(RequestDelegate next, string realm)
        {
            _next = next;
            _realm = realm;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            //This ensures that all ordinary pages (such as start page, login, register) work, because they don't come over the api.
            if (IsRequestComingOverApi(context))
            {
                //Check that the route values are not empty, because if they are, it has not been provided required parameters to locate the endpoint.
                if (IsRequestValid(context))
                {
                    //Since support page is open for everyone, it should never authenticate any credentials when handling post and get.
                    if (IsRequestSupportQuestion(context) && IsRequestOfTypeGetOrPost(context))
                    {
                        await _next(context);
                        return;
                    }
                    else
                    {
                        //In all other cases, verify the authentication.
                        //This ensures that the authorization header is present and returns 401 Unauthorized otherwise.
                        if (IsAuthorizationKeyInHeader(context) == false)
                        {
                            await SetUnauthorizedMissingAuthorizationHeader(context);
                            return;
                        }

                    }
                    //If the request is coming over the api, we authenticate the credentials (unless it's coming from supportquestion, which is handled above).
                    DecryptCredentials(context);
                    //When the client application sends a request it send username as -1. Then we trust that the client app has handled the authorization.
                    if (_username == "-1")
                    {
                        await _next(context);
                        return;
                    }
                    //Find user by provided username
                    ApplicationUser user = await userManager.FindByNameAsync(_username);
                    if (user != null)
                    {
                        //Verify the password if the user is found
                        _isVerifiedCredentials = await userManager.CheckPasswordAsync(user, _password);
                        if (_isVerifiedCredentials == false)
                        {
                            //If the password verification failes, try and see if the user has passed the hashed password.
                            _isVerifiedCredentials = _password == user.PasswordHash;
                        }
                    }
                    //If either one of the password tries above works, the credentials are verified and we continue to check if the user is an admin,
                    //which is needed for post/delete/update in most models
                    if (_isVerifiedCredentials)
                    {
                        //Check get method and that it's not trying to access another user's scores
                        if (IsRequestOfTypeGet(context))
                        {
                            if (IsRequestAskingForUserScores(context))
                            {
                                //Compare route value and actual user id
                                bool isMatchingUserIds = _providedRouteUserId == user.Id;
                                if (isMatchingUserIds)
                                {
                                    await _next(context);
                                    return;
                                }
                                else
                                {
                                    await SetForbiddenAskingForAnotherUsersScore(context);
                                    return;
                                }
                            }
                            //Allow everyone to get
                            else
                            {
                                await _next(context);
                                return;
                            }
                        }
                        //When it comes to user answers, there is only posting available. No extra checks are needed.
                        else if (IsUserAnswers(context))
                        {
                            await _next(context);
                            return;
                        }
                        else
                        {
                            _isAdmin = await userManager.IsInRoleAsync(user, "Admin");
                            if (_isAdmin == false)
                            {
                                await SetForbiddenMissingAdminRole(context);
                                return;
                            }
                            else
                            {
                                await _next(context);
                                return;
                            }
                        }
                    }
                    else
                    {
                        //If username and/or password is not matching, we return status code 401 and error message.
                        await SetUnauthorizedWrongCredentials(context);
                        return;
                    }
                }
                else
                {
                    await SetNotFound(context);
                    return;
                }


            }
            else
            {
                await _next(context);
                return;
            }
        }

        private async Task SetNotFound(HttpContext context)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Missing parameters for the attempted resource");
        }

        private bool IsRequestValid(HttpContext context)
        {
            return context.Request.RouteValues.Count > 0;
        }

        private void DecryptCredentials(HttpContext context)
        {
            string? header = context.Request.Headers.Authorization;
            var encodedCreds = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] usernameAndPassword = creds.Split(':');
            _username = usernameAndPassword[0];
            _password = usernameAndPassword[1];
        }

        private bool IsRequestComingOverApi(HttpContext context)
        {
            //This ensures that all ordinary pages (such as start page, login, register) work, because they don't come over the api.
            return context.Request.Path.Value.ToLower().Contains("api");
        }

        private bool IsRequestSupportQuestion(HttpContext context)
        {
            return context.Request.Path.Value.ToLower().Contains("supportquestion");
        }

        private bool IsAuthorizationKeyInHeader(HttpContext context)
        {
            return context.Request.Headers.ContainsKey("Authorization");
        }

        private bool IsRequestOfTypeGet(HttpContext context)
        {
            return context.Request.Method == "GET";
        }

        private bool IsRequestOfTypePost(HttpContext context)
        {
            return context.Request.Method == "POST";
        }

        private bool IsRequestOfTypeGetOrPost(HttpContext context)
        {
            return IsRequestOfTypeGet(context) || IsRequestOfTypePost(context);
        }

        private bool IsRequestAskingForUserScores(HttpContext context)
        {
            bool isAskingForUserScores = context.Request.RouteValues.TryGetValue("userId", out object routeUserId);
            if (routeUserId != null)
            {
                _providedRouteUserId = routeUserId.ToString();
            }
            return isAskingForUserScores;
        }

        private async Task SetForbiddenMissingAdminRole(HttpContext context)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("You don't have the required role to perform this operation");
        }

        private async Task SetUnauthorizedMissingAuthorizationHeader(HttpContext context)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
        }

        private async Task SetUnauthorizedWrongCredentials(HttpContext context)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Wrong username and/or password");
        }

        private async Task SetForbiddenAskingForAnotherUsersScore(HttpContext context)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("You are not allowed to access another user's scores");
        }

        private bool IsUserAnswers(HttpContext context)
        {
            return context.Request.Path.Value.ToLower().Contains("useranswers");
        }
    }
}
