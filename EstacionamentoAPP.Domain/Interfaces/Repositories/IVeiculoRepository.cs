using EstacionamentoApp.Domain.Entities;

namespace EstacionamentoApp.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository
    {
        void Insert(Veiculo veiculo);

        Veiculo? Find(string email, string placa);

        bool Exists(string email);
    }
}
