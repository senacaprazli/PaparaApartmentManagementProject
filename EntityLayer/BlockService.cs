using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApartmentManagement.Controllers
{
    public class BlockService
    {
        private UserContext _context = new UserContext();

        public bool AddBlock(Blocks _blocks)
        {
            try
            {
                _context.Blocks.Add(_blocks);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                Exception x = exc;
                return false;
            }
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

