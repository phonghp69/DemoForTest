using backend.Entities;
using backend.Enums;

namespace backend.Data
{
    public static class SeedingData
    {
        public static IEnumerable<Category> SeedingCategories
        {
            get
            {
                IEnumerable<Category> result = new List<Category>() {
                    new Category() {
                        CategoryId = 1,
                        CategoryName = "Laptop",
                        Perfix = "LA"
                    },
                    new Category() {
                        CategoryId = 2,
                        CategoryName = "Monitor",
                        Perfix = "MO"
                    },
                    new Category() {
                        CategoryId = 3,
                        CategoryName = "Personal Computer",
                        Perfix = "PC"
                    },
                };
                return result;
            }
        }
        public static IEnumerable<Asset> SeedingAssets
        {
            get
            {
                IEnumerable<Asset> result = new List<Asset>() {
                    new Asset() {
                        AssetId = 1,
                        CategoryId = 1,
                        CategoryName = "Laptop",
                        AssetName = "HP Zenbook8",
                        AssetCode = "LA1",
                        Specification ="this is sample data",
                        InstalledDate = DateTime.Now,
                        AssetState = AssetState.Available
                    },
                    new Asset() {
                        AssetId = 2,
                        CategoryId = 2,
                        CategoryName = "Monitor",
                        AssetName = "Dell UltralSharp",
                        AssetCode = "MO1",
                        Specification ="this is sample data",
                        InstalledDate = DateTime.Now,
                        AssetState = AssetState.Available
                    },
                    new Asset() {
                        AssetId =3,
                        CategoryId = 3,
                        CategoryName = "Personal Computer",
                        AssetName = "HP PC",
                        AssetCode = "PC1",
                        Specification="this is sample data",
                        InstalledDate = DateTime.Now,
                        AssetState = AssetState.Available
                    },
                };
                return result;
            }
        }
        public static IEnumerable<User> SeedingUsers
        {
            get
            {
                IEnumerable<User> result = new List<User>() {
                    new User() {
                        UserId = 1,
                        UserName = "Admin",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Admin"),
                        FirstName="Dao",
                        LastName="Quy Vuong",
                        Gender = Gender.Male,
                        Location = "Ha Noi",
                        IsFirstLogin = true,
                        StaffCode = "AD1",
                        Role = Role.Admin,
                        JoindedDate = DateTime.Now,
                        DateOfBirth = new DateTime(2000,2,23)
                    },
                    new User() {
                        UserId =2,
                        UserName = "Staff",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Staff"),
                        FirstName="Bui",
                        LastName="Chi Huong",
                        Gender = Gender.Male,
                        Location = "Bac Giang",
                        IsFirstLogin = true,
                        StaffCode = "US2",
                        Role = Role.User,
                        JoindedDate = DateTime.Now,
                        DateOfBirth = new DateTime(1999,3,26)
                    },
                    new User() {
                        UserId =3,
                        UserName = "Huong",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Huong"),
                        FirstName="Bui",
                        LastName="Chi Huong",
                        Gender = Gender.Other,
                        Location = "Cao Bang",
                        IsFirstLogin = true,
                        StaffCode = "........",
                        Role = Role.User,
                        JoindedDate = DateTime.Now,
                        DateOfBirth = new DateTime(2001,3,26)
                    },
                };
                return result;
            }
        }
        public static IEnumerable<Assignment> SeedingAssignments
        {
            get
            {
                IEnumerable<Assignment> result = new List<Assignment>() {
                    new Assignment() {
                        AssignmentId = 1,
                        AssignedToUserId = 2,
                        AssignedByUserId = 1,
                        AssetId = 2,
                        AssignedDate = DateTime.Now,
                        Note = "this is sample data",
                    },
                };
                return result;
            }
        }
        public static IEnumerable<ReturningRequest> SeedingReturningRequest
        {
            get
            {
                IEnumerable<ReturningRequest> result = new List<ReturningRequest>() {
                    new ReturningRequest() {
                        RequestId = 1,
                        RequestedByUserId = 2,
                        ProcessedByUserId = 1,
                        AssignmentId = 1,
                        RequestState = RequestState.WaitingForReturning,
                    },
                };
                return result;
            }
        }
    }
}