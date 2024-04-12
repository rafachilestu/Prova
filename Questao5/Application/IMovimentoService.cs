using Questao5.Application.Commands.Requests;

namespace Questao5.Application
{
    public interface IMovimentoService
    {
        int Update(MovimentoRequest movimento);
    }
}
