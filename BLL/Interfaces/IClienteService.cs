using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClienteService
    {
        Response Insert(Cliente c);
        DataResponse<Cliente> GetAll();
    }
}
