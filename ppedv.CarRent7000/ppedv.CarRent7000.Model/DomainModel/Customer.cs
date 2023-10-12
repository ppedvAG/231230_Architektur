﻿namespace ppedv.CarRent7000.Model.DomainModel
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }

        public ICollection<Rent> RentsAsDriver { get; set; } = new HashSet<Rent>();
        public ICollection<Rent> RentsAsBiller { get; set; } = new HashSet<Rent>();
    }
}
