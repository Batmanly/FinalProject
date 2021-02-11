using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //interface interface implemente ederse tekrar yazmaya gerek yok diger interfacteki prop lari da kapsar
        T Data { get; }
    }

}
