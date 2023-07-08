using AdaTech.Application.Card;
using AdaTech.Application.User.Query;
using AdaTech.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdaTech.Application.User
{
    using AdaTech.Domain.Models;
    using AdaTech.Infra.Security;

    public class UserHandler : IRequestHandler<IsValidUserQuery, bool>
    {
        private readonly IRepository<User> _userRepository;
        private readonly ILogger<CardHandler> _logger;

        public UserHandler(IRepository<User> userRepository, ILogger<CardHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(IsValidUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetFirstAsync(x => x.UserName == request.UserName);

                if (user == null) return false;

                var hash = PasswordHasherInMemory.HashPassword(request.UserName, request.PassWord);

                if (user.Hash != hash) return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }
    }
}
