using AutoMapper;
using BLL.Impl;
using Common;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MVCPresentationLayer.Models.Cliente;

namespace MVCPresentationLayer.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ClienteService clienteService = new ClienteService();

            DataResponse<Cliente> responseClientes = clienteService.GetAll();

            if (!responseClientes.HasSuccess)
            {
                //Se o select falhou, retorne a mensagem de erro para o cliente
                ViewBag.Errors = responseClientes.Message;
                return View();
            }
            //Se chegou aqui, o select funcionou, bora transformar a List<Pet> em uma List<PetSelectViewModel>

            MapperConfiguration mapper = new MapperConfiguration(m =>
               m.CreateMap<Cliente, ClienteSelectViewModel>()
           );

            List<ClienteSelectViewModel> clientes =
                mapper.CreateMapper().Map<List<ClienteSelectViewModel>>(responseClientes.Data);

            return View(clientes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ClienteInsertViewModel viewModel)
        {
            //Converter PetInsertViewModel para Pet e jogar para o BusinessLogicalLayer
            //AutoMapper
            //Cria uma configuração de mapeador que diz que o objeto PetInsertViewModel pode ser convertido em um Pet
            MapperConfiguration mapper = new MapperConfiguration(m =>
                m.CreateMap<ClienteInsertViewModel, Cliente>()
            );

            //Faz a conversão.
            Cliente cliente = mapper.CreateMapper().Map<Cliente>(viewModel);

            ClienteService clienteService = new ClienteService();

            //Chama a camada de negócio para validar o pet e posteriormente inseri-lo no banco de dados
            Response response = clienteService.Insert(cliente);

            //Pet cadastrado com sucesso
            if (response.HasSuccess)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Errors = response.Message;
            return View();
        }
    }
}
