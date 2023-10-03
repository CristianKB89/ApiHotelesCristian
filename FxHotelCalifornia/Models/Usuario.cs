using System;
using MongoDB.Bson.Serialization.Attributes;

namespace FxHotelCalifornia.Models
{
	public class Usuario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombres")]
        public string? Nombres { get; set; }

        [BsonElement("apelidos")]
        public string? Apellidos { get; set; }

        [BsonElement("fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [BsonElement("genero")]
        public string? Genero { get; set; }

        [BsonElement("tipoDocumento")]
        public string? TipoDocumento { get; set; }

        [BsonElement("numeroDocumento")]
        public string? NumeroDocumento { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("telefonoContacto")]
        public string? TelefonoContacto { get; set; }
    }
}

