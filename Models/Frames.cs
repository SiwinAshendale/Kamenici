using System;
using System.Collections.Generic;

namespace Kamenici.Data
{
    public partial class Frame
    {
        public Frame()
        {
            Orders = new HashSet<Order>();
        }

        public int FrameId { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public bool? Available { get; set; }
        public int Price { get; set; }
        public string CreatedById { get; set; }

        public virtual Microsoft.AspNetCore.Identity.IdentityUser CreatedBy { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
