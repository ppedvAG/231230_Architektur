using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;

namespace ppedv.CarRent7000.Logic.Core
{
    public class RentService
    {
        private readonly IRepository repository;

        public RentService(IRepository repository)
        {
            this.repository = repository;
        }

        public bool IsCarAvailable(Car car, DateTime start, DateTime end)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            if(end<start)
                throw new ArgumentException("Ende darf nicht vor dem Start sein");

            // Check if there are any existing rentals for the car that overlap with the specified time period
            var overlappingRentals = repository.GetAll<Rent>()
                .Where(x => x.Car == car &&
                            !(x.StartDate >= end || x.EndDate <= start))
                .ToList();

            return overlappingRentals.Count == 0;
        }


        public IEnumerable<Car> GetAvailableCars(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }


        public int CalcBillingDays(Rent rent)
        {
            var ts = rent.EndDate - rent.StartDate;
            //todo: sonntage raus rechnen
            return ts.Value.Days;
        }
    }
}
