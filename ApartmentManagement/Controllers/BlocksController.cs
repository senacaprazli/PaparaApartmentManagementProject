using ApartmentManagement.Controllers;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace ApartmentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class BlocksController : ControllerBase
    {
        BlockService blockService = new BlockService();

        //HTTPGET
        [HttpGet("GetBlocks")]
        public List<Blocks> GetBlocks()
        {
            return blockService.GetBlock();
        }
               
        //HTTPPOST
        [HttpPost("AddBlock")]
        public Result AddBlock([FromBody] Blocks newBlock)
        {
            Blocks user = blockService.CheckBlock(newBlock.Occupant, newBlock.Block);

            //check if newblock is in the list
            bool userCheck = (user != null) ? true : false;
            Result result = new Result();

            if (userCheck == false)
            {
                if (blockService.AddBlock(newBlock) == true)
                {
                    //If same id is not in the list, add newblock
                    result.HttpStatusCode = Ok().StatusCode;
                    result.Message = "New block with " + newBlock.id + " id is added";
                }
                else
                {
                    //if there is an error
                    result.HttpStatusCode = BadRequest().StatusCode;
                    result.Message = "Apartment with " + newBlock.id + " id can not added";
                }
            }
            else
            {
                //If same id is in the list
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "Apartmen with" + newBlock.id + " id is already in the list";
            }

            return result;
        }

        //HTTPPUT
        [HttpPut("UpdateBlock")]

        public Result UpdateBlock(int id, [FromBody] Blocks updatedBlock)
        {
            Console.WriteLine(id);
            Console.WriteLine(updatedBlock);
            Result result = new Result();

            List<Blocks> userList = blockService.GetBlock();

            //If profile is in the list, update it
            Blocks? _oldValue = userList.Find(x => x.id == id);
            if (_oldValue != null)
            {
                blockService.DeleteBlock(_oldValue.id);
                blockService.AddBlock(updatedBlock);

                result.HttpStatusCode = Ok().StatusCode;
                result.Message = "Block with " + _oldValue.id + " is updated.";
            }
            else
            {
                result.HttpStatusCode = BadRequest().StatusCode;
                result.Message = "There is no block with " + id + " id.";
            }
            return result;
        }
             
        //HTTPDELETE
        [HttpDelete("DeleteBlock")]
        public Result DeleteBlock(int id)
        {
            Result result = new Result();

            //If profile is in the list, delete it
            if (blockService.DeleteBlock(id))
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
