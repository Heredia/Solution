using Infrastructure.Databases.Database.Entities;
using Model.Enums;
using Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Infrastructure.Databases.Database.Context
{
    internal sealed class DatabaseContextMigration : DbMigrationsConfiguration<DatabaseContext>
    {
        public DatabaseContextMigration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DatabaseContext context)
        {
            AddOrUpdateAdministrator(context);
            AddOrUpdateUsers(context);
            context.SaveChanges();
        }

        private static void AddOrUpdateAdministrator(DbContext context)
        {
            var login = new LoginModel { Login = "admin", Password = "admin" };

            var user = new User
            {
                UserId = 1,
                Name = "Administrator",
                Surname = "Administrator",
                Email = "administrator@administrator.com",
                Login = login.LoginHash,
                Password = login.PasswordHash,
                Status = Status.Active
            };

            context.Set<User>().AddOrUpdate(user);

            var roles = new List<UserRole>
            {
                new UserRole { UserId = user.UserId, Role = Role.Admin },
                new UserRole { UserId = user.UserId, Role = Role.User }
            };

            foreach (var role in roles) { context.Set<UserRole>().AddOrUpdate(role); }
        }

        private static void AddOrUpdateUsers(DbContext context)
        {
            for (var i = 2; i < 500; i++)
            {
                var login = new LoginModel { Login = $"user{i}", Password = $"password{i}" };

                var user = new User
                {
                    UserId = i,
                    Name = $"Name {i}",
                    Surname = $"Surname {i}",
                    Email = $"e-mail{i}@mail.com",
                    Login = login.LoginHash,
                    Password = login.PasswordHash,
                    Status = Status.Active
                };

                context.Set<User>().AddOrUpdate(user);

                var roles = new List<UserRole>
                {
                    new UserRole { UserId = user.UserId, Role = Role.User }
                };

                foreach (var role in roles) { context.Set<UserRole>().AddOrUpdate(role); }
            }
        }
    }
}