using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWebApi.Model.Teachers.Entities
{
    
    public class Address
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
    }
}
