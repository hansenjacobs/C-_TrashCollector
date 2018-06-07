using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class WorkOrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public bool IsConfirmed { get; set; }

        public const int Requested = 1;
        public const int Confirmed = 2;
        public const int Completed = 3;
        public const int Cancelled = 4;
    }
}