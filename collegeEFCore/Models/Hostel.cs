using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collegeEFCore.Models
{
    public class Hostel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }
        public int AvailableSeats { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
