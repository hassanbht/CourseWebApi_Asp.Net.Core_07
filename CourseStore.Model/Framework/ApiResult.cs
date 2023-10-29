using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CourseWebApi.Model.Framework;

public class ApiResult
{
    private readonly List<string> _errors = new();
    public bool IsSuccess => !IsFailur;
    public bool IsFailur => _errors.Any();

    public ApiResultStatusCode StatusCode { get; set; }

    public void AddError(string errorMessage)
    {
        _errors.Add(errorMessage);
    }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public IReadOnlyList<string> Errors => _errors;

    public ApiResult(ApiResultStatusCode statusCode, string? errors = null)
    {
        StatusCode = statusCode;
        if (((int)statusCode) > 300) _errors.Add(errors ?? statusCode.ToDisplay());
    }


    #region Implicit Operators
    public static implicit operator ApiResult(OkResult result)
    {
        return new ApiResult(ApiResultStatusCode.Success);
    }

    public static implicit operator ApiResult(OkObjectResult result)
    {
        return new ApiResult<OkObjectResult>(ApiResultStatusCode.Success, (OkObjectResult) result.Value);
    }

    public static implicit operator ApiResult(BadRequestResult result)
    {
        return new ApiResult(ApiResultStatusCode.BadRequest);
    }

    public static implicit operator ApiResult(BadRequestObjectResult result)
    {
        var message = result.Value.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiResult(ApiResultStatusCode.BadRequest, message);
    }

    public static implicit operator ApiResult(ContentResult result)
    {
        return new ApiResult(ApiResultStatusCode.Success, result.Content);
    }

    public static implicit operator ApiResult(NotFoundResult result)
    {
        return new ApiResult(ApiResultStatusCode.NotFound);
    }
    #endregion

}
public class ApiResult<TResult> : ApiResult
{
    public ApiResult() :base(ApiResultStatusCode.Success) { }
    
    public ApiResult(ApiResultStatusCode statusCode, string? errors) : base(statusCode, errors)
    {
    }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public TResult? Result { get; set; }
    public ICollection<TResult> ListResult { get; set; }

    public ApiResult(ApiResultStatusCode statusCode, TResult data, string? message = null)
            : base(statusCode, message)
    {
        Result = data;
    }

    public ApiResult(ApiResultStatusCode statusCode, ICollection<TResult> data, string? message = null)
            : base(statusCode, message)
    {
        ListResult = data;
    }

    #region Implicit Operators
    public static implicit operator ApiResult<TResult>(TResult data)
    {
        return new ApiResult<TResult>(ApiResultStatusCode.Success, data);
    }

    public static implicit operator ApiResult<TResult>(OkResult result)
    {
        return new ApiResult<TResult>(ApiResultStatusCode.Success, null);
    }

    public static implicit operator ApiResult<TResult>(OkObjectResult result)
    {
        return new ApiResult<TResult>(ApiResultStatusCode.Success, (TResult)result.Value);
    }

    public static implicit operator ApiResult<TResult>(BadRequestResult result)
    {
        return new ApiResult<TResult>(ApiResultStatusCode.BadRequest, null);
    }

    public static implicit operator ApiResult<TResult>(BadRequestObjectResult result)
    {
        var message = result.Value.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiResult<TResult>(ApiResultStatusCode.BadRequest,  message);
    }

    public static implicit operator ApiResult<TResult>(ContentResult result)
    {
        return new ApiResult<TResult>(ApiResultStatusCode.Success,  result.Content);
    }

    public static implicit operator ApiResult<TResult>(NotFoundResult result)
    {
        return new ApiResult<TResult>(ApiResultStatusCode.NotFound, null);
    }

    public static implicit operator ApiResult<TResult>(NotFoundObjectResult result)
    {
        return new ApiResult<TResult>(ApiResultStatusCode.NotFound, (TResult)result.Value);
    }
    #endregion
}


public enum ApiResultStatusCode
{
    [Display(Name = "The item was created successfully")]
    Success = 201,

    [Display(Name = "The server is up, but overloaded with requests. Try again later!")]
    ServerError = 503,

    [Display(Name = "Validation errors in your request")]
    BadRequest = 400,

    [Display(Name = "The item does not exist")]
    NotFound = 404,

    [Display(Name = "Any message which should help the user to resolve the conflict")]
    LogicError = 409,

    [Display(Name = "Authentication credentials were missing or incorrect")]
    UnAuthorized = 401
}