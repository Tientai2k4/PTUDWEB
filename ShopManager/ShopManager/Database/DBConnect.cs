using Microsoft.Data.SqlClient;

namespace ShopManager.Database
{
	public class DBConnect
	{
		SqlConnection connect = new SqlConnection(" Data Source=DESKTOP-BFJUK9N\\TIENTAI;Initial Catalog=SportsShop;Integrated Security=True;Trust Server Certificate=True;TrustServerCertificate=False;Encrypt=false ");
		public SqlConnection getConnecttion()
		{
			return connect;
		}
		//create a function to Open connection
		public void openConnection()
		{
			if (connect.State == System.Data.ConnectionState.Closed)
			{
				connect.Open();
			}
		}
		//create a function to Close connection
		public void closeConnection()
		{
			if (connect.State == System.Data.ConnectionState.Open)
			{
				connect.Close();
			}
		}

	}

}