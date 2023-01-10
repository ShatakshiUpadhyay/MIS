using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Management.System.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } ="";
        public string LastName { get; set; } ="";
        public DateTime DateOfBirth { get; set; }   
        public Subject FavouriteSubject { get; set; }   
    }
}