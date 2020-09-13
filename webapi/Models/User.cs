using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRoutesResponses.Models
{
    public class User
    {
        public Guid UserId {get;set;} = Guid.NewGuid();

        public string Name {get;set;}

        public string LastName {get;set;}

        public string Phone {get;set;}

        public DateTime DateCreated {get;set;} = DateTime.Now;

        public virtual  ICollection<UserRole> UserRoles {get;set;}

        public bool Active {get;set;}  = true;
    }
}