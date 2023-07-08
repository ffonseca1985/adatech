using MediatR;

namespace AdaTech.Application.Card.Commands
{
    using AdaTech.Domain.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UpdateCardCommand : CardCommand, IRequest<Card>
    {
        public UpdateCardCommand(string id, string titulo, string conteudo, string lista)
            : base(titulo, conteudo, lista) {

            this.Id = id;
        }

        [Required]
        [DefaultValue(null)]
        public string? Id { get; set; }
    }
}
