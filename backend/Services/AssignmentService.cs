using backend.Data;
using backend.DTO;
using backend.Interfaces;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AssignmentService : IAssignmentService
    {
        private MyDbContext _context;
        public AssignmentService (MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<AssignmentDTO>> GetAllAssignment()
        {
            return await _context.Assignment.Select(x => x.AssignmentEntityToDTO()).ToListAsync();
        }

        public async Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId)
        {
            var foundUser = _context.Users.Include(x => x.Assignments).FirstOrDefault(x => x.UserId == userId);
            if(foundUser != null)
            {
                return foundUser.Assignments.Select(x => x.AssignmentEntityToDTO()).ToList();
            }
            return null;
        }
    }
}