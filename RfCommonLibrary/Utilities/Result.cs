using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.Utilities
{
    public class Result<T>
    {
       
        public bool IsSuccess { get; set; } = true;
        public bool IsFailure => !IsSuccess;
        public T? Data { get; set; }
        public string? Message { get; set; }

        public Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Data = default, Message = error };
    }
}
