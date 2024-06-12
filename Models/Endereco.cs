using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Models
{
    public class Endereco
    {   
        [BsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("tipoLogradouro")]
        public string TipoLogradouro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("numero")]
        public int Numero { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("localidade")]
        public string Cidade { get; set; }
    }
}