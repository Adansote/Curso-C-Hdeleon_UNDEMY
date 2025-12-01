
using Microsoft.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;  // libreria para los archivos 
//conexcion a la base de datos 
// Cadena de conexión a la base de datos


string connectionString = "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;TrustServerCertificate=true;"; ;

var query = " SELECT * FROM cerveza";

string filePath = @"C:\C#_conexcionBD_tarerinformacion_Excell\info_de_BD_en_excell.xlsx";

try
{

    using (SqlConnection connection = new SqlConnection(connectionString))
	{
		connection.Open();	
		SqlCommand command = new SqlCommand(query, connection);
		SqlDataAdapter adapter = new SqlDataAdapter(command);
		DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);


		//agregar una hoja de calculo 
		using ( var workbook = new XLWorkbook())
		{
			var worksheets = workbook.Worksheets.Add("Info");

			worksheets.Cell(1,1).InsertTable(dataTable);
			workbook.SaveAs(filePath);
		}
	}
}
catch (Exception)
{

	throw;
}