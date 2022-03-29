using backend.Entities;

namespace backend.Interfaces
{
    public interface IAssignmentService
    {
        public Task<List<Assignment>> GetAllAssignment();
    }
}