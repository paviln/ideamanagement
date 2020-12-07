using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public ApplicationUser accountHolder { get; set; }
    }
}
