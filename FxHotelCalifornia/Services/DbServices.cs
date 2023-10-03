using System;
using MongoDB.Driver;
using FxHotelCalifornia.Models;
using FxHotelCalifornia.Interfaces;

namespace FxHotelCalifornia.Services
{
	public class DbServices
	{
		private IMongoCollection<Hotel> _hotel;
		private IMongoCollection<Reserva> _reserva;
		private IMongoCollection<Usuario> _usuario;

        public DbServices (IPtSettings settings)
		{
			var cliente = new MongoClient(settings.Server);
			var database = cliente.GetDatabase(settings.DataBase);
			_hotel = database.GetCollection<Hotel>("Hoteles");
            _reserva = database.GetCollection<Reserva>("Reservas");
            _usuario = database.GetCollection<Usuario>("Usuarios");

        }

        #region [Hoteles]
        public List<Hotel> GetHotels() => _hotel.Find(d => true).ToList();

        public List<Hotel> GetHotelesConDisponibilidad()
        {
            var consulta = _hotel.AsQueryable()
                .Where(hotel => hotel.Habitaciones.Any(habitacion => habitacion.Disponibilidad));

            var resultados = consulta.ToList();

            return resultados;
        }

        public Hotel CreateHotel(Hotel hotel)
        {
			_hotel.InsertOne(hotel);
			return hotel;
		}

        public string UpdateHotel(string id, Hotel hotel)
        {

            _hotel.ReplaceOne(hotel => hotel.Id == id, hotel);
            return $"Se actualizo el hotel {hotel.Nombre}, correctamente";
        }

        public string DeleteHotel(string id)
        {

            _hotel.DeleteOne(d => d.Id == id);
            return $"Se eliminó el hotel con id {id}, correctamente";
        }
        #endregion

        #region [Reservas]
        public List<Reserva> GetReservas() => _reserva.Find(d => true).ToList();

        public Reserva CreateReserva(Reserva reserva)
        {
            reserva.HabitacionElegida.Disponibilidad = false;
            _reserva.InsertOne(reserva);
            return reserva;
        }

        public string UpdateReserva(string id, Reserva reserva)
        {

            _reserva.ReplaceOne(reserva => reserva.Id == id, reserva);
            return $"Se actualizo la reserva = {reserva.Id}, correctamente";
        }

        public string DeleteReserva(string id)
        {

            _reserva.DeleteOne(d => d.Id == id);
            return $"Se eliminó la reserva con id = {id}, correctamente";
        }
        #endregion

        #region [Usuarios]
        public List<Usuario> GetUsuarios() => _usuario.Find(d => true).ToList();

        public Usuario CreateUsuario(Usuario usuario)
        {
            _usuario.InsertOne(usuario);
            return usuario;
        }

        public string UpdateUsuario(string id, Usuario usuario)
        {

            _usuario.ReplaceOne(usuario => usuario.Id == id, usuario);
            return $"Se actualizo el usuario = {usuario.Id}, correctamente";
        }

        public string DeleteUsuario(string id)
        {

            _usuario.DeleteOne(d => d.Id == id);
            return $"Se eliminó el usuario con id = {id}, correctamente";
        }
        #endregion
    }
}

