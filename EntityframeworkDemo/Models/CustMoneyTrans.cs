using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityframeworkDemo.Models
{
    public class CustMoneyTrans
    {
        public int CustFrom { get; set; }
        public int CustTo { get; set; }
        public decimal Amt { get; set; }
    }
}