using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRS.Models
{
    public class ActivityEntry
    {
        //[JsonIgnore]
        //public int id;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public string code { get; set; }
        public string subcode { get; set; }
        public int time { get; set; }
        public string description { get; set; }
    }
}