using System;
namespace FxHotelCalifornia.Interfaces
{
	public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);       
    }
}

