using AdaTech.Application.Card.Commands;
using MediatR;

namespace AdaTech.Application.Card
{
    using AdaTech.Application.Card.Queries;
    using AdaTech.Domain.Interfaces;
    using AdaTech.Domain.Models;
    using Microsoft.Extensions.Logging;
    using System.Threading;

    public class CardHandler : IRequestHandler<AddCardCommand, Response<Card>>,
                               IRequestHandler<DeleteCardCommand, Response<IEnumerable<Card>>>,
                               IRequestHandler<FindAllCardsQuery, IEnumerable<Card>>,
                               IRequestHandler<FindCardByIdQuery, Card?>,
                               IRequestHandler<UpdateCardCommand, Response<Card>> 
                                
    {
        private readonly IRepository<Card> _cardRepository;
        private readonly ILogger<CardHandler> _logger;

        public CardHandler(IRepository<Card> cardRepository, ILogger<CardHandler> logger)
        {
            _cardRepository = cardRepository;
            _logger = logger;
        }

        ///
        public async Task<Response<Card>> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var card = new Card(new Guid(), request.Titulo, request.Conteudo, request.Lista);

                var (isValid, errorList) = card.IsValid();
                
                if (isValid == false)
                {
                    return new Response<Card>(errorList.ToArray());
                }

                await _cardRepository.InsertAsync(card);
                await _cardRepository.SaveChangesAsync(cancellationToken);

                return new Response<Card>(card);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        /// <summary>
        /// Handler que deleta virtualmente, ou seja, coloca como disable = true
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<Card>>> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var card = await _cardRepository.GetFirstAsync(x => x.Id == new Guid(request.Id));

                if (card == null)
                {
                     return Response<IEnumerable<Card>>.NotFoundError(request.Id);
                }

                card.Delete();                
                var (isValid, errorList) = card.IsValid();

                if (isValid == false)
                {
                    return new Response<IEnumerable<Card>>(errorList.ToArray());
                }

                await _cardRepository.UpdateAsync(card);
                await _cardRepository.SaveChangesAsync(cancellationToken);

                var cards = await _cardRepository.GetAsync(x => x.Disable == false);

                return new Response<IEnumerable<Card>>(cards);
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
                var result = await _cardRepository.GetAsync(x => x.Disable == false);
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

        public async Task<Response<Card>> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var search = await _cardRepository.GetFirstAsync(x => x.Id == new Guid(request.Id!));

                if (search == null)
                {
                    return Response<Card>.NotFoundError(request.Id!);
                }

                search.Update(request.Titulo, request.Conteudo, request.Lista);
                var (isValid, errorList) = search.IsValid();

                if (isValid == false)
                {
                    return new Response<Card>(errorList.ToArray());
                }

                var result = await _cardRepository.UpdateAsync(search);
                await _cardRepository.SaveChangesAsync(cancellationToken);

                return new Response<Card>(search);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }
    }
}
