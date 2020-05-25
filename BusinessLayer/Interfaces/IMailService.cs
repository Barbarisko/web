using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
	public interface IMailService
	{
		void SendEmailCustom(string body, string email, string subject);
	}
}
