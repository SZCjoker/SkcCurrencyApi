using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.BLL.Application.Response
{
    public class QueryResponse
    {
        public int id { get; set; }
        /// <summary>
        /// 幣別英文
        /// </summary>
        public string currency_name { get; set; }
        /// <summary>
        /// 幣別中文
        /// </summary>
        public string currency_cname { get; set; }
        /// <summary>
        /// 本行售出
        /// </summary>
        public string cash_sale { get; set; }
        /// <summary>
        /// 本行買入
        /// </summary>
        public string cash_buy { get; set; }
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime last_UpdateTime { get; set; }
    }
}
