using System;
using Newtonsoft.Json;

namespace src.Api.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("authenticated")]
        public bool authenticated { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("expiration")]
        public DateTime expiration { get; set; }

        [JsonProperty("acessToken")]
        public string acessToken { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
