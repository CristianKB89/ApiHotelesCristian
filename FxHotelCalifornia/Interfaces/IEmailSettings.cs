using System;
namespace FxHotelCalifornia.Interfaces
{
	public interface IEmailSettings
	{
        string SmtpServer { get; set; }
        int SmtpPort { get; set; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
        string SenderEmail { get; set; }
        string SenderName { get; set; }
    }
}

