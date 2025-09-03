using Bogus;
using EstacionamentoApp.Domain.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Test
{
    public class EstacionamentoTest
    {
        [Fact]
        public void Cadastro_Veiculo_Com_Sucesso()
        {
            var faker = new Faker("pt_BR");
            var request = new CadastroVeiculoRequestDto
            {
                NomeDono = faker.Name.FullName(),
                Placa = faker.Random.String2(3, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                + "-" +
                faker.Random.Int(1000, 9999),

                EmailDono = faker.Internet.Email(),

            };

            var jsonRequest = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var Client = new WebApplicationFactory<Program>().CreateClient();

            var result = Client.PostAsync("/api/veiculo", jsonRequest).Result;

            result.StatusCode
                .Should()
                .Be(System.Net.HttpStatusCode.Created);

        }
        [Fact]
        public void Retirar_Veiculo_Com_Sucesso()
        {

            #region Cadastrar Veiculo para depois Retirar

            var faker = new Faker("pt_BR");

            var CadastroVeiculoRequest = new CadastroVeiculoRequestDto
            {
                NomeDono = faker.Name.FullName(),
                Placa = faker.Random.String2(3, "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                + "-" +
                faker.Random.Int(1000, 9999),
                EmailDono = faker.Internet.Email(),
            };

            var jsonCadastroVeiculoRequest = new StringContent(JsonConvert.SerializeObject(CadastroVeiculoRequest), Encoding.UTF8, "application/json");

            var Client = new WebApplicationFactory<Program>().CreateClient();

            var resultCadastro = Client.PostAsync("/api/veiculo", jsonCadastroVeiculoRequest).Result;

            #endregion

            var RetirarVeiculoRequest = new RetirarVeiculoRequestDto
            {
                Placa = CadastroVeiculoRequest.Placa,
                EmailDono = CadastroVeiculoRequest.EmailDono,
            };

            var jsonRetirarVeiculoRequest = new StringContent(JsonConvert.SerializeObject(RetirarVeiculoRequest), Encoding.UTF8, "application/json");

            var result = Client.PostAsync("/api/veiculo/retirar", jsonRetirarVeiculoRequest).Result;

            result.StatusCode
                .Should()
                .Be(System.Net.HttpStatusCode.OK);

            var json = result.Content.ReadAsStringAsync().Result;

            var response = JsonConvert.DeserializeObject<RetirarVeiculoResponseDto>(json);

            object value = response.Id.Should().NotBeEmpty();
            response.NomeDono.Should().Be(CadastroVeiculoRequest.NomeDono);

            response.EmailDono.Should().Be(CadastroVeiculoRequest.EmailDono);

            response.HoraSaida.Should().NotBeNull();


        }
    }
}
