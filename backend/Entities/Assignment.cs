using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Entities;

namespace Back_end.DB.Entities
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentId{get;set;}
        public int UserId{get;set;}
        public int AssetId{get;set;}
        public DateTime AssignedDate{get;set;}
        public string Note{get;set;}
        public User User{get;set;}
        public Asset Asset{get;set;}
        public int RequestId{get;set;}
        public ReturningRequest ReturningRequest{get;set;}
    }
}