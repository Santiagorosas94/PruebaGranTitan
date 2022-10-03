using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaGranTitan.Application
{
    public interface IDefaultService
    {
        void SetValidationDictionary(IValidationDictionary validationDictionary);
    }

    public class DefaultService : IDefaultService
    {
        protected IValidationDictionary _validationDictionary;
        public DefaultService()
        {

        }
        public virtual void SetValidationDictionary(IValidationDictionary validationDictionary)
        {
            _validationDictionary = validationDictionary;
        }
    }
}
