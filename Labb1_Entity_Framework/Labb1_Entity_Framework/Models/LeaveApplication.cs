using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labb1_Entity_Framework.Models
{
    class LeaveApplication
    {
        [Key]
        public int LeaveId { get; set; }
        [Required]
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CurrentDate { get; set; }

        [ForeignKey("Employee")]
        public int ForeignEmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
