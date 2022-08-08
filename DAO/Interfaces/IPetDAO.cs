using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IPetDAO
    {
        Response Insert(Pet pet);
        DataResponse<Pet> GetAll();

    }
}
