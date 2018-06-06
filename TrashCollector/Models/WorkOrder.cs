using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }

        public DateTime SubmittedDateTime { get; set; }

        public DateTime ScheduledDate { get; set; }

        public int TypeId { get; set; }
        public WorkOrderType Type { get; set; }

        public int StatusId { get; set; }
        public WorkOrderStatus Status { get; set; }

        public ApplicationUser RequestedBy { get; set; }

        public Address ServiceAddress { get; set; }

        public DateTime? CompletionDateTime { get; set; }

        public ApplicationUser CompletedBy { get; set; }
    }
}