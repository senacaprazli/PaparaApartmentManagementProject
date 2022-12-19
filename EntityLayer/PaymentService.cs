using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ServiceLayer
{
    public class PaymentService
    {
        private UserContext _context = new UserContext();

        public bool AddPayment(Payments _payments)
        {
            try
            {
                _context.Payments.Add(_payments);
                _context.SaveChanges();

                return true;
            }
            catch (Exception exc)
            {
                Exception x = exc;
                return false;
            }
        }

        public List<Payments> GetPayments()
        {

            List<Payments> payments = new List<Payments>();
            payments = _context.Payments.OrderBy(m => m.id).ToList<Payments>();
            return payments;
        }

        public Payments CheckPayments(int id = 0)
        {
            Payments? user = new Payments();
            if (id > 0)
            {
                user = _context.Payments.FirstOrDefault(m => m.id == id);
            }
            return user;
        }

        public bool DeletePayments(int Id)
        {
            try
            {
                _context.Payments.Remove(CheckPayments(Id));
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
