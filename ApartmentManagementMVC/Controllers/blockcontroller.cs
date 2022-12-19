using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManagementMVC.Controllers
{
    public class blockcontroller : Controller
    {
        private UserContext _context = new UserContext();

        public ActionResult AddBlock(Blocks _blocks)
        {
            try
            {
                _context.Blocks.Add(_blocks);
                _context.SaveChanges();
            }
            catch (Exception exc)
            {
                Exception x = exc;
            }

            return View();
        }

        public List<Blocks> GetBlock()
        {
            List<Blocks> blocks = new List<Blocks>();
            blocks = _context.Blocks.OrderBy(x => x.id).ToList<Blocks>();
            return blocks;
        }

        public Blocks CheckBlock(string occupant = "", int block = 0, int id = 0)
        {
            Blocks? user = new Blocks();

            if (!string.IsNullOrEmpty(occupant) && block > 0)
                user = _context.Blocks.FirstOrDefault(x => x.Occupant == occupant && x.Block == block);
            else if (id > 0)
            {
                user = _context.Blocks.FirstOrDefault(x => x.id == id);
            }
            return user;
        }

        public bool DeleteBlock(int Id)
        {
            try
            {
                _context.Blocks.Remove(CheckBlock("", 0, Id));
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
