namespace ppedv.CarRent7000.Model.DomainModel
{
    public class Car : Entity
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int KW { get; set; }
        public DateTime BuildDate { get; set; }
        public double Kilometer { get; set; }

        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();

    }
}
