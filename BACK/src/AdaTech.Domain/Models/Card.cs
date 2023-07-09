
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
        public bool Disable { get; set; } = false;
        public string Conteudo { get; set; }
        public string Lista { get; set; }

        public void Delete()
        {
            this.Disable = true;
        }

        public void Update(string titulo, string conteudo, string lista)
        {
            this.Titulo = titulo;
            this.Conteudo = conteudo;
            this.Lista = lista;
        }

        public (bool, List<string>) IsValid()
        {
            List<string> errors = new();

            if (string.IsNullOrEmpty(this.Lista))
            {
                errors.Add("List is empty");
            }

            return (errors.Any() == false, errors);
        }
    }
}
