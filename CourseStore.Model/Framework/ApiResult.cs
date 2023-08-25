using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Model.Framework;

public class ApiResult
{
    private readonly List<string> _errors = new();
    public bool IsSuccess => !IsFailur;
    public bool IsFailur => _errors.Any();

    public void AddError(string errorMessage)
    {
        _errors.Add(errorMessage);
    }

    public IReadOnlyList<string> Errors => _errors;
}
public class ApiResult<TResult>: ApiResult
{
    public TResult? Result { get; set; }
    public ICollection<TResult> ListResult { get; set; }
}