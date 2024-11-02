using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System.Linq;
using Xunit;

public class DoctorContextTest
{
    [Fact]
    public void CanAddDoctorToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorContext>()
            .UseInMemoryDatabase(databaseName: "CanAddDoctorToDatabase")
            .Options;

        // Act
        using (var context = new DoctorContext(options))
        {
            var doctor = new Doctor
            {
                DoctorId = 1,
                Name = "Dr. John Doe",
                Specialization = "Cardiologist"
            };

            context.Doctors.Add(doctor);
            context.SaveChanges();
        }

        // Assert
        using (var context = new DoctorContext(options))
        {
            Assert.Equal(1, context.Doctors.Count());
            var savedDoctor = context.Doctors.First();
            Assert.Equal("Dr. John Doe", savedDoctor.Name);
        }
    }

    [Fact]
    public void CanRetrieveDoctorFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrieveDoctorFromDatabase")
            .Options;

        using (var context = new DoctorContext(options))
        {
            var doctor = new Doctor
            {
                DoctorId = 1,
                Name = "Dr. John Doe",
                Specialization = "Cardiologist"
            };

            context.Doctors.Add(doctor);
            context.SaveChanges();
        }

        // Act
        using (var context = new DoctorContext(options))
        {
            var savedDoctor = context.Doctors.FirstOrDefault(d => d.Name == "Dr. John Doe");

            // Assert
            Assert.NotNull(savedDoctor);
            Assert.Equal("Dr. John Doe", savedDoctor.Name);
        }
    }

    [Fact]
    public void CanUpdateDoctorInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdateDoctorInDatabase")
            .Options;

        using (var context = new DoctorContext(options))
        {
            var doctor = new Doctor
            {
                DoctorId = 1,
                Name = "Dr. John Doe",
                Specialization = "Cardiologist"
            };

            context.Doctors.Add(doctor);
            context.SaveChanges();
        }

        // Act
        using (var context = new DoctorContext(options))
        {
            var savedDoctor = context.Doctors.FirstOrDefault(d => d.Name == "Dr. John Doe");
            Assert.NotNull(savedDoctor);

            savedDoctor.Name = "Dr. Jane Smith";
            context.SaveChanges();
        }

        // Assert
        using (var context = new DoctorContext(options))
        {
            var updatedDoctor = context.Doctors.FirstOrDefault(d => d.Name == "Dr. Jane Smith");
            Assert.NotNull(updatedDoctor);
            Assert.Equal("Dr. Jane Smith", updatedDoctor.Name);
        }
    }

    [Fact]
    public void CanDeleteDoctorFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DoctorContext>()
            .UseInMemoryDatabase(databaseName: "CanDeleteDoctorFromDatabase")
            .Options;

        using (var context = new DoctorContext(options))
        {
            var doctor = new Doctor
            {
                DoctorId = 1,
                Name = "Dr. John Doe",
                Specialization = "Cardiologist"
            };

            context.Doctors.Add(doctor);
            context.SaveChanges();
        }

        // Act
        using (var context = new DoctorContext(options))
        {
            var savedDoctor = context.Doctors.FirstOrDefault(d => d.Name == "Dr. John Doe");
            Assert.NotNull(savedDoctor);

            context.Doctors.Remove(savedDoctor);
            context.SaveChanges();
        }

        // Assert
        using (var context = new DoctorContext(options))
        {
            Assert.Equal(0, context.Doctors.Count());
        }
    }
}
