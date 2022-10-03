namespace PruebaGranTitan.Application
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PruebaGranTitan.Domain;
    using PruebaGranTitan.Data;
    using Microsoft.EntityFrameworkCore;

    public class StateService : IStateService
    {
        private readonly ApplicationDbContext _context;
        public StateService(ApplicationDbContext context)
        {
            _context = context;
        }
        public State GetByid(int Id)
        {
            return _context.State.FirstOrDefaultAsync(m => m.Id == Id).Result;
        }

        public List<State> GetAll()
        {
            return _context.State.ToList();
        }

        public bool CreateOrEdit(State State)
        {
            try
            {
                if (State.Id.Equals(Guid.Empty))
                    _context.Add(State);
                else
                    _context.Update(State);
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
                var State = _context.State.Find(Id);
                _context.State.Remove(State);
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
