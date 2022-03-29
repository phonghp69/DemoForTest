using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Role = entity.Role.ToString(),
                JoindedDate = entity.JoindedDate,
            };
            return result;
        }

        public static User AssetDTOToEntity(this UserDTO user)
        {
            UserDTO result = new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToString(),
                JoindedDate = user.JoindedDate,
            };
            return result;
        }

    }
}