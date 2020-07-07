using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.BLL.Application.Request
{
    public class OperatorRequest
    {
        public string currency_name { get; set; }
        public string currency_cname { get; set; }
        public int state { get; set; }
    }
}
