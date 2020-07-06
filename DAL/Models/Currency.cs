using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.DAL.Models
{
    public class Currency
    {        
        public int Id { get; set; }
        /// <summary>
        /// 幣別英文
        /// </summary>
        public string  CurrencyName { get; set; }
        /// <summary>
        /// 幣別中文
        /// </summary>
        public string CurrencyCname { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public int Cdate { get; set; }
        /// <summary>
        /// 更新時間
        /// </summary>
        public int Udate { get; set; }
        /// <summary>
        /// 是否開放
        /// </summary>
        public int state { get; set; }

    }
}
