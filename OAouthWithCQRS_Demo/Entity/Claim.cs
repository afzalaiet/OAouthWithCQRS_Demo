using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.Entity
{
    public class Claim : BaseEntity
    {
        public int UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}