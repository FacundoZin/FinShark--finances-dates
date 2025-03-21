using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Common
{
    public class Result<T>
    {
        public bool Exit { get; private set; }
        public T Date { get; private set; }
        public string Errormessage { get; private set; }
        public int Errorcode { get; set; }

        public Result(bool exit, T date, string errormessage, int errorcode)
        {
            Exit = exit;
            Date = date;
            Errormessage = errormessage;
            Errorcode = errorcode;
        }

        public static Result<T> Exito(T datos) => new Result<T>(true, datos, null, 200);
        public static Result<T> Error(string message, int errorcode) => new Result<T>(false, default, message, errorcode);
    }
}