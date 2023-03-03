using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Contacts.WebApi.Models
{
    public class Contact
    {        
        public int ContactId { get; set; }     
        public string? Name { get; set; }        
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
