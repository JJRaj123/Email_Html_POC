using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Html_POC.Models
{
    public class Student
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public List<Persons> Persons { get; set; }
    }
    public class Persons
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
