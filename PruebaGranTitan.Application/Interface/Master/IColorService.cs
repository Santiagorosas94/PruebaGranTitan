namespace PruebaGranTitan.Application
{
    using PruebaGranTitan.Domain;
    using System.Collections.Generic;

    public interface IColorService
    {
        Color GetByid(int Id);

        List<Color> GetAll();

        bool CreateOrEdit(Color color);

        bool Delete(int Id);

    }
}
