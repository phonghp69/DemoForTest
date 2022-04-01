using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IReturningRequestService
    {
        public Task<ActionResult<List<ReturningRequestDTO>>> GetAllReturningRequests();
        public Task<ActionResult<ReturningRequestDTO>> GetReturningRequest(int id);

        public Task<IActionResult> AddReturningRequest(ReturningRequestDTO returningRequest);

        public Task<IActionResult> UpdateReturningRequest(int id, ReturningRequestDTO returningRequest);

        public Task<IActionResult> DeleteReturningRequest(int id);
    }
}