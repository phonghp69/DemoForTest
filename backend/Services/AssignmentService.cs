using backend.Data;
using backend.DTO;
using backend.Interfaces;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AssignmentService : IAssignmentService
    {
        private MyDbContext _context;
        public AssignmentService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> AddAssignment(AssignmentDTO assignment)
        {
            if (_context.Assignments != null)
            {
                try
                {
                    await _context.Assignments.AddAsync(assignment.AssignmentDTOToEntity());
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
        }
        public async Task<ActionResult> UpdateAssignment(AssignmentDTO assignment, int id)
        {
            if (_context.Assignments != null)
            {
                try
                {
                    var foundAssignment = await _context.Assignments.FindAsync(id);
                    if (foundAssignment != null)
                    {
                        foundAssignment = assignment.AssignmentDTOToEntity();
                        _context.Assignments.Update(foundAssignment);
                        await _context.SaveChangesAsync();
                        return new OkResult();
                    }
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
        }
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            if (_context.Assignments != null)
            {
                try
                {
                    var foundAssignment = await _context.Assignments.FindAsync(id);
                    if (foundAssignment != null)
                    {
                        _context.Assignments.Remove(foundAssignment);
                        await _context.SaveChangesAsync();
                        return new OkResult();
                    }
                    else
                    {
                        return new NotFoundResult();
                    }
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
        }
        public async Task<List<AssignmentDTO>> GetAllAssignment()
        {
            return await _context.Assignments.Select(x => x.AssignmentEntityToDTO()).ToListAsync();
        }

        public async Task<List<AssignmentDTO>> GetAssignmentByUserId(int userId)
        {
            var foundUser = _context.Users.Include(x => x.AssignedTo).FirstOrDefault(x => x.UserId == userId);
            if (foundUser != null)
            {
                return foundUser.AssignedTo.Select(x => x.AssignmentEntityToDTO()).ToList();
            }
            return null;
        }
    }
}