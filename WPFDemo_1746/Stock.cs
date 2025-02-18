using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo_1734.Class
{
    /// <summary>
    /// Stock表單
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// 股票代號
        /// </summary>
        public string Stock_No { get; set; }
        /// <summary>
        /// 股票中文簡稱
        /// </summary>
        public string Stock_Name { get; set; }
        /// <summary>
        /// 最低成交價
        /// </summary>
        public decimal Low_Price { get; set; }
        /// <summary>
        /// 最高成交價
        /// </summary>
        public decimal High_Price { get; set; }
        /// <summary>
        /// 異動日期
        /// </summary>
        public DateTime Modify_Date { get; set; }
        /// <summary>
        /// 異動人員
        /// </summary>
        public string Modify_User { get; set; }
    }
}
