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

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async ValueTask<BasicResponse<bool>> DeleteCurrency(OperatorRequest request)
        {

            var date = Convert.ToInt32(DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var oldData = Services.GetQ<Currency>().DataByKey(d=>d.CurrencyName==request.currency_name);
            oldData.state = 0;
            var result = Services.GetOp<Currency>().Update(d => d.CurrencyName == oldData.CurrencyName, oldData);

            return new BasicResponse<bool> { code = 001, data = result, desc = "success" };
        }
        /// <summary>
        /// 取得列表
        /// </summary>
        /// <returns></returns>
        public async ValueTask<BasicResponse<IEnumerable<QueryResponse>>> GetALLCurrency()
        {

            
            var datas = Services.GetQ<Currency>().AllDatas();
            var details = Services.GetQ<CurrencyDetail>().AllDatas();
            //left join 這是不會跳提示的但是可以過唷
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

        public async ValueTask<BasicResponse<IEnumerable<QueryResponse>>> GetByDate(string exchangeDate)
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
                      }).Where(t=>t.last_UpdateTime== Convert.ToDateTime(exchangeDate)).OrderByDescending(s=>s.last_UpdateTime).ToList();


            return new BasicResponse<IEnumerable<QueryResponse>> { code = 0001, data = response, desc = "success" };

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async ValueTask<BasicResponse<bool>> UpdateCurrency(OperatorRequest request)
        {
            var date = Convert.ToInt32(DateTimeOffset.UtcNow.ToString("yyyyMMdd"));
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var oldData = Services.GetQ<Currency>().DataByKey(d => d.CurrencyName == request.currency_name);
            oldData.CurrencyName = request.currency_name;
            oldData.CurrencyCname = request.currency_cname;
            oldData.state = request.state;
            oldData.Udate = date;
            var result = Services.GetOp<Currency>().Update(d => d.CurrencyName == oldData.CurrencyName, oldData);

            

            return new BasicResponse<bool> { code = 001, data = result, desc = "success" };
        }
    }
}
