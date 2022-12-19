using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OccupantsController : ControllerBase
    {
        OccupantsService occupantService = new OccupantsService();

        [HttpGet("GetOccupants")]
        public List<Occupants> GetOccupants()
        {
            return occupantService.GetOccupant();
        }

        [HttpPost("AddOccupant")]
        public Result AddOccupant([FromBody] Occupants newOccupant)
        {

            Occupants user = occupantService.CheckOccupant(newOccupant.TcId);

            bool userCheck = (user != null) ? true : false;

            Result result = new Result();

            if (userCheck == false)
            {

                if (occupantService.AddOccupant(newOccupant) == true)
                {
                    result.HttpStatusCode = Ok().StatusCode;
                    result.Message = "New occupant with " + newOccupant.Id + " id is added.";
                }
                else
                {
                    result.HttpStatusCode = BadRequest().StatusCode;
                    result.Message = "Occupant with " + newOccupant.Id + " id cannot added.";
                }

            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "Occupant with " + user.Id + " id already exists.";
            }

            return result;
        }

        [HttpPut("UpdateOccupant")]
        public Result UpdateOccupant(int id, [FromBody] Occupants updatedOccupant)
        {
            Result result = new Result();

            List<Occupants> userList = occupantService.GetOccupant();

            Occupants? _oldValue = userList.Find(x => x.Id == id);
            if (_oldValue != null)
            {
                occupantService.DeleteOccupant(_oldValue.Id);
                occupantService.AddOccupant(updatedOccupant);

                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "Occupant with " + _oldValue.Id + " is updated.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "There is no occupant with " + id + " id.";
            }
            return result;
        }


        [HttpDelete("DeleteOccupant")]
        public Result DeleteOccupant(int id)
        {
            Result result = new Result();

            if (occupantService.DeleteOccupant(id))
            {
                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "Ocupant with " + id + " id is deleted.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "There is no occupant with " + id + " id.";
            }
            return result;
        }
    }
}
