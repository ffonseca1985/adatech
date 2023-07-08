using AdaTech.Application.Card.Commands;
using MediatR;

namespace AdaTech.Application.Card
{
    using AdaTech.Application.Card.Queries;
    using AdaTech.Domain.Interfaces;
    using AdaTech.Domain.Models;
    using Microsoft.Extensions.Logging;
    using System.Threading;

    public class CardHandler : IRequestHandler<AddCardCommand, Card>,
                               IRequestHandler<DeleteCardCommand, Unit>,
                               IRequestHandler<FindAllCardsQuery, IEnumerable<Card>>,
                               IRequestHandler<FindCardByIdQuery, Card?>,
                               IRequestHandler<UpdateCardCommand, Card> 
                                
    {
        private readonly IRepository<Card> _cardRepository;
        private readonly ILogger<CardHandler> _logger;

        public CardHandler(IRepository<Card> cardRepository, ILogger<CardHandler> logger)
        {
            _cardRepository = cardRepository;
            _logger = logger;
        }

        ///
        public async Task<Card> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var id = new Guid();

                var card = new Card(id, request.Titulo, request.Conteudo, request.Lista);
                await _cardRepository.InsertAsync(card);

                await _cardRepository.SaveChangesAsync();

                return card;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public async Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _cardRepository.DeleteAsync(new Guid(request.Id));
                await _cardRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public async Task<IEnumerable<Card>> Handle(FindAllCardsQuery _, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cardRepository.GetAllAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public async Task<Card?> Handle(FindCardByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cardRepository.GetFirstAsync(x => x.Id == new Guid(request.Id));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public async Task<Card> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var card = new Card(new Guid(request.Id!), request.Titulo, request.Conteudo, request.Lista);
                
                var result = await _cardRepository.UpdateAsync(card);
                await _cardRepository.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }
    }
}
