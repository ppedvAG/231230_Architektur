// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.CarRent7000.Api.Controllers
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int KW { get; set; }
        public DateTime BuildDate { get; set; }
        public double Kilometer { get; set; }
    }
}
