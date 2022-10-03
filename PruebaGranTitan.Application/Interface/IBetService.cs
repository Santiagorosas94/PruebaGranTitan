namespace PruebaGranTitan.Application
{
    using PruebaGranTitan.Domain;
    using System;
    using System.Collections.Generic;
    public interface IBetService : IDefaultService
    {
        Bet GetByid(int Id);

        List<Bet> GetAll();

        bool CreateOrEdit(Bet bet);

        bool Delete(int Id);

        void SaveResult(int idRoulette);
    }
}