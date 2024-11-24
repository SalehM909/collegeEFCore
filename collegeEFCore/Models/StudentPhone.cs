using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegeEFCore.Models
{
    public class StudentPhone
    {
        [Key]
        public int StId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }


        public virtual Student Student { get; set; }
    }
}
