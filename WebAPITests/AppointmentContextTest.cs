using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System;
using System.Linq;
using Xunit;

public class AppointmentContextTest
{
    [Fact]
    public void CanAddAppointmentToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanAddAppointmentToDatabase")
            .Options;

        // Act
        using (var context = new AppointmentContext(options))
        {
            var appointment = new Appointment
            {
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Scheduled"
            };

            context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        // Assert
        using (var context = new AppointmentContext(options))
        {
            Assert.Equal(1, context.Appointments.Count());
            var savedAppointment = context.Appointments.First();
            Assert.Equal("Scheduled", savedAppointment.Status);
        }
    }

    [Fact]
    public void CanRetrieveAppointmentFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrieveAppointmentFromDatabase")
            .Options;

        using (var context = new AppointmentContext(options))
        {
            var appointment = new Appointment
            {
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Scheduled"
            };

            context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        // Act
        using (var context = new AppointmentContext(options))
        {
            var savedAppointment = context.Appointments.FirstOrDefault(a => a.Status == "Scheduled");

            // Assert
            Assert.NotNull(savedAppointment);
            Assert.Equal("Scheduled", savedAppointment.Status);
        }
    }

    [Fact]
    public void CanUpdateAppointmentInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdateAppointmentInDatabase")
            .Options;

        using (var context = new AppointmentContext(options))
        {
            var appointment = new Appointment
            {
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Scheduled"
            };

            context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        // Act
        using (var context = new AppointmentContext(options))
        {
            var savedAppointment = context.Appointments.FirstOrDefault(a => a.Status == "Scheduled");
            Assert.NotNull(savedAppointment);

            savedAppointment.Status = "Completed";
            context.SaveChanges();
        }

        // Assert
        using (var context = new AppointmentContext(options))
        {
            var updatedAppointment = context.Appointments.FirstOrDefault(a => a.Status == "Completed");
            Assert.NotNull(updatedAppointment);
            Assert.Equal("Completed", updatedAppointment.Status);
        }
    }

    [Fact]
    public void CanDeleteAppointmentFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanDeleteAppointmentFromDatabase")
            .Options;

        using (var context = new AppointmentContext(options))
        {
            var appointment = new Appointment
            {
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Scheduled"
            };

            context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        // Act
        using (var context = new AppointmentContext(options))
        {
            var savedAppointment = context.Appointments.FirstOrDefault(a => a.Status == "Scheduled");
            Assert.NotNull(savedAppointment);

            context.Appointments.Remove(savedAppointment);
            context.SaveChanges();
        }

        // Assert
        using (var context = new AppointmentContext(options))
        {
            Assert.Equal(0, context.Appointments.Count());
        }
    }

}
