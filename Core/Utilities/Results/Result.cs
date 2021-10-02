using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Readonly olan proplar constructor da set edilebilir.
        public Result(bool success, string message):this(success)//this demek classın kendisi demektir burada Result dır. cons. succesi de gönderdim
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
