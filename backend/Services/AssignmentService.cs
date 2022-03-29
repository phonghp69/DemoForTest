using backend.Data;
using backend.Entities;
using backend.Utilities;
using backend.Interfaces;

namespace backend.Services
{
    public class AssignmentService : IAssignmentService
    {
        private MyDbContext _context;
        public AssignmentService (MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAllAssignment()
        {
            return _context.Assignment.ToList();
        }
    }
}