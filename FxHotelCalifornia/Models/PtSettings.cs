using System;
using FxHotelCalifornia.Interfaces;

namespace FxHotelCalifornia.Models
{
	public class PtSettings : IPtSettings
	{
		public string Server { get; set; }
		public string DataBase { get; set; }
		public string Collection { get; set; }
    }
}

