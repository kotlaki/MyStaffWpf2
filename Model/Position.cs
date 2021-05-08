using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStaffWpf2.Model
{
    [Index("DepartmentId", IsUnique = false)]
    public class Position
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Staff> Staffs { get; set; }

        [Required]
        [StringLength(30)]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public Department DepartmentById
        {
            get
            {
                return DataWorker.findDepartmentById(DepartmentId);
            }
        }

    }
}
