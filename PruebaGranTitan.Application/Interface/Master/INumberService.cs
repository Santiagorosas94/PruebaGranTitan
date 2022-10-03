namespace PruebaGranTitan.Application
{
    using PruebaGranTitan.Domain;
    using System;
    using System.Collections.Generic;
    public interface INumberService
    {
        Number GetByid(int Id);

        List<Number> GetAll();

        bool CreateOrEdit(Number number);

        bool Delete(int Id);

    }
}
