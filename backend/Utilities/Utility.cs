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
                CategoryId = entity.CategoryId,
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
                CategoryId = asset.CategoryId,
                Name = asset.Name,
                AssetStatus = asset.AssetStatus,
                AssetState = asset.AssetState,
            };
        }

        public static AssignmentDTO AssignmentEntityToDTO(this Assignment entity)
        {
            AssignmentDTO result = new AssignmentDTO
            {
                AssignmentId = entity.AssignmentId,
                AssignedToUserId = entity.AssignedToUserId,
                AssignedByUserID = entity.AssignedByUserId,
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
                AssignedToUserId = assignment.AssignedToUserId,
                AssignedByUserId = assignment.AssignedByUserID,
                AssetId = assignment.AssetId,
                AssignedDate = assignment.AssignedDate,
                Note = assignment.Note,
                RequestId = assignment.RequestId
            };
            return result;
        }

        public static UserDTO UserEntityToDTO(this User entity)
        {
            UserDTO result = new UserDTO
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                PasswordHash = entity.PasswordHash,
                Role = entity.Role,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                JoindedDate = entity.JoindedDate
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
                Role = user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JoindedDate = user.JoindedDate
            };
            return result;
        }
    }
}