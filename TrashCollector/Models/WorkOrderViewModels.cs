using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class WorkOrderCreateViewModel
    {
        [Display(Name ="Service Date")]
        public DateTime? ScheduledDate { get; set; }

        [Display(Name ="Status")]
        public int StatusId { get; set; }

        [Required]
        [StringLength(128)]
        public string CustomerUserId { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<WorkOrderStatus> Statuses { get; set; }
    }
}