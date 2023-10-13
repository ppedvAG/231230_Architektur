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


        public IEnumerable<Car> GetAvailableCars(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool IsCarAvailable(Car car, DateTime start, DateTime end)
        {
            var query = repository.GetAll<Rent>().Where(x => x.Car == car);

            return query.Any();
        }

        public int CalcBillingDays(Rent rent)
        {
            var ts = rent.EndDate - rent.StartDate;
            //todo: sonntage raus rechnen
            return ts.Value.Days;
        }
    }
}
