using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityframeworkDemo.Models
{
    public class TransactionDetails
    {
        public int tranid { get; set; }
        public DateTime trandate { get; set; }
        public decimal amt { get; set; }
    }
}