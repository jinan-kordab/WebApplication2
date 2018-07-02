using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		[WebMethod]
		public static string BindDatatable(string uniqueUserID,string fullName, string givenName, string familyName, string email, string googleToken)
		{
			string ConnectionIDUpdated = "false";
			
			using (var db = new WebApplication2.MyEntityFramework.MySignalRUsersEntities())
			{
				var userDataRecord = (from c in db.UsersTemp
								  where (c.UniqueUserID == uniqueUserID)
								  select c).SingleOrDefault();

				if (userDataRecord != null)
				{
					userDataRecord.FullName = fullName;
					userDataRecord.GivenName = givenName;
					userDataRecord.FamilyName = familyName;
					userDataRecord.Email = email;
					userDataRecord.GoogleToken = googleToken;

					db.SaveChanges();

					ConnectionIDUpdated = "true";
				}
			}
			return ConnectionIDUpdated;
		}
	}
}