using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegeEFCore.Models
{
    public class FacultyMobile
    {
        [Key]
        public int FacultyMobileId { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }

        public string MobileNumber { get; set; }


        public virtual Faculty Faculty { get; set; }
    }
}
