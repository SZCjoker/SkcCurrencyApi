using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.DAL.Models
{
    public class CurrencyDetail
    {
        public int Id { get; set; }
        /// <summary>
        /// 幣別英文
        /// </summary>
        public string CurrencyName { get; set; }
        /// <summary>
        /// 本行售出
        /// </summary>
        public string CashSale { get; set; }
        /// <summary>
        /// 本行買入
        /// </summary>
        public string CashBuy { get; set; }
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime LastUpdateTime { get; set; }
    }
}
