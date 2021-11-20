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
        [Required(ErrorMessage = "Please enter date")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Please enter code")]
        public string code { get; set; }
        [Required(ErrorMessage = "subcode bad",AllowEmptyStrings = true)]
        public string subcode { get; set; } = "";
        [Required(ErrorMessage = "Please enter time")]
        public int time { get; set; }
        [Required(ErrorMessage = "Please enter description", AllowEmptyStrings = true)]
        public string description { get; set; }
    }
}