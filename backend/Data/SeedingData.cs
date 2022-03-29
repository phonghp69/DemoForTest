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
                        AssetId = 1,
                        CategoryId = 1,
                        AssignmentId = 1,
                        Name = "mouse keyboard",
                        AssetStatus = ".......",
                        AssetState = AssetState.WaitingForRecycle
                    },
                    new Asset() {
                        AssetId = 2,
                        CategoryId = 2,
                        AssignmentId = 2,
                        Name = "name tags",
                        AssetStatus = ".......",
                        AssetState = AssetState.Availiable
                    },
                    new Asset() {
                        AssetId =3,
                        CategoryId = 3,
                        AssignmentId = 3,
                        Name = "flowers",
                        AssetStatus = ".......",
                        AssetState = AssetState.NotAvailiable
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
        public static IEnumerable<Assignment> SeedingAssignments
        {
            get
            {
                IEnumerable<Assignment> result = new List<Assignment>() {
                    new Assignment() {
                        AssignmentId = 1,
                        UserId = 2,
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