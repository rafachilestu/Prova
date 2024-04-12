using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application
{
    public class MovimentoService
    {

        public int Update(MovimentoRequest movimento)
        {
            
                MovimentoResponse response = new MovimentoResponse();

                // fazer update no banco de dados do objeto movimento
                // retornar o id no objeto response

                return response.IdMovimento;
            
        }
    }
}
