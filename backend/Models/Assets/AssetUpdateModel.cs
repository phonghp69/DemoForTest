using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Assets
{
    public class AssetUpdateModel
    {
        public string? AssetName {get;set;}
        public int CategoryId {get;set;}
        public string Specification {get;set;}
        public string AssetState {get;set;}
    }
}