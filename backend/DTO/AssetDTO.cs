
using Back_end.Enums;

namespace Back_end.DB.DTO
{
    public class AssetDTO
    {
        public int AssetId{get;set;}
        public int CategoryId{get;set;}
        public int AssignmentId{get;set;}
        public string Name{get;set;}
        public string AssetStatus{get;set;}
        public AssetState AssetState{get;set;}

    }
}