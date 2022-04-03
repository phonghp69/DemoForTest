using backend.Data;
using backend.DTO;
using backend.Interfaces;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ReturningRequestService : IReturningRequestService
    {
        private MyDbContext _context;
        public ReturningRequestService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AddReturningRequest(ReturningRequestDTO returningRequest)
        {
            if (_context.ReturningRequests != null)
            {
                try
                {
                    await _context.ReturningRequests.AddAsync(returningRequest.ReturningRequestDTOToEntity());
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

        public async Task<IActionResult> DeleteReturningRequest(int id)
        {
            if (_context.ReturningRequests != null)
            {
                try
                {
                    var foundReturningRequest = await _context.ReturningRequests.FindAsync(id);
                    if (foundReturningRequest != null)
                    {
                        _context.ReturningRequests.Remove(foundReturningRequest);
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

        public async Task<ActionResult<List<ReturningRequestDTO>>> GetAllReturningRequests()
        {
            if (_context.ReturningRequests != null)
            {
                try
                {
                    var returningRequest = await _context.ReturningRequests.Select(returningRequest => returningRequest.ReturningRequestEntityToDTO()).ToListAsync();
                    return new OkObjectResult(returningRequest);
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<ReturningRequestDTO>> GetReturningRequest(int id)
        {
            if (_context.ReturningRequests != null)
            {
                try
                {
                    var foundReturningRequest = await _context.ReturningRequests.FindAsync(id);
                    if (foundReturningRequest != null)
                        return new OkObjectResult(foundReturningRequest.ReturningRequestEntityToDTO());
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }

        public async Task<IActionResult> UpdateReturningRequest(int id, ReturningRequestDTO returningRequest)
        {
            if (_context.ReturningRequests != null)
            {
                try
                {
                    var foundReturningRequest = await _context.ReturningRequests.FindAsync(id);
                    if (foundReturningRequest != null)
                    {
                        foundReturningRequest = returningRequest.ReturningRequestDTOToEntity();
                        _context.ReturningRequests.Update(foundReturningRequest);
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
    }
}