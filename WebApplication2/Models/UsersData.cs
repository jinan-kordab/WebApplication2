using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
	public class UsersData
	{
		public string userID;
		public string FullName;
		public string GivenName;
		public string FamilyName;
		public string Email;
		public string GoogleToken;

		public List<string> userIDS = new List<string>();
	}
}