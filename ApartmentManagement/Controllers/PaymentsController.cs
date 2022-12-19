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
    public class PaymentsController : ControllerBase
    {
        PaymentService paymentService = new PaymentService();

        [HttpGet("GetPayments")]
        public List<Payments> GetInvoicesDues()
        {
            return paymentService.GetPayments();
        }

        [HttpPost("AddPayments")]
        public Result AddIPayments([FromBody] Payments newPayment)
        {

            Result result = new Result();

            if (paymentService.AddPayment(newPayment) == true)
            {
                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "New payments with " + newPayment.id + " id is added.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "Payments with " + newPayment.id + " id cannot added.";
            }
            return result;
        }

        [HttpPut("UpdatePayments")]
        public Result UpdatePayments(int id, [FromBody] Payments updatedPayment)
        {
            Result result = new Result();

            List<Payments> userList = paymentService.GetPayments();

            Payments? _oldValue = userList.Find(x => x.id == id);
            if (_oldValue != null)
            {
                paymentService.DeletePayments(_oldValue.id);
                paymentService.AddPayment(updatedPayment);

                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "Payments with " + _oldValue.id + " is updated.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode; //error code
                result.Message = "There is no invoice/dues with " + id + " id.";
            }
            return result;
        }

        [HttpDelete("DeletePayment")]
        public Result DeletePayment(int id)
        {
            Result result = new Result();

            //If profile is in the list, delete it
            if (paymentService.DeletePayments(id))
            {
                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "Block with " + id + " id is deleted.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "There is no block with " + id + " id.";
            }
            return result;
        }

    }
}
