using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdaTech.Application.Card.Commands
{
    using AdaTech.Domain.Models;
    public class DeleteCardCommand : IRequest<Response<IEnumerable<Card>>>
    {
        public DeleteCardCommand(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is empty");  
            }

            Id = id;
        }

        [Required]
        [DefaultValue(null)]
        public string Id { get; set; }
    }
}
