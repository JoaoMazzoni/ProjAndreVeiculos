using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

//"cep": "01001-000",
//      "logradouro": "Praça da Sé",
//      "complemento": "lado ímpar",
//      "bairro": "Sé",
//      "localidade": "São Paulo",
//      "uf": "SP",
//      "ibge": "3550308",
//      "gia": "1004",
//      "ddd": "11",
//      "siafi": "7107"