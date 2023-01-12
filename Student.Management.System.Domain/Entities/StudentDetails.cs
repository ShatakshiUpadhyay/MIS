using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Management.System.Domain.Entities
{
    public class StudentDetails
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } ="";
        public string LastName { get; set; } ="";
        public DateTime DateOfBirth { get; set; }  

        public virtual Subject Subject { get; set; }   
 

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }




    }
}