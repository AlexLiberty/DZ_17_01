using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

string connectionString = "";

GetConnectionString();

void GetConnectionString()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        IConfiguration configuration = builder.Build();
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

//1
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    int mountainID = 1;
//    DateTime startDate = DateTime.Now;
//    DateTime endDate = DateTime.Now.AddDays(400);

//    using (SqlCommand command = new SqlCommand("AddExpedition", connection))
//    {
//        command.CommandType = System.Data.CommandType.StoredProcedure;

//        command.Parameters.AddWithValue("@MountainID", mountainID);
//        command.Parameters.AddWithValue("@StartDate", startDate);
//        command.Parameters.AddWithValue("@EndDate", endDate);

//        command.ExecuteNonQuery();
//    }

//    connection.Close();
//}


//2
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    int expeditionID = 1;
//    int mountainID = 2;
//    DateTime startDate = DateTime.Now.AddDays(10);
//    DateTime endDate = DateTime.Now.AddDays(410);

//    using (SqlCommand updateCommand = new SqlCommand("UpdateExpedition", connection))
//    {
//        updateCommand.CommandType = System.Data.CommandType.StoredProcedure;

//        updateCommand.Parameters.AddWithValue("@ExpeditionID", expeditionID);
//        updateCommand.Parameters.AddWithValue("@MountainID", mountainID);
//        updateCommand.Parameters.AddWithValue("@StartDate", startDate);
//        updateCommand.Parameters.AddWithValue("@EndDate", endDate);

//        updateCommand.ExecuteNonQuery();
//    }

//    connection.Close();
//}

//3
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();
//    int expeditionIDToDelete = 1;

//    using (SqlCommand deleteCommand = new SqlCommand("DeleteExpedition", connection))
//    {
//        deleteCommand.CommandType = System.Data.CommandType.StoredProcedure;

//        deleteCommand.Parameters.AddWithValue("@ExpeditionID", expeditionIDToDelete);

//        deleteCommand.ExecuteNonQuery();
//    }

//    connection.Close();
//}

//4
//
//5

//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    using (SqlCommand addSummitCommand = new SqlCommand("AddSummit", connection))
//    {
//        addSummitCommand.CommandType = System.Data.CommandType.StoredProcedure;

//        addSummitCommand.Parameters.AddWithValue("@Name", "Тест");
//        addSummitCommand.Parameters.AddWithValue("@Height", 9999);
//        addSummitCommand.Parameters.AddWithValue("@Country", "Тест");
//        addSummitCommand.Parameters.AddWithValue("@Region", "TEST");

//        addSummitCommand.ExecuteNonQuery();
//    }
//}

//6
//try
//{
//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        connection.Open();

//        using (SqlCommand updateSummitCommand = new SqlCommand("UpdateSummit", connection))
//        {
//            updateSummitCommand.CommandType = System.Data.CommandType.StoredProcedure;
//            updateSummitCommand.Parameters.AddWithValue("@MountainID", 3);
//            updateSummitCommand.Parameters.AddWithValue("@Height", 3000);
//            updateSummitCommand.Parameters.AddWithValue("@Country", "NewCountry");
//            updateSummitCommand.Parameters.AddWithValue("@Region", "NewRegion");

//            updateSummitCommand.ExecuteNonQuery();
//        }
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}

//7
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    using (SqlCommand command = new SqlCommand("GetClimbersInDateRange", connection))
//    {
//        command.CommandType = System.Data.CommandType.StoredProcedure;
//        command.Parameters.AddWithValue("@StartDate", DateTime.Parse("2020-01-01"));
//        command.Parameters.AddWithValue("@EndDate", DateTime.Parse("2027-02-01")); 

//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                int climberID = reader.GetInt32(0);
//                string climberName = reader.GetString(1);
//                int expeditionID = reader.GetInt32(2);
//                DateTime startDate = reader.GetDateTime(3);
//                DateTime endDate = reader.GetDateTime(4);

//                Console.WriteLine($"ClimberID: {climberID}, Name: {climberName}, ExpeditionID: {expeditionID}, StartDate: {startDate}, EndDate: {endDate}");
//            }
//        }
//    }

//    connection.Close();
//}

//8
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    connection.Open();

//    using (SqlCommand command = new SqlCommand("AddClimberToGroup", connection))
//    {
//        command.CommandType = System.Data.CommandType.StoredProcedure;
//        command.Parameters.AddWithValue("@Name", "ТЕСТ");
//        command.Parameters.AddWithValue("@Address", "ТЕСТ");

//        command.ExecuteNonQuery();

//        Console.WriteLine("Climber added successfully.");
//    }

//    connection.Close();
//}

//9
using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();

    using (SqlCommand command = new SqlCommand("GetClimberExpeditionCount", connection))
    {
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ClimberID", 1);

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string mountainName = reader.GetString(0);
                int expeditionCount = reader.GetInt32(1);

                Console.WriteLine($"MountainName: {mountainName}, ExpeditionCount: {expeditionCount}");
            }
        }
    }

    connection.Close();
}



static void ExecuteNonQuery(SqlConnection connection, string query)
{
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        command.ExecuteNonQuery();
    }
}