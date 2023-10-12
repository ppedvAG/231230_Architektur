using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ppedv.CarRent7000.Model.DomainModel;
using System.Reflection;

namespace ppedv.CarRent7000.Data.EfCore.Tests
{
    public class CarRentContextTests
    {
        [Fact]
        public void Can_create_db()
        {
            var con = new CarRentContext();
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_insert_car()
        {
            var car = new Car() { Color = "blue", Model = "zwölf" };
            var con = new CarRentContext();

            con.Add(car);
            var affRows = con.SaveChanges();

            Assert.Equal(1, affRows);
        }

        [Fact]
        public void Can_read_car()
        {
            var car = new Car() { Color = "red", Model = $"elf_{Guid.NewGuid()}" };

            using (var con = new CarRentContext())
            {
                con.Add(car);
                con.SaveChanges();
            }

            using (var con = new CarRentContext())
            {
                var loaded = con.Cars.Find(car.Id);
                Assert.NotNull(loaded);
                Assert.Equal(car.Model, loaded.Model);
            }
        }

        [Fact]
        public void Can_update_car()
        {
            var car = new Car() { Color = "red", Model = "elf" };
            var newModel = "zehn";

            using (var con = new CarRentContext())
            {
                con.Add(car);
                con.SaveChanges();
            }

            using (var con = new CarRentContext())
            {
                var loaded = con.Cars.Find(car.Id);
                loaded.Model = newModel;
                con.SaveChanges();
            }

            using (var con = new CarRentContext())
            {
                var loaded = con.Cars.Find(car.Id);
                Assert.Equal(newModel, loaded.Model);
            }
        }

        [Fact]
        public void Can_delete_car()
        {
            var car = new Car() { Color = "pink", Model = "neun" };

            using (var con = new CarRentContext())
            {
                con.Add(car);
                con.SaveChanges();
            }

            using (var con = new CarRentContext())
            {
                var loaded = con.Cars.Find(car.Id);
                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new CarRentContext())
            {
                var loaded = con.Cars.Find(car.Id);
                Assert.Null(loaded);
            }
        }


        [Fact]
        public void Can_add_and_read_car_with_autofix_and_fluentAssertions()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));

            var car = fix.Create<Car>();

            using (var con = new CarRentContext())
            {
                con.Add(car);
                con.SaveChanges();
            }

            using (var con = new CarRentContext())
            {
                var loaded = con.Cars.Include(x => x.Rents)
                                     .ThenInclude(x => x.Biller)
                                     .Include(x => x.Rents)
                                     .ThenInclude(x => x.Driver)
                                     .Where(x => x.Id == car.Id)
                                     .FirstOrDefault();

                loaded.Should().BeEquivalentTo(car, x => x.IgnoringCyclicReferences());
            }

        }

        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }
    }
}