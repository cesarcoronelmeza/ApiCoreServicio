using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ROLE
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActiveId { get; set; }
        public string Active { get; set; }

    }

    public class RoleRquest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActiveId { get; set; }
    }
}