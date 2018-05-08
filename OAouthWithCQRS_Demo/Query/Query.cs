using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeremonyBazar.Query
{
    public static class Query
    {
        public const string Get = "Select * from {0} where Id = {1};";
        public const string GetAll = "Select * from {0};";
        public const string GetAllActive = "Select * from {0} where IsActive = 1";
        public const string GetAllDeactive = "Select * from {0} where IsActive = 0";       

    }
}