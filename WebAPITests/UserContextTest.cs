using Microsoft.EntityFrameworkCore;
using Project.WebAPI.Models;
using Project.WebAPI.Models.Contexts;
using System;
using System.Linq;
using Xunit;

public class UserContextTest
{
    [Fact]
    public void CanAddUserToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(databaseName: "CanAddUserToDatabase")
            .Options;

        // Act
        using (var context = new UserContext(options))
        {
            var user = new User
            {
                UserId = 1,
                UserName = "TestUser",
                DateOfBirth = DateTime.Now,
                MedicalCardId = 1
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        // Assert
        using (var context = new UserContext(options))
        {
            Assert.Equal(1, context.Users.Count());
            var savedUser = context.Users.First();
            Assert.Equal("TestUser", savedUser.UserName);
        }
    }

    [Fact]
    public void CanRetrieveUserFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(databaseName: "CanRetrieveUserFromDatabase")
            .Options;

        using (var context = new UserContext(options))
        {
            var user = new User
            {
                UserId = 1,
                UserName = "TestUser",
                DateOfBirth = DateTime.Now,
                MedicalCardId = 1
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        // Act
        using (var context = new UserContext(options))
        {
            var savedUser = context.Users.FirstOrDefault(u => u.UserName == "TestUser");

            // Assert
            Assert.NotNull(savedUser);
            Assert.Equal("TestUser", savedUser.UserName);
        }
    }

    [Fact]
    public void CanUpdateUserInDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(databaseName: "CanUpdateUserInDatabase")
            .Options;

        using (var context = new UserContext(options))
        {
            var user = new User
            {
                UserId = 1,
                UserName = "TestUser",
                DateOfBirth = DateTime.Now,
                MedicalCardId = 1
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        // Act
        using (var context = new UserContext(options))
        {
            var savedUser = context.Users.FirstOrDefault(u => u.UserName == "TestUser");
            Assert.NotNull(savedUser);

            savedUser.UserName = "UpdatedUser";
            context.SaveChanges();
        }

        // Assert
        using (var context = new UserContext(options))
        {
            var updatedUser = context.Users.FirstOrDefault(u => u.UserName == "UpdatedUser");
            Assert.NotNull(updatedUser);
            Assert.Equal("UpdatedUser", updatedUser.UserName);
        }
    }

    [Fact]
    public void CanDeleteUserFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase(databaseName: "CanDeleteUserFromDatabase")
            .Options;

        using (var context = new UserContext(options))
        {
            var user = new User
            {
                UserId = 1,
                UserName = "TestUser",
                DateOfBirth = DateTime.Now,
                MedicalCardId = 1
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        // Act
        using (var context = new UserContext(options))
        {
            var savedUser = context.Users.FirstOrDefault(u => u.UserName == "TestUser");
            Assert.NotNull(savedUser);

            context.Users.Remove(savedUser);
            context.SaveChanges();
        }

        // Assert
        using (var context = new UserContext(options))
        {
            Assert.Equal(0, context.Users.Count());
        }
    }

}
