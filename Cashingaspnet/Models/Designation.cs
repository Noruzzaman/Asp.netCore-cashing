using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Cashingaspnet.Models;
using Microsoft.Extensions.Hosting;

namespace Cashingaspnet.Models
{
    public class Designation
    {

        public Designation()
        {
            Employee = new HashSet<Employee>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(250)]
        public string Designations { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
