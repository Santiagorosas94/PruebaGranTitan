namespace PruebaGranTitan.Application
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PruebaGranTitan.Domain;
    using Microsoft.EntityFrameworkCore;
    using PruebaGranTitan.Data;

    public class ColorService : IColorService
    {
        private readonly ApplicationDbContext _context;
        public ColorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Color GetByid(int Id)
        {
            return _context.Color.FirstOrDefaultAsync(m => m.Id == Id).Result;
        }

        public List<Color> GetAll()
        {
            return _context.Color.ToList();
        }

        public bool CreateOrEdit(Color Color)
        {
            try
            {
                if (Color.Id.Equals(Guid.Empty))
                    _context.Add(Color);
                else
                    _context.Update(Color);
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
                var Color = _context.Color.Find(Id);
                _context.Color.Remove(Color);
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
