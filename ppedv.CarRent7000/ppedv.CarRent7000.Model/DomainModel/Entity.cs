﻿namespace ppedv.CarRent7000.Model.DomainModel
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
