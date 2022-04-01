using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTO
{
    public class AssetInforDTO
    {
        public int AssetId { get; set; }
        public string CategoryName { get; set; }
        public string AssetCode {get;set;}
        public string AssetName { get; set; }
        public string AssetState { get; set;}
    }
}