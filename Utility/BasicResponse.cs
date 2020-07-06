using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.Utility
{
    public struct BasicResponse<T>
    {
        public int code { get; set; }
        public string desc { get; set; }
        public T data { get; set; }
    }

}

