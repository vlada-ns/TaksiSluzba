namespace TaksiSluzba.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaksiSluzba.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaksiSluzba.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaksiSluzba.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Addresses.AddOrUpdate(x => x.Id,
                new Address() { Id = 1, Street = "Rumenacka", StreetNumber = "2", AreaCode = "21000", City = "Novi Sad" },
                new Address() { Id = 2, Street = "Temerinska", StreetNumber = "15", AreaCode = "21000", City = "Novi Sad" },
                new Address() { Id = 3, Street = "Radnicka", StreetNumber = "4", AreaCode = "21000", City = "Novi Sad" },
                new Address() { Id = 4, Street = "Sutjeska", StreetNumber = "2", AreaCode = "21000", City = "Novi Sad" }
                );

            context.Locations.AddOrUpdate(x => x.Id,
                new Location() { Id = 1, XCoordinate = "", YCoordinate = "", AddressId = 1 },
                new Location() { Id = 2, XCoordinate = "", YCoordinate = "", AddressId = 2 },
                new Location() { Id = 3, XCoordinate = "", YCoordinate = "", AddressId = 3 },
                new Location() { Id = 4, XCoordinate = "", YCoordinate = "", AddressId = 4 }
                );

            context.Dispathers.AddOrUpdate(x => x.Id,
                new Dispatcher() { Id = 1, Username = "dispecer1@gmail.com", Password = "Dispecer1@123", Name = "dispecer1", LastName = "dis1", Gender = Gender.Male, JMBG = 1234567890123, Telephone = "021555333", Email = "dispecer1@gmail.com", Role = "dispatcher", EmployeeOfTheMonth = false },
                new Dispatcher() { Id = 2, Username = "dispecer2@gmail.com", Password = "Dispecer2@123", Name = "dispecer2", LastName = "dis2", Gender = Gender.Female, JMBG = 1234567890123, Telephone = "021555333", Email = "dispecer2@gmail.com", Role = "dispatcher", EmployeeOfTheMonth = false },
                new Dispatcher() { Id = 3, Username = "dispecer3@gmail.com", Password = "Dispecer3@123", Name = "dispecer3", LastName = "dis3", Gender = Gender.Other, JMBG = 1234567890123, Telephone = "021555333", Email = "dispecer3@gmail.com", Role = "dispatcher", EmployeeOfTheMonth = false }
                );

            context.Drivers.AddOrUpdate(x => x.Id,
                new Driver() { Id = 4, Username = "driver1@gmail.com", Password = "Driver1@123", Name = "driver1", LastName = "dri1", Gender = Gender.Male, JMBG = 1234567890123, Telephone = "021555333", Email = "driver1@gmail.com", Role = "driver", Blocked = false, LocationId = 1 },
                new Driver() { Id = 5, Username = "driver2@gmail.com", Password = "Driver2@123", Name = "driver2", LastName = "dri2", Gender = Gender.Female, JMBG = 1234567890123, Telephone = "021555333", Email = "driver2@gmail.com", Role = "driver", Blocked = false, LocationId = 2 },
                new Driver() { Id = 6, Username = "driver3@gmail.com", Password = "Driver3@123", Name = "driver3", LastName = "dri3", Gender = Gender.Other, JMBG = 1234567890123, Telephone = "021555333", Email = "driver3@gmail.com", Role = "driver", Blocked = false, LocationId = 3 }
                );

            context.Customers.AddOrUpdate(x => x.Id,
                new Customer() { Id = 7, Username = "customer1@gmail.com", Password = "Customer1@123", Name = "customer1", LastName = "cus1", Gender = Gender.Male, JMBG = 1234567890123, Telephone = "021555333", Email = "customer1@gmail.com", Role = "customer", Blocked = false, BonusPoints = 5 },
                new Customer() { Id = 8, Username = "customer2@gmail.com", Password = "Customer2@123", Name = "customer2", LastName = "cus2", Gender = Gender.Female, JMBG = 1234567890123, Telephone = "021555333", Email = "customer2@gmail.com", Role = "customer", Blocked = false, BonusPoints = 2 },
                new Customer() { Id = 9, Username = "customer3@gmail.com", Password = "Customer3@123", Name = "customer3", LastName = "cus3", Gender = Gender.Other, JMBG = 1234567890123, Telephone = "021555333", Email = "customer3@gmail.com", Role = "customer", Blocked = false, BonusPoints = 0 }
                );

            context.Cars.AddOrUpdate(x => x.Id,
                new Car() { Id = 4, Year = 2006, RegistrationPlate = "NS228SY", TaxiNumber = "001", CarType = CarType.PassengerCar },
                new Car() { Id = 5, Year = 2009, RegistrationPlate = "NS554AB", TaxiNumber = "002", CarType = CarType.PassengerCar },
                new Car() { Id = 6, Year = 2016, RegistrationPlate = "NS001NS", TaxiNumber = "003", CarType = CarType.PassengerCar }
                );

            context.Drives.AddOrUpdate(x => x.Id,
                new Drive() { Id = 1, OrderDateTime = new DateTime(2019, 1, 10), LocationId = 1, CarType = CarType.PassengerCar, CustomerId = 1, DestinationId = 2, DispatcherId = 3, DriverId = 1, Amount = 100m, Status = Status.Successful },
                new Drive() { Id = 2, OrderDateTime = new DateTime(2019, 1, 10), LocationId = 1, CarType = CarType.PassengerCar, CustomerId = 1, DestinationId = 3, DispatcherId = 2, DriverId = 2, Amount = 100m, Status = Status.Successful },
                new Drive() { Id = 3, OrderDateTime = new DateTime(2019, 1, 10), LocationId = 2, CarType = CarType.PassengerCar, CustomerId = 1, DestinationId = 1, DispatcherId = 1, DriverId = 3, Amount = 150m, Status = Status.Successful },
                new Drive() { Id = 4, OrderDateTime = new DateTime(2019, 1, 11), LocationId = 2, CarType = CarType.PassengerCar, CustomerId = 1, DestinationId = 3, DispatcherId = 2, DriverId = 3, Amount = 150m, Status = Status.Successful },
                new Drive() { Id = 5, OrderDateTime = new DateTime(2019, 1, 11), LocationId = 3, CarType = CarType.PassengerCar, CustomerId = 1, DestinationId = 1, DispatcherId = 3, DriverId = 2, Amount = 200m, Status = Status.Successful },
                new Drive() { Id = 6, OrderDateTime = new DateTime(2019, 1, 11), LocationId = 3, CarType = CarType.PassengerCar, CustomerId = 1, DestinationId = 2, DispatcherId = 1, DriverId = 1, Amount = 200m, Status = Status.Successful },
                new Drive() { Id = 7, OrderDateTime = new DateTime(2019, 1, 12), LocationId = 1, CarType = CarType.PassengerCar, CustomerId = 2, DestinationId = 2, DispatcherId = 1, DriverId = 3, Amount = 250m, Status = Status.Successful },
                new Drive() { Id = 8, OrderDateTime = new DateTime(2019, 1, 12), LocationId = 1, CarType = CarType.PassengerCar, CustomerId = 2, DestinationId = 3, DispatcherId = 3, DriverId = 3, Amount = 250m, Status = Status.Successful },
                new Drive() { Id = 9, OrderDateTime = new DateTime(2019, 1, 12), LocationId = 2, CarType = CarType.PassengerCar, CustomerId = 2, DestinationId = 1, DispatcherId = 2, DriverId = 2, Amount = 300m, Status = Status.Successful },
                new Drive() { Id = 10, OrderDateTime = new DateTime(2019, 1, 13), LocationId = 2, CarType = CarType.PassengerCar, CustomerId = 2, DestinationId = 3, DispatcherId = 3, DriverId = 2, Amount = 300m, Status = Status.Successful },
                new Drive() { Id = 11, OrderDateTime = new DateTime(2019, 1, 13), LocationId = 3, CarType = CarType.PassengerCar, CustomerId = 2, DestinationId = 1, DispatcherId = 1, DriverId = 1, Amount = 350m, Status = Status.Successful },
                new Drive() { Id = 12, OrderDateTime = new DateTime(2019, 1, 13), LocationId = 3, CarType = CarType.PassengerCar, CustomerId = 2, DestinationId = 2, DispatcherId = 2, DriverId = 1, Amount = 350m, Status = Status.Successful },
                new Drive() { Id = 13, OrderDateTime = new DateTime(2019, 1, 12), LocationId = 1, CarType = CarType.PassengerCar, CustomerId = 3, DestinationId = 2, DispatcherId = 2, DriverId = 2, Amount = 400m, Status = Status.Successful },
                new Drive() { Id = 14, OrderDateTime = new DateTime(2019, 1, 12), LocationId = 1, CarType = CarType.PassengerCar, CustomerId = 3, DestinationId = 3, DispatcherId = 1, DriverId = 2, Amount = 400m, Status = Status.Successful },
                new Drive() { Id = 15, OrderDateTime = new DateTime(2019, 1, 12), LocationId = 2, CarType = CarType.PassengerCar, CustomerId = 3, DestinationId = 1, DispatcherId = 3, DriverId = 3, Amount = 450m, Status = Status.Successful },
                new Drive() { Id = 16, OrderDateTime = new DateTime(2019, 1, 13), LocationId = 2, CarType = CarType.PassengerCar, CustomerId = 3, DestinationId = 3, DispatcherId = 1, DriverId = 3, Amount = 450m, Status = Status.Successful },
                new Drive() { Id = 17, OrderDateTime = new DateTime(2019, 1, 13), LocationId = 3, CarType = CarType.PassengerCar, CustomerId = 3, DestinationId = 1, DispatcherId = 2, DriverId = 1, Amount = 500m, Status = Status.Successful },
                new Drive() { Id = 18, OrderDateTime = new DateTime(2019, 1, 13), LocationId = 3, CarType = CarType.PassengerCar, CustomerId = 3, DestinationId = 2, DispatcherId = 3, DriverId = 1, Amount = 500m, Status = Status.Successful }
                );
        }
    }
}
