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
                        Name = "Technology",
                        Perfix = "......"
                    },
                    new Category() {
                        CategoryId = 2,
                        Name = "Personal items",
                        Perfix = "......"
                    },
                    new Category() {
                        CategoryId = 3,
                         Name = "Other",
                        Perfix = "......"
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
                        AssetId =1,
                        CategoryId = 1,
                        AssignmentId = 1,
                        Name = "mouse keyboard",
                        AssetStatus = ".......",
                        AssetState = AssetState.WaitingForRecycle
                    },
                    new Asset() {
                        AssetId =2,
                        CategoryId = 2,
                        AssignmentId = 2,
                        Name = "name tags",
                        AssetStatus = ".......",
                        AssetState = AssetState.Avaliable
                    },
                    new Asset() {
                        AssetId =3,
                        CategoryId = 3,
                        AssignmentId = 3,
                        Name = "flowers",
                        AssetStatus = ".......",
                        AssetState = AssetState.NotAvliable
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
                        UserId =1,
                        UserName = "Admin",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Admin"),
                        FirstName="Dao",
                        LastName="Quy Vuong",
                        Role = Role.Admin,
                        JoindedDate = DateTime.Now,
                    },
                    new User() {
                        UserId =2,
                        UserName = "Staff",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Staff"),
                        FirstName="Bui",
                        LastName="Chi Huong",
                        Role = Role.User,
                        JoindedDate = DateTime.Now,
                    },
                };
                return result;
            }
        }

        public static IEnumerable<Assignment> SeddingAssignment {
            get
            {
                IEnumerable<Assignment> result = new List<Assignment>
                {
                    new Assignment() {
                        AssignmentId = 1,
                        UserId = 1,
                        AssetId = 1,
                        AssignedDate = DateTime.Now,
                        Note = "this is sample data"
                    },
                    new Assignment() {
                        AssignmentId = 2,
                        UserId = 2,
                        AssetId = 2,
                        AssignedDate = DateTime.Now,
                        Note = "this is sample data2"
                    },
                        new Assignment() {
                        AssignmentId = 3,
                        UserId = 1,
                        AssetId = 3,
                        AssignedDate = DateTime.Now,
                        Note = "this is sample data3"
                    },
                };
                return result;
            }
        }
    }
}