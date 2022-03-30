using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTO
{
    public class AssignmentDTO
    {
        public int AssignmentId { get; set; }
        public int AssignedToUserId { get; set; }
        public int AssignedByUserID { get; set; }
        public int AssetId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Note { get; set; }
        public int RequestId { get; set; }
    }
}