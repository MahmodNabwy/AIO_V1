﻿using AIO.Contracts.Enums;
using AIO.Core.Entities;
using AIO.Core.Entities.AppSettings;
using AIO.Core.Entities.Auth;
using AIO.Core.Entities.Auth.Roles;
using AIO.Core.Entities.Languages;
using AIO.Shared.Consts;
using Microsoft.EntityFrameworkCore;

namespace AIO.Infrastructure.Helpers
{
    internal class SeedData
    {
        internal SeedData(ModelBuilder modelBuilder)
        {
            SeedInitialData(modelBuilder);
        }
        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            #region Seeding IdentityRole table 
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = "b17cc416-89b4-455d-a58a-4b4e8503e995",
                    Name = Roles.SuperAdmin,
                    NormalizedName = Roles.SuperAdmin.ToUpper(),
                    ConcurrencyStamp = "6acc130c-f695-4134-9e9c-19ba25872d52",
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    IsDeleted = false,
                    IsSystem = true
                },
                new Role
                {
                    Id = "67df368b-c097-4020-b6b9-f2c03aaae7a8",
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper(),
                    ConcurrencyStamp = "1d548e79-f43f-4452-af54-88327d81a3a4",
                    CreatedAt = DateTime.Parse("2023-09-27 00:53:30"),
                    UpdatedAt = DateTime.Parse("2023-09-27 00:53:30"),
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    IsDeleted = false,
                    IsSystem = true
                },
                new Role
                {
                    Id = "fd44e5d3-57ed-4276-98b6-844f06045062",
                    Name = Roles.ContentCreator,
                    NormalizedName = Roles.ContentCreator.ToUpper(),
                    ConcurrencyStamp = "d0926134-d4c9-4ce4-9802-3f1c6605a33b",
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    IsDeleted = false,
                    IsSystem = true
                },
                new Role
                {
                    Id = "61580090-2de4-4f3a-8d93-34e32fc48ecb",
                    Name = Roles.Editor,
                    NormalizedName = Roles.Editor.ToUpper(),
                    ConcurrencyStamp = "d65c8300-f921-4eb4-9241-98ddc63c50f5",
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    IsDeleted = false,
                    IsSystem = true
                }
                );
            #endregion

            #region Seeding the User to AspNetUsers table

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UserName = "Admin",
                    Gender = Gender.Male,
                    Path = null,
                    IsBanned = false,
                    PasswordHash = "AQAAAAEAACcQAAAAECi3lT6l+1HKEawLjldUyT9Azn1jpzQZeMkapDbycmjUT++jy2voAG5zGBg4Spj+iA==", // = "q?$A!P_D5eT&D2BB"
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "amalassem21@gmail.com",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    //ProfilePictureId = null,
                    NormalizedUserName = "admin".ToUpper(),
                    NormalizedEmail = "amalassem21@gmail.com".ToUpper(),
                    ConcurrencyStamp = "e3b9c8c2-31c8-4899-99c4-6ebc51e2542b",
                    SecurityStamp = "SLKWB2MKZHIHR3TK4VHZYLZSAMIKAUCF",
                    EmailConfirmed = true,
                    PhoneNumber = "01145907543"

                }
            );

            #endregion

            #region Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserId = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    RoleId = "fd44e5d3-57ed-4276-98b6-844f06045062",
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8"
                },
                new UserRole
                {
                    UserId = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995",
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8"
                },

                new UserRole
                {
                    UserId = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    RoleId = "61580090-2de4-4f3a-8d93-34e32fc48ecb",
                    CreatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"),
                    CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8",
                    UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8"
                }
            );

            #endregion

            #region Seeding Defualt Languages
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, IsSystem = true, Name = "العربية", IsDefault = true, Flag = "eg", Locale = "ar", Direction = "rtl", CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false },
                new Language { Id = 2, IsSystem = true, Name = "الإنجليزية", IsDefault = false, Flag = "us", Locale = "en", Direction = "ltr", CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false }
            );
            #endregion

            #region Seeding Defualt Language Translation
            modelBuilder.Entity<LanguageTranslation>().HasData(
                new LanguageTranslation { Id = 1, Name = "Arabic", Locale = "en", LanguageId = 1, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30") },
                new LanguageTranslation { Id = 2, Name = "English", Locale = "en", LanguageId = 2, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30") }
            );
            #endregion

            #region PermissionModule
            modelBuilder.Entity<PermissionModule>().HasData(

                new PermissionModule { IsSystem = true, Id = (int)Modules.Departments, Name = Module.Departments, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
                new PermissionModule { IsSystem = true, Id = (int)Modules.Users, Name = Module.Users, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
                new PermissionModule { IsSystem = true, Id = (int)Modules.Roles, Name = Module.Roles, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
                new PermissionModule { IsSystem = true, Id = (int)Modules.Permissions, Name = Module.Permissions, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
                new PermissionModule { IsSystem = true, Id = (int)Modules.Settings, Name = Module.Settings, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
                new PermissionModule { IsSystem = true, Id = (int)Modules.Languages, Name = Module.Languages, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
                new PermissionModule { IsSystem = true, Id = (int)Modules.DepartmentUsers, Name = Module.DepartmentUsers, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20  00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
                new PermissionModule { IsSystem = true, Id = (int)Modules.Dashboard, Name = Module.Dashboard, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20  00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" }

            );
            #endregion

            #region Role Permissions
            modelBuilder.Entity<RolePermission>().HasData(
               new RolePermission { Id = 1, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Departments, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 2, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Departments, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 3, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Departments, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 4, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Departments, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 5, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Departments, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },

               new RolePermission { Id = 6, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Users, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 7, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Users, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 8, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Users, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 9, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Users, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 10, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Users, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },

               new RolePermission { Id = 11, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Roles, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 12, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Roles, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 13, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Roles, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 14, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Roles, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 15, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Roles, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },

               new RolePermission { Id = 16, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Permissions, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 17, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Permissions, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 18, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Permissions, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 19, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Permissions, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 20, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Permissions, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },

               new RolePermission { Id = 21, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Settings, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 22, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Settings, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 23, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Settings, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 24, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Settings, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 25, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Settings, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },

               new RolePermission { Id = 26, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Languages, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 27, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Languages, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 28, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Languages, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 29, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Languages, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 30, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Languages, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2021-11-15 00:53:30"), UpdatedAt = DateTime.Parse("2021-11-15 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },

               new RolePermission { Id = 31, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.DepartmentUsers, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 32, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.DepartmentUsers, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 33, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.DepartmentUsers, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 34, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.DepartmentUsers, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 35, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.DepartmentUsers, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },

               new RolePermission { Id = 36, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Dashboard, OperationId = (int)Operations.Show, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 37, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Dashboard, OperationId = (int)Operations.Add, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 38, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Dashboard, OperationId = (int)Operations.Edit, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 39, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Dashboard, OperationId = (int)Operations.SoftDelete, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" },
               new RolePermission { Id = 40, RoleId = "b17cc416-89b4-455d-a58a-4b4e8503e995", ModuleId = (int)Modules.Dashboard, OperationId = (int)Operations.Delete, CreatedAt = DateTime.Parse("2023-02-20 00:53:30"), UpdatedAt = DateTime.Parse("2023-02-20 00:53:30"), IsDeleted = false, CreatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8", UpdatedBy = "c1be5862-d402-4a31-b292-6aded859f7a8" }

               );

            #endregion

            #region AppSettings SeedData
            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting
                {
                    Id = 1,
                    Key = "email_configuration",
                    IsSystem = true,
                    Value =
                        "{\"From\":\"digitalhub_dev@outlook.com\",\"SmtpServer\":\"smtp-mail.outlook.com\",\"Port\":\"587\",\"UserName\":\"digitalhub_dev@outlook.com\",\"Password\":\"DigitalDevTeam@123\"}"
                },


                new AppSetting
                {
                    Id = 2,
                    Key = "complete_migration_email",
                    IsSystem = true,
                    Value = " تم رفع الملف ( {0} )بنجاح  "
                },

                new AppSetting
                {
                    Id = 3,
                    Key = "uncomplete_migration_email",
                    IsSystem = true,
                    Value = " لم يتم رفع الملف  ( {0} ) لوجود اخطاء بالشيت ({1}) بالصف {2} والعمود {3}؛فلابد من مراجعة النشرة ثم قم بإعادة الرفع مره اخرى "
                }

            );

            #endregion
        }
    }
}
