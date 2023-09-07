using System.ComponentModel.DataAnnotations;

namespace ParkView_Capstone.Models.Servicess
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }
        public string ServiceImage { get; set; }
    }
}
