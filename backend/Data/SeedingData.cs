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
                        PasswordHash="Admin",
                        FirstName="Dao",
                        LastName="Quy Vuong",
                        Role = Role.Admin,
                        JoindedDate = 2020/02/30,
                    },
                    new User() {
                        UserId =2,
                        UserName = "Staff",
                        PasswordHash="Staff",
                        FirstName="Bui",
                        LastName="Chi Huong",
                        Role = Role.User,
                        JoindedDate = 2020/04/26,
                    },
                };
                return result;
            }  
        }
    }
}