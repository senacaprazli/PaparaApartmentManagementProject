using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class MessageService
    {
        private UserContext _context = new UserContext();

        public bool AddMessage(Messages _message)
        {
            try
            {
                _context.Messages.Add(_message);
                _context.SaveChanges();

                return true;
            }
            catch (Exception exc)
            {
                Exception x = exc;
                return false;
            }
        }

        public List<Messages> GetMessage()
        {
            List<Messages> message = new List<Messages>();
            message = _context.Messages.OrderBy(x => x.Id).ToList<Messages>();
            return message;
        }

        public Messages CheckMessage(int id = 0)
        {
            Messages? user = new Messages();
            if (id > 0)
            {
                user = _context.Messages.FirstOrDefault(x => x.Id == id);
            }
            return user;
        }

        public bool DeleteMessage(int Id)
        {
            try
            {
                _context.Messages.Remove(CheckMessage(Id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
