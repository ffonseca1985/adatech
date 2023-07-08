
namespace AdaTech.Domain.Models
{
    public class Card
    {
        public Card(Guid id, string titulo, string conteudo, string lista)
        {
            Id = id;
            Titulo = titulo;
            Conteudo = conteudo;
            Lista = lista;
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Lista { get; set; }
    }
}
