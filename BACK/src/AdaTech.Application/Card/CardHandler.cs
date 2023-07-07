using AdaTech.Application.Card.Commands;
using MediatR;

namespace AdaTech.Application.Card
{
    using AdaTech.Application.Card.Queries;
    using AdaTech.Domain.Models;
    using System.Threading;

    public class CardHandler : IRequestHandler<AddCardCommand, Card>,
                               IRequestHandler<DeleteCardCommand, Unit>,
                               IRequestHandler<FindAllCardsQuery, List<Card>>,
                               IRequestHandler<FindCardByIdQuery, Card> 
                                
    {
        public Task<Card> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Card>> Handle(FindAllCardsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Card> Handle(FindCardByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
