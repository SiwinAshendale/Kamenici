using Kamenici.Models;
using System;
using System.Collections.Generic;
namespace Kamenici.Data
{
    public partial class Order
    {
        public Order(int FrameId, DateTime DueDate, string CreatedBy)
        {
            this.FrameId = FrameId;
            this.Status = "Pending";
            this.DueDate = DueDate;
            this.CreatedBy = CreatedBy;
            this.OrderDate = DateTime.Today;
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CreatedBy { get; set; }
        public int FrameId { get; set; }
        public string Status { get; set; }

        public virtual Microsoft.AspNetCore.Identity.IdentityUser CreatedByNavigation { get; set; }
        public virtual Frame Frame { get; set; }
    }
}
