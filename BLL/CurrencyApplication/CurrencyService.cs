using SkcCurrencyApi.BLL.Application.Request;
using SkcCurrencyApi.BLL.Application.Response;
using SkcCurrencyApi.DAL.GenericService;
using SkcCurrencyApi.DAL.Interface;
using SkcCurrencyApi.DAL.Models;
using SkcCurrencyApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SkcCurrencyApi.BLL.Application
{
    public class CurrencyService : ICurrencySevice
    {
        
        public CurrencyService ( )
        {
            
        }

        //yyyyMMddhhmmss
        public async ValueTask<BasicResponse<bool>> CreateCurrency(OperatorRequest request)
        {
            var date = Convert.ToInt32(DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var data = new Currency { 
                CurrencyName = request.currency_name,
                CurrencyCname= request.currency_cname,
                Cdate = date,
                Udate = date,
                state = 1
            };
             
            var result =  Services.GetOp<Currency>().Create(data);

            return new BasicResponse<bool> { code=001, data = result, desc= "success" };
        }

        public async ValueTask<BasicResponse<bool>> DeleteCurrency(OperatorRequest request)
        {

            var date = Convert.ToInt32(DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var data = new Currency
            {
                CurrencyName = request.currency_name,
                CurrencyCname = request.currency_name,
                Cdate = date,
                Udate = date,
                state = 0
            };

            var result = Services.GetOp<Currency>().Update(d => d.Id == data.Id, data);

            return new BasicResponse<bool> { code = 001, data = result, desc = "success" };
        }

        public async ValueTask<BasicResponse<IEnumerable<QueryResponse>>> GetALLCurrency()
        {
            
            var datas = Services.GetQ<Currency>().AllDatas();
            var details = Services.GetQ<CurrencyDetail>().AllDatas();

            var response = datas.Join(details, o => o.CurrencyName, p => p.CurrencyName,
                      (c, s) => new QueryResponse {

                          currency_name = c.CurrencyName,
                          currency_cname =c.CurrencyCname,
                          cash_buy = s.CashBuy,
                          cash_sale = s.CashSale,
                          last_UpdateTime = s.LastUpdateTime
                           }).ToList();


            return new BasicResponse<IEnumerable<QueryResponse>> { code = 0001, data = response, desc = "success" };
        }

        public async ValueTask<BasicResponse<IEnumerable<QueryResponse>>> GetByDate(DateTime exchangeDate)
        {
            var datas = Services.GetQ<Currency>().AllDatas();
            var details = Services.GetQ<CurrencyDetail>().AllDatas();

            var response = datas.Join(details, o => o.CurrencyName, p => p.CurrencyName,
                      (c, s) => new QueryResponse
                      {

                          currency_name = c.CurrencyName,
                          currency_cname = c.CurrencyCname,
                          cash_buy = s.CashBuy,
                          cash_sale = s.CashSale,
                          last_UpdateTime = s.LastUpdateTime
                      }).Where(t=>t.last_UpdateTime==exchangeDate).OrderByDescending(s=>s.last_UpdateTime).ToList();


            return new BasicResponse<IEnumerable<QueryResponse>> { code = 0001, data = response, desc = "success" };

        }

        public async ValueTask<BasicResponse<bool>> UpdateCurrency(OperatorRequest request)
        {
            var date = Convert.ToInt32(DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var data = new Currency
            {
                CurrencyName = request.currency_name,
                CurrencyCname = request.currency_name,
                Cdate = date,
                Udate = date,
                state = 0
            };

            var result = Services.GetOp<Currency>().Update(d => d.Id == data.Id, data);

            return new BasicResponse<bool> { code = 001, data = result, desc = "success" };
        }
    }
}
