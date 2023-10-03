using System;
using MongoDB.Bson.Serialization.Attributes;

namespace FxHotelCalifornia.Models
{
	public class Reserva
	{
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("fechaEntrada")]
        public DateTime FechaEntrada { get; set; }

        [BsonElement("fechaSalida")]
        public DateTime FechaSalida { get; set; }

        [BsonElement("cantidadPersonas")]
        public int? CantidadPersonas { get; set; }

        [BsonElement("ciudadDestino")]
        public string? CiudadDestino { get; set; }

        [BsonElement("habitacionElegida")]
        public Habitacion? HabitacionElegida { get; set; }

        [BsonElement("usuario")]
        public Usuario? Usuario { get; set; }
    }
}

