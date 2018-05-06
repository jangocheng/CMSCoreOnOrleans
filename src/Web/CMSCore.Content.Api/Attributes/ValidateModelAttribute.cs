﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CMSCore.Content.Api.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (!context.ModelState.IsValid)
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        errors = context.ModelState?.Select(x => x.Value.Errors)
                    });
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

/*
/// <summary>
/// Validates provided parameters by their names. Ex: [ValidateModel("id,name")]
/// </summary>
/// <param name="requiredParameters">Parameter names. Comma separated WITHOUT SPACES</param>
public ValidateModelAttribute(string requiredParameters)
{
requiredParameters.Split(',');
}

/// <summary>
/// Validates provided parameters and returns a custom error message + errors
/// </summary>
/// <param name="errorMessage"></param>
/// <param name="requiredParameters"></param>
public ValidateModelAttribute(string errorMessage, string requiredParameters)
: this(errorMessage, true)
{
requiredParameters.Split(',');
}
    
//if (context.ActionArguments != null && context.ActionArguments.Any(x =>
//        x.Value == null || x.Value is string s && string.IsNullOrEmpty(s)))
//{
//    context.Result = new BadRequestObjectResult(new {errorMessage = _errorMessage});
//}

if (_requiredParameters != null && (_requiredParameters.Length == -1) == false)
{
    var attributes = context.ActionArguments;

    foreach (var parameter in _requiredParameters)
    {
        var attr = attributes[parameter];
        if (attr == null || attr is string s && string.IsNullOrEmpty(s))
        {
            _errors.Add($"'{parameter}' must be provided with a value.");
        }
    }

    if (context.ModelState.IsValid && _errors.Any())
        context.Result = new BadRequestObjectResult(new
        {
            errorMessage = _errorMessage,
            errors = _errors
        });
}

 */
