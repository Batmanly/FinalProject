using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        
        public Result(bool success, string message):this(success)//Reuslt tek parametreli fonksiyonuna tek parametre gelirse bu cift parametre gelirse altakide calisir
        {
            //Readonly olanlar contructor icinde set edilebilir
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
