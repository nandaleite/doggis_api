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
    public interface IServiceService
    {
        IEnumerable<Service> GetAll();
    }
    public class ServiceService : IServiceService
    {
        private List<Service> _servicos = new List<Service>
        { 
           // new Service { Id = 1, TipoPagamento = "Cartao de Credito", Valor = "100,00", Servicos = "Vacina", PetAtendido = "Rex", Profissional = "Edson Gomes" }
        };

        private readonly AppSettings _appSettings;

        public ServiceService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Service> GetAll() {
            // return users without passwords
            return _servicos.Select(x => {
                return x;
            });
        }
    }
}