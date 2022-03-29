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
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Perfix = entity.Perfix,
            };
        }
        public static Category CategoryDTOToEntity(this CategoryDTO category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Perfix = category.Perfix,
            };
        }
        public static AssetDTO AssetEntityToDTO(this Asset entity)
        {
            return new AssetDTO()
            {
                AssetId = entity.AssetId,
                Name = entity.Name,
                AssetStatus = entity.AssetStatus,
                AssetState = entity.AssetState,
            };
        }
        public static Asset AssetDTOToEntity(this AssetDTO asset)
        {
            return new Asset()
            {
                AssetId = asset.AssetId,
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

        public static User UserDTOToEntity(this UserDTO user)
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

        public static AssignmentDTO AssignmentEntityToDTO(this Assignment entity)
        {
            AssignmentDTO result = new AssignmentDTO
            {
                AssignmentId = entity.AssignmentId,
                UserId = entity.UserId,
                AssetId = entity.AssetId,
                AssignedDate = entity.AssignedDate,
                Note = entity.Note,
                RequestId = entity.RequestId
            };
            return result;
        }

        public static Assignment AssignmentDTOToEntity(this AssignmentDTO assignment)
        {
            Assignment result = new Assignment
            {
                AssignmentId = assignment.AssignmentId,
                UserId = assignment.UserId,
                AssetId = assignment.AssetId,
                AssignedDate = assignment.AssignedDate,
                Note = assignment.Note,
                RequestId = assignment.RequestId
            };
            return result;
        }
    }
}