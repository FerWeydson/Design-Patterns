using Localiza.Frotas.Domain;
using Localiza.Frotas.infra.Facade;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Localiza.Frotas.Infra.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetran
    {
        private readonly DetranOptions detranOptions;
        private readonly System.Net.Http.IHttpClientFactory httpClientFactory;
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> detranOptions, System.Net.Http.IHttpClientFactory httpClientFactory, IVeiculoRepository veiculoRepository)
        {
            this.detranOptions = detranOptions.CurrentValue;
            this.httpClientFactory = httpClientFactory;
            this.veiculoRepository = veiculoRepository;
        }

        public async Task AgendarVistoriaDetran(Guid veiculoId)
        {
            var veiculo = veiculoRepository.GetById(veiculoId);

            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(detranOptions.BaseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestModel = new VistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(detranOptions.QuantidadeDiasParaAgendamento)
            };
            var jsonContent = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await client.PostAsync(detranOptions.VistoriaUri, contentString);
        }
    }
}
