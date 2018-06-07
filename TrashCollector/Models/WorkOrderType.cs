using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class WorkOrderType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public const int ReoccurringWeekly = 1;
        public const int OneTime = 2;
    }
}