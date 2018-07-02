using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
	public partial class Admin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			WebApplication2.Models.UsersData uData = new WebApplication2.Models.UsersData();

			using (var db = new WebApplication2.MyEntityFramework.MySignalRUsersEntities())
			{
				var userIDsList = (from c in db.UsersTemp
								   select new Models.UsersData() { userID = c.UniqueUserID, FullName=c.FullName, GivenName=c.GivenName,FamilyName=c.FamilyName,Email=c.Email,GoogleToken=c.GoogleToken }).ToList();

				
				foreach (var id in userIDsList)
				{
					if (id.FullName != null)
					{
						uData.userIDS.Add(id.userID.ToString() + "|" + id.FullName.ToString());
					}
					else
					{
						uData.userIDS.Add(id.userID.ToString());
					}
				}
			}

			allLoggedInUsers.Items.Clear();
			for (int i = 0; i < uData.userIDS.Count; i++)
			{
				allLoggedInUsers.Items.Add(new ListItem(uData.userIDS[i].ToString()));
			}
			
		}
	}
}