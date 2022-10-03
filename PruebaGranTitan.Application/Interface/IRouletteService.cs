namespace PruebaGranTitan.Application
{
    using PruebaGranTitan.Domain;
    using System;
    using System.Collections.Generic;
    public interface IRouletteService
    {
        Roulette GetByid(int Id);

        List<Roulette> GetAll();

        bool CreateOrEdit(Roulette estudiante);

        bool Delete(Guid Id);

    }
}
