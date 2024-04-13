using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.DAL.Entities
{
    public class Employee
    {
        [Key]
        [Ignore]
        public int Id { get; set; }
        [Index(0)]
        public required string Name { get; set; }
        [Index(1)]
        public DateTime DateOfBirth { get; set; }
        [Index(2)]
        public bool Married { get; set; }
        [Index(3)]
        public required string Phone { get; set; }
        [Index(4)]
        public decimal Salary { get; set; }
    }
}
