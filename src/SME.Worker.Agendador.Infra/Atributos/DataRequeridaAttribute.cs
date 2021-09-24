using System;
using System.ComponentModel.DataAnnotations;

namespace SME.Worker.Agendador.Infra
{
    public class DataRequeridaAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            return (DateTime)value != DateTime.MinValue;
        }
    }
}