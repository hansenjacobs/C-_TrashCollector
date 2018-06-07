using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerIndexViewModel
    {
        public ApplicationUser Customer { get; set; }
        public WorkOrder NextWorkOrder { get; set; }
    }
}