using CrudPerson.Models;
using CrudPerson.Models.Entities;
using CrudPerson.Models.Entities.Data.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ModelBaseController {

        public PersonController(APIficacionContext dbContext)
      : base(dbContext) {
        }

        [HttpPost, Route("Save")]
        public ObjectResult Save([FromBody] MPerson data) {
            MSGenericResponse response = new MSGenericResponse() {
                Status = "Success",
                Message = "Data was fetched from the database successfully"
            };


            try {
                User p = null;
                if (data.id.HasValue) {
                    p = dbContext.Users.First(w => w.id == data.id);
                    p.name = data.name;
                } else {
                    if (dbContext.Users.Any(w => w.name == data.name)) {
                        response.Status = "Error";
                        response.Message = "There is already a person with this name";
                        return BuildResponseObjectResult(response);
                    }
                    p = new User() {
                        name = data.name,
                        lastname = data.lastname,
                        datetime   = data.datetime,
                        address = data.address,
                        gender = data.gender,
                        age = data.age,
                    };
                    dbContext.Users.Add(p);
                }
                dbContext.SaveChanges();
                data.id = p.id;
                response.Data = data;
            } catch (Exception e) {
                response.SetErrorInfo(e);
            }
            return BuildResponseObjectResult(response);
        }

        [HttpGet, Route("Delete/{ID:int}")]
        public ObjectResult Delete([FromRoute] int ID) {
            MSGenericResponse response = new MSGenericResponse() {
                Status = "Success",
                Message = "Data was deleted from the database successfully"
            };



            try {
                User p = dbContext.Users.Find(ID);
                if (p == null) {
                    response.Status = "Error";
                    response.Message = "Data was not found";
                    return BuildResponseObjectResult(response);
                }
                dbContext.Users.Remove(p);
                dbContext.SaveChanges();
            } catch (Exception e) {
                response.SetErrorInfo(e);
            }
            return BuildResponseObjectResult(response);
        }

        [HttpGet, Route("List")]
        public ObjectResult List() {
            MSGenericResponse response = new MSGenericResponse() {
                Status = "Success",
                Message = "Data was fetched from the database successfully"
            };

            try
            {
                List<MSimpleItemList> list = dbContext.Users
                .Select(s => new MSimpleItemList() {
                    id = s.id,
                    name = s.name
                }).ToList();
                response.Data = list;
            } catch (Exception e) {
                response.SetErrorInfo(e);
            }
            return BuildResponseObjectResult(response);
        }





    }
}
