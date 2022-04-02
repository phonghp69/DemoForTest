using backend.Data;
using backend.DTO;
using backend.Entities;
using backend.Enums;

namespace backend.Utilities
{
    public static class Utility
    {
        public static CategoryDTO CategoryEntityToDTO(this Category entity)
        {
            return new CategoryDTO()
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Perfix = entity.Perfix,
            };
        }
        public static Category CategoryDTOToEntity(this CategoryDTO category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Perfix = category.Perfix,
            };
        }
        public static AssetDTO AssetEntityToDTO(this Asset entity)
        {
            return new AssetDTO()
            {
                CategoryId = entity.CategoryId,
                AssetName = entity.AssetName,
                CategoryName = entity.CategoryName,
                AssetCode = entity.AssetCode,
                AssetState = entity.AssetState.ToString(),
            };
        }
        public static Asset AssetDTOToEntity(this AssetDTO asset)
        {
            AssetState enumParseResult;
            Asset result = new Asset
            {
                CategoryId = asset.CategoryId,
                // AssignmentId = asset.AssignmentId,
                AssetName = asset.AssetName,
                AssetCode = asset.AssetCode,
                // AssetStatus = asset.AssetStatus,
                AssetState = Enum.TryParse(asset.AssetState, out enumParseResult)
                    ? enumParseResult
                    : AssetState.WaitingForRecycle,
            };
            return result;
        }

        public static AssignmentDTO AssignmentEntityToDTO(this Assignment entity)
        {
            AssignmentDTO result = new AssignmentDTO
            {
                // AssignmentId = entity.AssignmentId,
                AssignedToUserId = entity.AssignedToUserId,
                AssignedByUserID = entity.AssignedByUserId,
                AssetId = entity.AssetId,
                AssignedDate = entity.AssignedDate,
                Note = entity.Note
            };
            return result;
        }

        public static Assignment AssignmentDTOToEntity(this AssignmentDTO assignment)
        {
            Assignment result = new Assignment
            {
                // AssignmentId = assignment.AssignmentId,
                AssignedToUserId = assignment.AssignedToUserId,
                AssignedByUserId = assignment.AssignedByUserID,
                AssetId = assignment.AssetId,
                AssignedDate = assignment.AssignedDate,
                Note = assignment.Note
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
                Role = entity.Role.ToString(),
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                JoindedDate = entity.JoindedDate,
                Gender = entity.Gender.ToString(),
                Location = entity.Location,
                IsFirstLogin = entity.IsFirstLogin,
                DateOfBirth = entity.DateOfBirth.ToString(),
                StaffCode = entity.StaffCode
            };
            return result;
        }
        public static User UserDTOToEntity(this UserDTO user)
        {
            Role enumParseResult;
            Gender enumParseResult1;
            DateTime dateTimeParseResult;
            User result = new User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JoindedDate = user.JoindedDate,
                Location = user.Location,
                IsFirstLogin = user.IsFirstLogin,
                StaffCode = user.StaffCode,
                // DateOfBirth = user.DateOfBirth,
                Role = Enum.TryParse(user.Role, out enumParseResult)
                    ? enumParseResult
                    : Role.User,
                Gender = Enum.TryParse(user.Gender, out enumParseResult1)
                    ? enumParseResult1
                    : Gender.Other,
                DateOfBirth = DateTime.TryParse(user.DateOfBirth, out dateTimeParseResult)
                    ? dateTimeParseResult
                    : DateTime.Now,
            };
            return result;
        }
        public static ReturningRequestDTO ReturningRequestEntityToDTO(this ReturningRequest entity)
        {
            return new ReturningRequestDTO()
            {
                RequestedByUserId = entity.RequestedByUserId,
                ProcessedByUserId = entity.ProcessedByUserId,
                AssignmentId = entity.AssignmentId,
                RequestState = entity.RequestState.ToString()
            };
        }
        public static ReturningRequest ReturningRequestDTOToEntity(this ReturningRequestDTO returningRequest)
        {
            RequestState enumParseResult;
            ReturningRequest result = new ReturningRequest
            {
                RequestedByUserId = returningRequest.RequestedByUserId,
                ProcessedByUserId = returningRequest.ProcessedByUserId,
                AssignmentId = returningRequest.AssignmentId,
                RequestState = Enum.TryParse(returningRequest.RequestState, out enumParseResult)
                    ? enumParseResult
                    : RequestState.WaitingForReturning,
            };
            return result;
        }
        // public static User UserDTOToEntity(this UserDTO user)
        // {
        //     User result = new User
        //     {
        //         UserId = user.UserId,
        //         UserName = user.UserName,
        //         PasswordHash = user.PasswordHash,
        //         Role = user.Role,
        //         FirstName = user.FirstName,
        //         LastName = user.LastName,
        //         JoindedDate = user.JoindedDate
        //     };
        //     return result;
        // }
    }
}