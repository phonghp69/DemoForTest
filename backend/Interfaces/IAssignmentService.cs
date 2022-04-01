using backend.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IAssignmentService
    {
        public Task<ActionResult> AddAssignment(AssignmentDTO assignment);
        public Task<ActionResult> UpdateAssignment(AssignmentDTO assignment, int id);
        public Task<ActionResult> DeleteAssignment(int id);
        public Task<List<AssignmentDTO>> GetAllAssignment();
        public Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId);
    }
}