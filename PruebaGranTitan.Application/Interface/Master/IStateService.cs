namespace PruebaGranTitan.Application
{
    using PruebaGranTitan.Domain;
    using System.Collections.Generic;

    public interface IStateService
    {
        State GetByid(int Id);

        List<State> GetAll();

        bool CreateOrEdit(State state);

        bool Delete(int Id);

    }
}
