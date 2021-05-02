using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    interface IValidable
    {
        bool ValidateTemperature(Vacuna unaVacuna);

        bool VaidateAge(Vacuna unaVacuna);

        decimal ValidatePrice(Vacuna unaVacuna);

        int VaidateLapsoDiasDosis(Vacuna unaVacuna);

        bool ValidateCantidadDosis(Vacuna unaVacuna);

        bool ValidateProduccionAnual(Vacuna unaVacuna);
    }
}
