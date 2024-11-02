using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System.Linq;
using Xunit;

public class MedicationRelationshipContextTest
{
    [Fact]
    public void CanAddMedicationRelationshipToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicationRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanAddMedicationRelationshipToDatabase")
            .Options;

        // Act
        using (var context = new MedicationRelationshipContext(options))
        {
            var medicationRelationship = new MedicationRelationship
            {
                MedicationRelationshipId = 1,
                MedicalCardId = 1,
                MedicationId = 1
            };

            context.MedicationRelationships.Add(medicationRelationship);
            context.SaveChanges();
        }

        // Assert
        using (var context = new MedicationRelationshipContext(options))
        {
            Assert.Equal(1, context.MedicationRelationships.Count());
            var savedMedicationRelationship = context.MedicationRelationships.First();
            Assert.Equal(1, savedMedicationRelationship.MedicalCardId);
        }
    }

    [Fact]
    public void CanRetrieveMedicationRelationshipFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicationRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrieveMedicationRelationshipFromDatabase")
            .Options;

        using (var context = new MedicationRelationshipContext(options))
        {
            var medicationRelationship = new MedicationRelationship
            {
                MedicationRelationshipId = 1,
                MedicalCardId = 1,
                MedicationId = 1
            };

            context.MedicationRelationships.Add(medicationRelationship);
            context.SaveChanges();
        }

        // Act
        using (var context = new MedicationRelationshipContext(options))
        {
            var savedMedicationRelationship = context.MedicationRelationships.FirstOrDefault(mr => mr.MedicalCardId == 1);

            // Assert
            Assert.NotNull(savedMedicationRelationship);
            Assert.Equal(1, savedMedicationRelationship.MedicalCardId);
        }
    }

    [Fact]
    public void CanUpdateMedicationRelationshipInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicationRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdateMedicationRelationshipInDatabase")
            .Options;

        using (var context = new MedicationRelationshipContext(options))
        {
            var medicationRelationship = new MedicationRelationship
            {
                MedicationRelationshipId = 1,
                MedicalCardId = 1,
                MedicationId = 1
            };

            context.MedicationRelationships.Add(medicationRelationship);
            context.SaveChanges();
        }

        // Act
        using (var context = new MedicationRelationshipContext(options))
        {
            var savedMedicationRelationship = context.MedicationRelationships.FirstOrDefault(mr => mr.MedicalCardId == 1);
            Assert.NotNull(savedMedicationRelationship);

            savedMedicationRelationship.MedicalCardId = 2;
            context.SaveChanges();
        }

        // Assert
        using (var context = new MedicationRelationshipContext(options))
        {
            var updatedMedicationRelationship = context.MedicationRelationships.FirstOrDefault(mr => mr.MedicalCardId == 2);
            Assert.NotNull(updatedMedicationRelationship);
            Assert.Equal(2, updatedMedicationRelationship.MedicalCardId);
        }
    }

    [Fact]
    public void CanDeleteMedicationRelationshipFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicationRelationshipContext>()
            .UseInMemoryDatabase(databaseName: "CanDeleteMedicationRelationshipFromDatabase")
            .Options;

        using (var context = new MedicationRelationshipContext(options))
        {
            var medicationRelationship = new MedicationRelationship
            {
                MedicationRelationshipId = 1,
                MedicalCardId = 1,
                MedicationId = 1
            };

            context.MedicationRelationships.Add(medicationRelationship);
            context.SaveChanges();
        }

        // Act
        using (var context = new MedicationRelationshipContext(options))
        {
            var savedMedicationRelationship = context.MedicationRelationships.FirstOrDefault(mr => mr.MedicalCardId == 1);
            Assert.NotNull(savedMedicationRelationship);

            context.MedicationRelationships.Remove(savedMedicationRelationship);
            context.SaveChanges();
        }

        // Assert
        using (var context = new MedicationRelationshipContext(options))
        {
            Assert.Equal(0, context.MedicationRelationships.Count());
        }
    }

}
