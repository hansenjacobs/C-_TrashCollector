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

        [Required]
        [StringLength(128)]
        public string RequestedById { get; set; }
        public ApplicationUser RequestedBy { get; set; }

        public int ServiceAddressId { get; set; }
        public Address ServiceAddress { get; set; }

        public DateTime? CompletionDateTime { get; set; }

        [StringLength(128)]
        public string CompletedById { get; set; }
        public ApplicationUser CompletedBy { get; set; }

        public static WorkOrder ScheduleNextPickUp (ApplicationDbContext _context, ApplicationUser requetedBy)
        {
            int daysToAdd = ((int)requetedBy.WeeklyPickupDayId - (int)DateTime.Today.DayOfWeek + 7) % 7;
            var newWorkOrder = new WorkOrder()
            {
                SubmittedDateTime = DateTime.Now,
                ScheduledDate = DateTime.Today.AddDays(daysToAdd),
                TypeId = WorkOrderType.ReoccurringWeekly,
                StatusId = WorkOrderStatus.Confirmed,
                RequestedById = requetedBy.Id,
                ServiceAddressId = requetedBy.AddressId
            };

            _context.WorkOrders.Add(newWorkOrder);
            _context.SaveChanges();
            
            return newWorkOrder;
        }
    }
}