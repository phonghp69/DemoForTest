using backend.Data;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using backend.Entities;

namespace backend.Services
{
    public class AssignmentService : IAssignmentService
    {
        private MyDbContext _context;

        public AssignmentService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Assignment>> GetAllAssignment()
        {
            return await _context.Assignment.ToListAsync();
        }
    }
}