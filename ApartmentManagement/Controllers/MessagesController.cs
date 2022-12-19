using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Collections.Generic;

namespace ApartmentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        MessageService messageService = new MessageService();

        [HttpGet("GetMessages")]
        public List<Messages> GetMessages()
        {
            return messageService.GetMessage();
        }

        [HttpPost("AddMessage")]
        public Result AddMessage([FromBody] Messages newMessage)
        {
            Result result = new Result();

            if (messageService.AddMessage(newMessage) == true)
            {
                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "New message with " + newMessage.Id + " id is added.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "Message with " + newMessage.Id + " id cannot added.";
            }
            return result;
        }

        [HttpPut("UpdateMessage")]
        public Result UpdateMessage(int id, [FromBody] Messages updatedMessage)
        {
            Result result = new Result();

            List<Messages> userList = messageService.GetMessage();

            Messages? _oldValue = userList.Find(x => x.Id == id);
            if (_oldValue != null)
            {
                    messageService.DeleteMessage(_oldValue.Id);
                    messageService.AddMessage(updatedMessage);

                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "Message with " + _oldValue.Id + " is updated.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "There is no message with " + id + " id.";
            }
            return result;
        }

        [HttpDelete("DeleteMessage")]
        public Result DeleteMessage(int id)
        {
            Result result = new Result();

            if (messageService.DeleteMessage(id))
            {
                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "Message is deleted.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "There is no message";
            }
            return result;
        }
    }
}
