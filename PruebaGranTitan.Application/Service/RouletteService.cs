namespace PruebaGranTitan.Application
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PruebaGranTitan.Domain;
    using PruebaGranTitan.Data;

    public class RouletteService : IRouletteService
    {
        private readonly ApplicationDbContext _context;
        public RouletteService(ApplicationDbContext context)
        {
            _context = context;

        }
        public Roulette GetByid(int Id)
        {

            return _context.Roulette.FirstOrDefault(m => m.Id == Id);
        }

        public List<Roulette> GetAll()
        {

            return _context.Roulette.ToList();
        }

        public bool CreateOrEdit(Roulette Roulette)
        {
            try
            {
                if (Roulette.Id.Equals(Guid.Empty))
                    _context.Add(Roulette);
                else
                    _context.Update(Roulette);
                _context.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var Roulette = _context.Roulette.Find(Id);
                _context.Roulette.Remove(Roulette);
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
