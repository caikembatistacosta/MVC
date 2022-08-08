using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    internal interface IClienteDAO
    {
        Response Insert(Cliente cliente);
        DataResponse<Cliente> GetAll();
    }
}
