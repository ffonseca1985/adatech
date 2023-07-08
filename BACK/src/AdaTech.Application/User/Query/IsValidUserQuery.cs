using MediatR;

namespace AdaTech.Application.User.Query
{
    using AdaTech.Domain.Models;
    using Newtonsoft.Json;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class IsValidUserQuery : IRequest<bool>
    {
        public IsValidUserQuery(string userName, string passWord)
        {
            UserName = userName;
            PassWord = passWord;
        }

        [Required]
        [DefaultValue(null)]
        [JsonPropertyName("login")]
        public string UserName { get; set; }

        [Required]
        [DefaultValue(null)]
        [JsonPropertyName("senha")]
        public string PassWord { get; set; }
    }
}
