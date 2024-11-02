using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System;
using System.Linq;
using Xunit;

public class PastAppointmentContextTest
{
    [Fact]
    public void CanAddPastAppointmentToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PastAppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanAddPastAppointmentToDatabase")
            .Options;

        // Act
        using (var context = new PastAppointmentContext(options))
        {
            var pastAppointment = new PastAppointment
            {
                PastAppointmentKey = 1,
                DeletedTime = DateTime.Now,
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Completed"
            };

            context.PastAppointments.Add(pastAppointment);
            context.SaveChanges();
        }

        // Assert
        using (var context = new PastAppointmentContext(options))
        {
            Assert.Equal(1, context.PastAppointments.Count());
            var savedPastAppointment = context.PastAppointments.First();
            Assert.Equal(1, savedPastAppointment.PastAppointmentKey);
        }
    }

    [Fact]
    public void CanRetrievePastAppointmentFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PastAppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrievePastAppointmentFromDatabase")
            .Options;

        using (var context = new PastAppointmentContext(options))
        {
            var pastAppointment = new PastAppointment
            {
                PastAppointmentKey = 1,
                DeletedTime = DateTime.Now,
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Completed"
            };

            context.PastAppointments.Add(pastAppointment);
            context.SaveChanges();
        }

        // Act
        using (var context = new PastAppointmentContext(options))
        {
            var savedPastAppointment = context.PastAppointments.FirstOrDefault(pa => pa.PastAppointmentKey == 1);

            // Assert
            Assert.NotNull(savedPastAppointment);
            Assert.Equal(1, savedPastAppointment.PastAppointmentKey);
        }
    }

    [Fact]
    public void CanUpdatePastAppointmentInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PastAppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdatePastAppointmentInDatabase")
            .Options;

        using (var context = new PastAppointmentContext(options))
        {
            var pastAppointment = new PastAppointment
            {
                PastAppointmentKey = 1,
                DeletedTime = DateTime.Now,
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Completed"
            };

            context.PastAppointments.Add(pastAppointment);
            context.SaveChanges();
        }

        // Act
        using (var context = new PastAppointmentContext(options))
        {
            var savedPastAppointment = context.PastAppointments.FirstOrDefault(pa => pa.PastAppointmentKey == 1);
            Assert.NotNull(savedPastAppointment);

            savedPastAppointment.AppointmentId = 2;
            context.SaveChanges();
        }

        // Assert
        using (var context = new PastAppointmentContext(options))
        {
            var updatedPastAppointment = context.PastAppointments.FirstOrDefault(pa => pa.PastAppointmentKey == 1);
            Assert.NotNull(updatedPastAppointment);
            Assert.Equal(2, updatedPastAppointment.AppointmentId);
        }
    }

    [Fact]
    public void CanDeletePastAppointmentFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<PastAppointmentContext>()
            .UseInMemoryDatabase(databaseName: "CanDeletePastAppointmentFromDatabase")
            .Options;

        using (var context = new PastAppointmentContext(options))
        {
            var pastAppointment = new PastAppointment
            {
                PastAppointmentKey = 1,
                DeletedTime = DateTime.Now,
                AppointmentId = 1,
                StartTime = DateTime.Now,
                Status = "Completed"
            };

            context.PastAppointments.Add(pastAppointment);
            context.SaveChanges();
        }

        // Act
        using (var context = new PastAppointmentContext(options))
        {
            var savedPastAppointment = context.PastAppointments.FirstOrDefault(pa => pa.PastAppointmentKey == 1);
            Assert.NotNull(savedPastAppointment);

            context.PastAppointments.Remove(savedPastAppointment);
            context.SaveChanges();
        }

        // Assert
        using (var context = new PastAppointmentContext(options))
        {
            Assert.Equal(0, context.PastAppointments.Count());
        }
    }
}
