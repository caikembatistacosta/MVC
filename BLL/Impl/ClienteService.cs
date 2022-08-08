using BLL.Extensions;
using BLL.Interfaces;
using BLL.Validators.Cliente;
using Common;
using DAO.Impl;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClienteService : IClienteService
    {
        public DataResponse<Cliente> GetAll()
        {
            //No mundo real, poderia estar sendo trabalhado a politica de cache do pet!
            ClienteDAO dao = new ClienteDAO();
            return dao.GetAll();
        }

        public Response Insert(Cliente c)
        {
            //PetInsertValidator validator = new PetInsertValidator();
            //ValidationResult result = validator.Validate(p);
            //Response response = result.ConvertToResponse();
            Response response = new ClienteInsertValidator().Validate(c).ConvertToResponse();

            //Se a validação não passou, retorne o response para tela!
            if (!response.HasSuccess)
            {
                return response;
            }
            //Se o pet está sendo cadastrado, então ele está ativo.
            c.Ativo = true;

            //Se chegou aqui, é pq a validação passou e o PET está pronto pra ser cadastrado no banco.
            ClienteDAO dao = new ClienteDAO();
            response = dao.Insert(c);
            return response;
        }
    }
}
