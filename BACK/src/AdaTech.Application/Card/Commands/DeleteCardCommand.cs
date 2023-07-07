using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdaTech.Application.Card.Commands
{
    public class DeleteCardCommand : IRequest<Unit>
    {
        public DeleteCardCommand(string id)
        {
            Id = id;
        }

        [Required]
        [DefaultValue(null)]
        public string Id { get; set; }
    }
}
