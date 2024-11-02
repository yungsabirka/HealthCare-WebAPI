using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System.Linq;
using Xunit;

public class AppointmentRelationshipContextTest
{
    [Fact]
    public void CanAddAppointmentRelationshipToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanAddAppointmentRelationshipToDatabase")
            .Options;

        // Act
        using (var context = new AppointmentRelationshipContext(options))
        {
            var appointmentRelationship = new AppointmentRelationship
            {
                AppointmentRelationshipId = 1,
                AppointmentId = 1,
                DoctorId = 1,
                UserId = 1
            };

            context.AppointmentRelationships.Add(appointmentRelationship);
            context.SaveChanges();
        }

        // Assert
        using (var context = new AppointmentRelationshipContext(options))
        {
            Assert.Equal(1, context.AppointmentRelationships.Count());
            var savedAppointmentRelationship = context.AppointmentRelationships.First();
            Assert.Equal(1, savedAppointmentRelationship.AppointmentId);
        }
    }

    [Fact]
    public void CanRetrieveAppointmentRelationshipFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrieveAppointmentRelationshipFromDatabase")
            .Options;

        using (var context = new AppointmentRelationshipContext(options))
        {
            var appointmentRelationship = new AppointmentRelationship
            {
                AppointmentRelationshipId = 1,
                AppointmentId = 1,
                DoctorId = 1,
                UserId = 1
            };

            context.AppointmentRelationships.Add(appointmentRelationship);
            context.SaveChanges();
        }

        // Act
        using (var context = new AppointmentRelationshipContext(options))
        {
            var savedAppointmentRelationship = context.AppointmentRelationships.FirstOrDefault(ar => ar.AppointmentId == 1);

            // Assert
            Assert.NotNull(savedAppointmentRelationship);
            Assert.Equal(1, savedAppointmentRelationship.AppointmentId);
        }
    }

    [Fact]
    public void CanUpdateAppointmentRelationshipInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdateAppointmentRelationshipInDatabase")
            .Options;

        using (var context = new AppointmentRelationshipContext(options))
        {
            var appointmentRelationship = new AppointmentRelationship
            {
                AppointmentRelationshipId = 1,
                AppointmentId = 1,
                DoctorId = 1,
                UserId = 1
            };

            context.AppointmentRelationships.Add(appointmentRelationship);
            context.SaveChanges();
        }

        // Act
        using (var context = new AppointmentRelationshipContext(options))
        {
            var savedAppointmentRelationship = context.AppointmentRelationships.FirstOrDefault(ar => ar.AppointmentId == 1);
            Assert.NotNull(savedAppointmentRelationship);

            savedAppointmentRelationship.AppointmentId = 2;
            context.SaveChanges();
        }

        // Assert
        using (var context = new AppointmentRelationshipContext(options))
        {
            var updatedAppointmentRelationship = context.AppointmentRelationships.FirstOrDefault(ar => ar.AppointmentId == 2);
            Assert.NotNull(updatedAppointmentRelationship);
            Assert.Equal(2, updatedAppointmentRelationship.AppointmentId);
        }
    }

    [Fact]
    public void CanDeleteAppointmentRelationshipFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanDeleteAppointmentRelationshipFromDatabase")
            .Options;

        using (var context = new AppointmentRelationshipContext(options))
        {
            var appointmentRelationship = new AppointmentRelationship
            {
                AppointmentRelationshipId = 1,
                AppointmentId = 1,
                DoctorId = 1,
                UserId = 1
            };

            context.AppointmentRelationships.Add(appointmentRelationship);
            context.SaveChanges();
        }

        // Act
        using (var context = new AppointmentRelationshipContext(options))
        {
            var savedAppointmentRelationship = context.AppointmentRelationships.FirstOrDefault(ar => ar.AppointmentId == 1);
            Assert.NotNull(savedAppointmentRelationship);

            context.AppointmentRelationships.Remove(savedAppointmentRelationship);
            context.SaveChanges();
        }

        // Assert
        using (var context = new AppointmentRelationshipContext(options))
        {
            Assert.Equal(0, context.AppointmentRelationships.Count());
        }
    }

}
