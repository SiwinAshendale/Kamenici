using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Kamenici.Data
{
    public partial class Frame
    {
        public Frame(int width, int height, int price, string CreatedById)
        {
            Available = true;
            Width = width;
            Height = height;
            Price = price;
            this.CreatedById = CreatedById;

        }

        public int FrameId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool? Available { get; set; }
        public int Price { get; set; }
        public string CreatedById { get; set; }

        public virtual Microsoft.AspNetCore.Identity.IdentityUser CreatedBy { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
