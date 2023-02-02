using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPerson.Models {
    public class MSGenericResponse {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; } = null;
        public void SetErrorInfo(System.Exception ex) {
            Status = "Fatal";
            Message = ex.ToString();
            Data = null;
        }

        public void SetErrorInfo(string ex) {
            Status = "Fatal";
            Message = ex;
            Data = null;
        }

        public int CheckStatus(int warningCode = StatusCodes.Status200OK) {
            switch (Status) {
                case "Success": return StatusCodes.Status200OK;
                case "Error": return StatusCodes.Status200OK;
                case "Warning": return warningCode;
                case "Fatal": return StatusCodes.Status500InternalServerError;
                default: return StatusCodes.Status501NotImplemented;
            }
        }
    }
}
