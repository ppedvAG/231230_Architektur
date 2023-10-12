using Microsoft.Data.Sqlite;
using System.Data.Common;

Console.WriteLine("Hello,Factory!");

string conStringSQL = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";
string conStringSQLITE = @"Data Source=C:\DB\Northwind.sqlite";

DbProviderFactory factory = null;
string conString = "";


if ("SQL" != "SQL")
{
    factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
    conString = conStringSQL;
}
else
{
    factory = Microsoft.Data.Sqlite.SqliteFactory.Instance;
    conString = conStringSQLITE;
}


DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();
Console.WriteLine("DB open");

DbCommand sqlCommand = factory.CreateCommand();
sqlCommand.Connection = con;
sqlCommand.CommandText = "SELECT COUNT(*) FROM Employees";

var rowCount = sqlCommand.ExecuteScalar();
Console.WriteLine($"{rowCount} Employees in DB");