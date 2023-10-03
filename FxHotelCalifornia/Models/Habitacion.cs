using MongoDB.Bson.Serialization.Attributes;

namespace FxHotelCalifornia.Models
{
    public class Habitacion
    {
        [BsonElement("tipo_habitacion")]
        public string TipoHabitacion { get; set; }

        [BsonElement("costo_base")]
        public decimal CostoBase { get; set; }

        [BsonElement("impuestos")]
        public decimal Impuestos { get; set; }

        [BsonElement("disponibilidad")]
        public bool Disponibilidad { get; set; }

        [BsonElement("ubicacion_habitacion")]
        public string UbicacionHabitacion { get; set; }
    }
}