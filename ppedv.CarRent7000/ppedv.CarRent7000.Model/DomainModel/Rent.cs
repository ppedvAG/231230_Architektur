﻿namespace ppedv.CarRent7000.Model.DomainModel
{
    public class Rent : Entity
    {
        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public string StartLocation { get; set; } = string.Empty;
        public string? EndLocation { get; set; } = null;

        public Car? Car { get; set; }

        public Customer? Driver { get; set; }
        public Customer? Biller { get; set; }
    }
}
