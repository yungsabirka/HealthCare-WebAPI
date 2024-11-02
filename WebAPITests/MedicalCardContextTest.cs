using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System.Linq;
using Xunit;

public class MedicalCardContextTest
{
    [Fact]
    public void CanAddMedicalCardToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicalCardContext>()
            .UseInMemoryDatabase(databaseName: "CanAddMedicalCardToDatabase")
            .Options;

        // Act
        using (var context = new MedicalCardContext(options))
        {
            var medicalCard = new MedicalCard
            {
                MedicalCardId = 1,
                Diseases = "Flu",
                Description = "Patient has symptoms of flu.",
                Treatment = "Rest and stay hydrated",
                TestResults = "Negative"
            };

            context.MedicalCards.Add(medicalCard);
            context.SaveChanges();
        }

        // Assert
        using (var context = new MedicalCardContext(options))
        {
            Assert.Equal(1, context.MedicalCards.Count());
            var savedMedicalCard = context.MedicalCards.First();
            Assert.Equal("Flu", savedMedicalCard.Diseases);
        }
    }

    [Fact]
    public void CanRetrieveMedicalCardFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicalCardContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrieveMedicalCardFromDatabase")
            .Options;

        using (var context = new MedicalCardContext(options))
        {
            var medicalCard = new MedicalCard
            {
                MedicalCardId = 1,
                Diseases = "Flu",
                Description = "Patient has symptoms of flu.",
                Treatment = "Rest and stay hydrated",
                TestResults = "Negative"
            };

            context.MedicalCards.Add(medicalCard);
            context.SaveChanges();
        }

        // Act
        using (var context = new MedicalCardContext(options))
        {
            var savedMedicalCard = context.MedicalCards.FirstOrDefault(mc => mc.Diseases == "Flu");

            // Assert
            Assert.NotNull(savedMedicalCard);
            Assert.Equal("Flu", savedMedicalCard.Diseases);
        }
    }

    [Fact]
    public void CanUpdateMedicalCardInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicalCardContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdateMedicalCardInDatabase")
            .Options;

        using (var context = new MedicalCardContext(options))
        {
            var medicalCard = new MedicalCard
            {
                MedicalCardId = 1,
                Diseases = "Flu",
                Description = "Patient has symptoms of flu.",
                Treatment = "Rest and stay hydrated",
                TestResults = "Negative"
            };

            context.MedicalCards.Add(medicalCard);
            context.SaveChanges();
        }

        // Act
        using (var context = new MedicalCardContext(options))
        {
            var savedMedicalCard = context.MedicalCards.FirstOrDefault(mc => mc.Diseases == "Flu");
            Assert.NotNull(savedMedicalCard);

            savedMedicalCard.Diseases = "Cold";
            context.SaveChanges();
        }

        // Assert
        using (var context = new MedicalCardContext(options))
        {
            var updatedMedicalCard = context.MedicalCards.FirstOrDefault(mc => mc.Diseases == "Cold");
            Assert.NotNull(updatedMedicalCard);
            Assert.Equal("Cold", updatedMedicalCard.Diseases);
        }
    }

    [Fact]
    public void CanDeleteMedicalCardFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MedicalCardContext>()
            .UseInMemoryDatabase(databaseName: "CanDeleteMedicalCardFromDatabase")
            .Options;

        using (var context = new MedicalCardContext(options))
        {
            var medicalCard = new MedicalCard
            {
                MedicalCardId = 1,
                Diseases = "Flu",
                Description = "Patient has symptoms of flu.",
                Treatment = "Rest and stay hydrated",
                TestResults = "Negative"
            };

            context.MedicalCards.Add(medicalCard);
            context.SaveChanges();
        }

        // Act
        using (var context = new MedicalCardContext(options))
        {
            var savedMedicalCard = context.MedicalCards.FirstOrDefault(mc => mc.Diseases == "Flu");
            Assert.NotNull(savedMedicalCard);

            context.MedicalCards.Remove(savedMedicalCard);
            context.SaveChanges();
        }

        // Assert
        using (var context = new MedicalCardContext(options))
        {
            Assert.Equal(0, context.MedicalCards.Count());
        }
    }

}
