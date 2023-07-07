using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Application.Card.Commands
{
    public class CardCommand
    {
        public CardCommand(string titulo, string conteudo, string lista)
        {
            Titulo = titulo;
            Conteudo = conteudo;
            Lista = lista;
        }

        [Required]
        [DefaultValue(null)]
        public string Titulo { get; set; }

        [Required]
        [DefaultValue(null)]
        public string Conteudo { get; set; }

        [Required]
        [DefaultValue(null)]
        public string Lista { get; set; }
    }
}
