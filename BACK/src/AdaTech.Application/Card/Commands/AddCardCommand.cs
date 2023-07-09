using MediatR;

namespace AdaTech.Application.Card.Commands
{
    using AdaTech.Domain.Models;

    public class AddCardCommand : CardCommand, IRequest<Response<Card>>
    {
        public AddCardCommand(string titulo, string conteudo, string lista) : base(titulo, conteudo, lista) {}
    }
}
