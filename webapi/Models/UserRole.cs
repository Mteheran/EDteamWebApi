using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApiRoutesResponses.Models
{
    public class UserRole
    {
        public Guid UserRoleId {get;set;} = Guid.NewGuid();
        public string Role {get;set;}
        public string Description {get;set;}
        public Guid UserId {get;set;}

        [JsonIgnore]
        public bool Active {get;set;}  = true;
        public virtual User User {get;set;}
    }
}