using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;

namespace ppedv.CarRent7000.Data.EfCore
{
    public class CarRentRepository : IRepository
    {
        private CarRentContext _context = new CarRentContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if (typeof(T).IsAssignableFrom(typeof(Rent)))
            //    _context.Rents.Add(entity as Rent);
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public int SaveAll()
        {
            return _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }
    }
}
