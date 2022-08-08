using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators.Pet
{
    internal class PetUpdateValidator : PetValidator
    {
        public PetUpdateValidator()
        {
            base.ValidateID();
            base.ValidatePeso();
        }

    }
}
