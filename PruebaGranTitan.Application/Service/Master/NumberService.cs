namespace PruebaGranTitan.Application
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PruebaGranTitan.Domain;
    using PruebaGranTitan.Data;
    using Microsoft.EntityFrameworkCore;

    public class NumberService: INumberService
    {
        private readonly ApplicationDbContext _context;
        public NumberService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Number GetByid(int Id)
        {
            return _context.Number.FirstOrDefaultAsync(m => m.Id == Id).Result;
        }

        public List<Number> GetAll()
        {
            return _context.Number.ToList();
        }

        public bool CreateOrEdit(Number Number)
        {
            try
            {
                if (Number.Id.Equals(Guid.Empty))
                    _context.Add(Number);
                else
                    _context.Update(Number);
                _context.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var Number = _context.Number.Find(Id);
                _context.Number.Remove(Number);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
