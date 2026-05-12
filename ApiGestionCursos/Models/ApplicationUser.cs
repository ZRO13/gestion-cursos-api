using System;
using Microsoft.AspNetCore.Identity;

namespace ApiGestionCursos.Models
{

    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }

}
