using MediatR;

namespace AdaTech.Application.Card.Queries
{
    using AdaTech.Domain.Models;
    public class FindAllCardsQuery : IRequest<IEnumerable<Card>> {}
}
