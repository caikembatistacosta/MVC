using Common;
using DAO.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class ClienteDAO : IClienteDAO
    {
        public DataResponse<Cliente> GetAll()
        {
            PetShopDbContext db = new PetShopDbContext();
            DataResponse<Cliente> response = new DataResponse<Cliente>();

            try
            {
                List<Cliente> cliente = db.Cliente.Where(p => p.Ativo).ToList();
                response.HasSuccess = true;
                response.Message = "Cliente selecionado com sucesso!";
                response.Data = cliente;
                return response;
            }
            catch (Exception ex)
            {
                response.HasSuccess = false;
                response.Message = "Erro no banco, contate o administrador.";
                response.Exception = ex;
                return response;
            }
        }

        public Response Insert(Cliente cliente)
        {
            PetShopDbContext db = new PetShopDbContext();
            db.Cliente.Add(cliente);
            try
            {
                db.SaveChanges();
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Cliente cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    HasSuccess = false,
                    Message = "Erro no banco de dados, contate o administrador.",
                    Exception = ex
                };
            }
        }
    }
}
