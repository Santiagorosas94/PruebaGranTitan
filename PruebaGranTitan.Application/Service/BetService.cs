namespace PruebaGranTitan.Application
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PruebaGranTitan.Domain;
    using PruebaGranTitan.Data;
    using Microsoft.EntityFrameworkCore;
    using PruebaGranTitan.Domain.Enums;

    public class BetService : DefaultService, IBetService
    {
        public readonly ApplicationDbContext _context;
        public BetService(ApplicationDbContext context)
        {
            _context = context;

        }
        public Bet GetByid(int Id)
        {
            return _context.Bet.FirstOrDefaultAsync(m => m.Id == Id).Result;
        }

        public List<Bet> GetAll()
        {
            return _context.Bet.ToList();
        }

        public void SaveResult(int idRoulette)
        {
            var roulette = _context.Roulette.FirstOrDefault(m => m.Id == idRoulette);
            var bet = _context.Bet.Where(x => x.RouletteId.Equals(roulette.Id)).ToList();
            var number = _context.Number.FirstOrDefaultAsync(m => m.Id == RamdonNumber()).Result;
            var winningBets = bet.Where(x => (x.NumberId.Equals(number.Id) || x.ColorId.Equals(number.IdColor))).ToList();
            foreach (var item in winningBets)
            {
                var paymentValue = CalculatePaymenteValue(item);
                var resultBets = new ResultBet()
                {
                    BetId = item.Id,
                    PaymentValue = paymentValue
                };
                _context.ResultBet.Add(resultBets);
            }
            roulette.StateId = (int)Enums.Estados.Inactivo;
            _context.Roulette.Update(roulette);
            _context.SaveChanges();
        }
        private int RamdonNumber()
        {
            Random rnd = new Random();
            List<Number> numbers = new List<Number>();
            numbers = _context.Number.OrderBy(x => x.Id).ToList();

            return rnd.Next(numbers.FirstOrDefault().Id, numbers.LastOrDefault().Id);
        }
        private double CalculatePaymenteValue(Bet item)
        {
            double paymentValue = 0;
            if (!item.NumberId.HasValue)
                paymentValue = item.ValueBet * 1.5;
            else
                paymentValue = item.ValueBet * 5;

            return paymentValue;
        }

        public List<Roulette> GetResult(Roulette Roulette)
        {
            var result = new List<Roulette>();
            _context.Roulette.ToList();

            return result;
        }

        public bool CreateOrEdit(Bet Bet)
        {
            try
            {
                if (Bet.Id == 0)
                    _context.Add(Bet);
                else
                    _context.Update(Bet);
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
                var Bet = _context.Bet.Find(Id);
                _context.Bet.Remove(Bet);
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
