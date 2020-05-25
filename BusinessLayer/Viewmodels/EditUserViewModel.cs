﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Viewmodels
{
	public class EditUserViewModel
	{
		public string Id { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}
