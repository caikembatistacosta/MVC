using BLL.Interfaces;
using BLL.Validators.Pet;
using Common;
using Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Extensions;
using DAO.Impl;

namespace BLL.Impl
{
    //No mundo real, a camada de negócio não faz apenas validações, ela é responsável
    //por regras mais avançadas, log, cache, autorização
    //Install-Package FluentValidation
    public class PetService : IPetService
    {
        public DataResponse<Pet> GetAll()
        {
            //No mundo real, poderia estar sendo trabalhado a politica de cache do pet!
            PetDAO dao = new PetDAO();
            return dao.GetAll();
        }

        public Response Insert(Pet p)
        {
            //PetInsertValidator validator = new PetInsertValidator();
            //ValidationResult result = validator.Validate(p);
            //Response response = result.ConvertToResponse();
            Response response = new PetInsertValidator().Validate(p).ConvertToResponse();

            //Se a validação não passou, retorne o response para tela!
            if (!response.HasSuccess)
            {
                return response;
            }
            //Se o pet está sendo cadastrado, então ele está ativo.
            p.EstaAtivo = true;

            //Se chegou aqui, é pq a validação passou e o PET está pronto pra ser cadastrado no banco.
            PetDAO dao = new PetDAO();
            response = dao.Insert(p);
            return response;
        }
    }
}
