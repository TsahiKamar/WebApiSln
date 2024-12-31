﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using System;
using WebApi.Models;

namespace WebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
       public void OnAuthorization(AuthorizationFilterContext context)
       {
           var user = (User)context.HttpContext.Items["User"];
           if (user == null)
           {
               //Not logged in
               context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
           }
       }
    }
}
