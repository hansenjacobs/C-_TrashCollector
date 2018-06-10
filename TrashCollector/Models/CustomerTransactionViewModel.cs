using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerTransactionViewModel
    {
        public Customer Customer { get; set; }
        public List<Transaction> Transactions { get; set; }
        public double Balance { get; set; }
    }
}