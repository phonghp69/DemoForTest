using backend.DTO;
using backend.Entities;

namespace backend.Utilities
{
    public static class Utility
    {
        public static CategoryDTO CategoryEntityToDTO(this Category entity)
        {
            return new CategoryDTO()
            {
                Name = entity.Name,
                Perfix = entity.Perfix,
            };
        }
        public static Category CategoryDTOToEntity(this CategoryDTO category)
        {
            return new Category()
            {
                Name = category.Name,
                Perfix = category.Perfix,
            };
        }        
        public static AssetDTO AssetEntityToDTO(this Asset entity)
        {
            return new AssetDTO()
            {
                Name = entity.Name,
                AssetStatus = entity.AssetStatus,
                AssetState = entity.AssetState,
            };
        }
        public static Asset AssetDTOToEntity(this AssetDTO asset)
        {
            return new Asset()
            {
                Name = asset.Name,
                AssetStatus = asset.AssetStatus,
                AssetState = asset.AssetState,
            };
        }
        public static UserDTO UserEntityToDTO(this User entity)
        {
            UserDTO result = new UserDTO
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                PasswordHash = entity.PasswordHash,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Role = entity.Role,
                JoindedDate = entity.JoindedDate,
            };
            return result;
        }

        public static User AssetDTOToEntity(this UserDTO user)
        {
            User result = new User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                JoindedDate = user.JoindedDate,
            };
            return result;
        }

    }
}