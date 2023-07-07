using MediatR;

namespace AdaTech.Application.Card.Queries
{
    using AdaTech.Domain.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class FindCardByIdQuery : IRequest<Card>
    {
        [Required]
        [DefaultValue(null)]
        public string Id { get; set; }

        public FindCardByIdQuery(string id)
        {
            Id = id;
        }
    }
}
