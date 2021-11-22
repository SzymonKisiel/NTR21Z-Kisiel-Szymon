using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRS.Models
{
    public class ManagerDetailsViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; } = DateTime.Now;
        public string username { get; set; } = "";
        public int accepted { get; set; } = 0;
    }
}
