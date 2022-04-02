using backend.Enums;

namespace backend.DTO
{
    public class AssetDTO
    {
        public int AssetId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName{get;set;}
        // public int? AssignmentId { get; set; }
        public string AssetName { get; set; }
        public string AssetState { get; set; }
        public string? AssetCode{get;set;}

    }
}