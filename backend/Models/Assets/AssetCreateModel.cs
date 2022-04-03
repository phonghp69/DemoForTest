using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Assets
{
    public class AssetCreateModel
    {
        public string? AssetName {get;set;}
        public int CategoryId {get;set;}
        public string Specification {get;set;}
        public string Location {get;set;}
        public DateTime InstalledDate {get;set;}
        public string AssetState {get;set;}
    }
}