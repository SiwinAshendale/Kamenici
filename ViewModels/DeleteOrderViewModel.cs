using System.ComponentModel.DataAnnotations;

namespace Kamenici.ViewModels
{
    public class DeleteOrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int FrameId { get; set; }
    }
}
