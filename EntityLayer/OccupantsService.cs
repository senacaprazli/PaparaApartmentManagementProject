using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class OccupantsService
    {
        private UserContext _context = new UserContext();

        public bool AddOccupant(Occupants _occupant)
        {
            try
            {
                _context.Occupants.Add(_occupant);
                _context.SaveChanges();

                return true;
            }
            catch (Exception exc)
            {
                Exception x = exc;
                return false;
            }
        }

        public List<Occupants> GetOccupant()
        {

            List<Occupants> occupant = new List<Occupants>();
            occupant = _context.Occupants.OrderBy(x => x.Id).ToList<Occupants>();
            return occupant;
        }

        public Occupants CheckOccupant(string tcId = "", int id = 0)
        {
            Occupants? user = new Occupants();

            if (!string.IsNullOrEmpty(tcId))
                user = _context.Occupants.FirstOrDefault(x => x.TcId == tcId);

            else if (id > 0)
            {
                user = _context.Occupants.FirstOrDefault(m => m.Id == id);
            }
            return user;
        }

        public bool DeleteOccupant(int Id)
        {
            try
            {
                _context.Occupants.Remove(CheckOccupant("", Id));
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
