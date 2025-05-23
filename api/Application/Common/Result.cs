using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Application.Common
{
    public class Result<T>
    {
        public bool Exit { get; private set; }
        public T Data { get; private set; }
        public string Errormessage { get; private set; }
        public int Errorcode { get; set; }

        public Result(bool exit, T data, string errormessage, int errorcode)
        {
            Exit = exit;
            Data = data;
            Errormessage = errormessage;
            Errorcode = errorcode;
        }

        public static Result<T> Exito(T data) => new Result<T>(true, data, string.Empty, 200);
        public static Result<T> Error(string message, int errorcode) => new Result<T>(false, default, message, errorcode);
    }
}