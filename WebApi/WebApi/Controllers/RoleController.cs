using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class RoleController : ApiController
    {
        // GET api/values/5
        public List<ROLE> Get(RoleRquest rquest)
        { 
            return  RoleDataConection.Listar(rquest);
        }

        // POST api/values
        public bool Post([FromBody] ROLE roleinsert)
        {
            return RoleDataConection.Registrar(roleinsert); 
        }
    }
}
