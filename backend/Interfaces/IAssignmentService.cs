using backend.DTO;

namespace backend.Interfaces
{
    public interface IAssignmentService
    {
        public Task<List<AssignmentDTO>> GetAllAssignment();
        public Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId);
    }
}