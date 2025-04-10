using System;
using System.Data;
using System.Data.OleDb;


namespace ConDbLib
{
	public class CDB
	{
		OleDbConnection objCon;
		OleDbCommand objCmd;
		OleDbDataAdapter objAd;
        string constring = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SAN;Data Source=.";
		string strError;
		public CDB()
		{
			objCon =new OleDbConnection();
			objCmd = new OleDbCommand();
			objAd= new OleDbDataAdapter();
			objCon.ConnectionString = constring;
		}
		public void OpenConnection()
		{
			try
			{
				objCon.Open();
				objCmd.Connection = objCon;
			}
			catch(Exception e)
			{
				strError = e.ToString();
			}
		}
		public void nonselectquery(string strQ)
		{
			try
			{
				objCmd.CommandText = strQ;
				objCmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				strError = e.ToString();
			}
		}
		public DataTable getRecord(string strQ)
		{
			DataSet ds = new DataSet();
			DataTable dt = null;
			try
			{				
				objCmd.CommandText = strQ;
				objAd.SelectCommand=objCmd;
				objAd.Fill(ds);
				dt = ds.Tables[0];
			}
			catch(Exception e)
			{
				strError = e.ToString();
			}
			return dt;
		}
		public void close()
		{
			objCon.Close();
		}
		public string Error
		{
			get
			{
				return strError;
			}
		}
	
	}
	
}
