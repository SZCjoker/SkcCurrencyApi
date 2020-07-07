using SkcCurrencyApi.BLL.Application.Request;
using SkcCurrencyApi.BLL.Application.Response;
using SkcCurrencyApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.BLL.Application
{
public  interface ICurrencySevice
    {

        ValueTask<BasicResponse<bool>> CreateCurrency(OperatorRequest request);
        ValueTask<BasicResponse<bool>> UpdateCurrency(OperatorRequest request);
        ValueTask<BasicResponse<bool>> DeleteCurrency(OperatorRequest request);
        ValueTask<BasicResponse<IEnumerable<QueryResponse>>> GetALLCurrency();

        ValueTask<BasicResponse<IEnumerable<QueryResponse>>> GetByDate(string exchangeDate);

    }
}
