using MongoDB.Bson.Serialization.Attributes;

namespace FxHotelCalifornia.Models
{
    public class Hotel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nombre")]
        public string? Nombre { get; set; }

        [BsonElement("direccion")]
        public string? Direccion { get; set; }

        [BsonElement("ciudad")]
        public string? Ciudad { get; set; }

        [BsonElement("hotelHabilitado")]
        public bool? HotelHabilitado { get; set; }

        [BsonElement("habitaciones")]
        public List<Habitacion> Habitaciones { get; set; }
    }
}