using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IServiceCompletedService
    {
        IEnumerable<ServiceCompleted> GetAll();
    }
    public class ServiceCompletedService : IServiceCompletedService
    {
        private List<ServiceCompleted> _servicos = new List<ServiceCompleted>
        { 
            new ServiceCompleted { Id = 1, TipoPagamento = "Cartao de Credito", Valor = "100,00", Servicos = "Vacina", PetAtendido = "Rex", Profissional = "Edson Gomes" },
            new ServiceCompleted { Id = 1, TipoPagamento = "Dinheiro", Valor = "50,00", Servicos = "Banho", PetAtendido = "Rex", Profissional = "Eduarda Silva" },
            new ServiceCompleted { Id = 1, TipoPagamento = "Cartao de Debito", Valor = "120,00", Servicos = "Consulta", PetAtendido = "Rex", Profissional = "Maria Angela Amaranto" },
            new ServiceCompleted { Id = 1, TipoPagamento = "Dinheiro", Valor = "50,00", Servicos = "Banho", PetAtendido = "Rex", Profissional = "Eduarda Silva" }
        };

        private readonly AppSettings _appSettings;

        public ServiceCompletedService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public IEnumerable<ServiceCompleted> GetAll() {
            // return users without passwords
            return _servicos.Select(x => {
                return x;
            });
        }
    }
}