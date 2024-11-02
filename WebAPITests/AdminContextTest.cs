using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System.Linq;
using Xunit;

public class AdminContextTest
{
    [Fact]
    public void CanAddAdminToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AdminContext>()
            .UseInMemoryDatabase(databaseName: "CanAddAdminToDatabase")
            .Options;

        using (var context = new AdminContext(options))
        {
            var admin = new Admin
            {
                UserId = 1,
                UserName = "TestAdmin",
                Password = "TestPassword",
                Email = "testadmin@example.com"
            };

            context.Admins.Add(admin);
            context.SaveChanges();
        }

        using (var context = new AdminContext(options))
        {
            Assert.Equal(1, context.Admins.Count());
            var savedAdmin = context.Admins.First();
            Assert.Equal("TestAdmin", savedAdmin.UserName);
        }
    }

    [Fact]
    public void CanRetrieveAdminFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AdminContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrieveAdminFromDatabase")
            .Options;

        using (var context = new AdminContext(options))
        {
            var admin = new Admin
            {
                UserId = 1,
                UserName = "TestAdmin",
                Password = "TestPassword",
                Email = "testadmin@example.com"
            };

            context.Admins.Add(admin);
            context.SaveChanges();
        }

        // Act
        using (var context = new AdminContext(options))
        {
            var savedAdmin = context.Admins.FirstOrDefault(u => u.UserName == "TestAdmin");

            // Assert
            Assert.NotNull(savedAdmin);
            Assert.Equal("TestAdmin", savedAdmin.UserName);
        }
    }

    [Fact]
    public void CanUpdateAdminInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AdminContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdateAdminInDatabase")
            .Options;

        using (var context = new AdminContext(options))
        {
            var admin = new Admin
            {
                UserId = 1,
                UserName = "TestAdmin",
                Password = "TestPassword",
                Email = "testadmin@example.com"
            };

            context.Admins.Add(admin);
            context.SaveChanges();
        }

        // Act
        using (var context = new AdminContext(options))
        {
            var savedAdmin = context.Admins.FirstOrDefault(u => u.UserName == "TestAdmin");
            Assert.NotNull(savedAdmin);

            savedAdmin.UserName = "UpdatedAdmin";
            context.SaveChanges();
        }

        // Assert
        using (var context = new AdminContext(options))
        {
            var updatedAdmin = context.Admins.FirstOrDefault(u => u.UserName == "UpdatedAdmin");
            Assert.NotNull(updatedAdmin);
            Assert.Equal("UpdatedAdmin", updatedAdmin.UserName);
        }
    }

    [Fact]
    public void CanDeleteAdminFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AdminContext>()
            .UseInMemoryDatabase(databaseName: "CanDeleteAdminFromDatabase")
            .Options;

        using (var context = new AdminContext(options))
        {
            var admin = new Admin
            {
                UserId = 1,
                UserName = "TestAdmin",
                Password = "TestPassword",
                Email = "testadmin@example.com"
            };

            context.Admins.Add(admin);
            context.SaveChanges();
        }

        // Act
        using (var context = new AdminContext(options))
        {
            var savedAdmin = context.Admins.FirstOrDefault(u => u.UserName == "TestAdmin");
            Assert.NotNull(savedAdmin);

            context.Admins.Remove(savedAdmin);
            context.SaveChanges();
        }

        // Assert
        using (var context = new AdminContext(options))
        {
            Assert.Equal(0, context.Admins.Count());
        }
    }

}
