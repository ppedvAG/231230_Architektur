using NSubstitute;
using ppedv.CarRent7000.Model.Contracts;
using ppedv.CarRent7000.Model.DomainModel;

namespace ppedv.CarRent7000.Logic.Core.Tests.RentServiceTests
{
    public class RentServiceTestsIsCarAvailable
    {
        [Fact]
        public void Throw_ArgumentNullEx_if_car_is_null()
        {
            var rs = new RentService(null);

            Assert.Throws<ArgumentNullException>(() => rs.IsCarAvailable(null, DateTime.Now, DateTime.Now));
        }

        [Fact]
        public void Throw_ArgumentEx_if_end_date_is_before_start_date()
        {
            var rs = new RentService(null);
            var car = new Car();

            Assert.Throws<ArgumentException>(() => rs.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddDays(-1)));
        }

        [Fact]
        public void Car_with_no_rents_should_be_available()
        {
            // Arrange
            var car = new Car();
            var repository = Substitute.For<IRepository>();
            repository.GetAll<Rent>().Returns(new List<Rent>());
            var rentService = new RentService(repository);

            // Act
            var isAvailable = rentService.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.True(isAvailable);
        }

        [Fact]
        public void Car_with_rents_not_in_date_range_should_be_available()
        {
            // Arrange
            var car = new Car();
            var repository = Substitute.For<IRepository>();
            var rental = new Rent { Car = car, StartDate = DateTime.Now.AddHours(2), EndDate = DateTime.Now.AddHours(3) };
            repository.GetAll<Rent>().Returns(new List<Rent> { rental });
            var rentService = new RentService(repository);

            // Act
            var isAvailable = rentService.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.True(isAvailable);
        }

        [Fact]
        public void Car_with_rents_in_date_range_should_not_be_available()
        {
            // Arrange
            var car = new Car();
            var repository = Substitute.For<IRepository>();
            var rental = new Rent { Car = car, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(1) };
            repository.GetAll<Rent>().Returns(new List<Rent> { rental });
            var rentService = new RentService(repository);

            // Act
            var isAvailable = rentService.IsCarAvailable(car, DateTime.Now, DateTime.Now.AddHours(2));

            // Assert
            Assert.False(isAvailable);
        }
    }
}