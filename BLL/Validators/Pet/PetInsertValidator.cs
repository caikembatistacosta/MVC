using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators.Pet
{
    internal class PetInsertValidator : PetValidator
    {
        public PetInsertValidator()
        {
            base.ValidateNome();
            base.ValidatePeso();
            base.ValidateRaca();
            base.ValidateCor();
        }

    }
}
