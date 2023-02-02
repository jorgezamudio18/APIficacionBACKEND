using CrudPerson.Models;
using CrudPerson.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ModelBaseController : ControllerBase {
        public ModelBaseController(APIficacionContext dbContext) {
            this.dbContext = dbContext;
        }

        protected APIficacionContext dbContext { get; set; }

        protected ObjectResult BuildResponseObjectResult(MSGenericResponse res, int code = 0) {
            return StatusCode(code != 0 ? code : res.CheckStatus(), res);
        }
    }
}
