using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedBoxCar.Web.Models
{
    public class Users : IdentityUser
    {
        public bool isAdmin { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
