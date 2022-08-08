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
    public class PetDAO : IPetDAO
    {
        public DataResponse<Pet> GetAll()
        {
            PetShopDbContext db = new PetShopDbContext();
            DataResponse<Pet> response = new DataResponse<Pet>();

            try
            {
                List<Pet> pets = db.Pets.Where(p => p.EstaAtivo).ToList();
                response.HasSuccess = true;
                response.Message = "Pets selecionados com sucesso!";
                response.Data = pets;
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

        public Response Insert(Pet pet)
        {
            PetShopDbContext db = new PetShopDbContext();
            db.Pets.Add(pet);
            try
            {
                db.SaveChanges();
                return new Response()
                {
                    HasSuccess = true,
                    Message = "Neném cadastrado com sucesso."
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
