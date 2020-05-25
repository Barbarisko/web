using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
	public class AppUser : IdentityUser
	{
		public string City { get; set; }
		public string Country { get; set; }
	}
}
