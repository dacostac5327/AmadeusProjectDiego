using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public int Department { get; set; }
        public DateTime DateBirth { get; set; }
        public sex Sex { get; set; }
        public int Arl { get; set; }
        public int Eps { get; set; }
        public bool State { get; set; }
        public virtual Department? DepartmentNavigation { get; set; }
        public virtual ARL? ArlNavigation { get; set; }
        public virtual EPS? EpsNavigation { get; set; }
    }

    public enum sex {
        Male = 1,
        Female = 2,
        Other = 3
    }
}
