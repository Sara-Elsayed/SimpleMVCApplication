using SimpleAuthProject.Models.Entities;
using SimpleAuthProject.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimpleAuthProject.Models.Entities
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(15,100)]
        public int Age { get; set; }
        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("Department")]
        public int Fk_DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}