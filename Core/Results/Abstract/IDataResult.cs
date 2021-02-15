using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
