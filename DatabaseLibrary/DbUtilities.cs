using Microsoft.Data.Sqlite;

namespace DatabaseLibrary
{
    public class DbUtilities
    {
        // Creates habits table if it doesn't exist
        // Also creates the "habit-Tracker.db" file if it doesn't exist
        public static void Initiate()
        {
            using (var connection = new SqliteConnection(@"Data Source=habit-Tracker.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS habits(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Habit TEXT,
                        Quantity INTEGER
                        )";

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void ViewAllHabits()
        {
            using (var connection = new SqliteConnection(@"Data Source=habit-Tracker.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT * FROM habits";

                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetString(0);
                        var date = reader.GetString(1);
                        var habit = reader.GetString(2);
                        var quantity = reader.GetString(3);

                        Console.WriteLine($"{id} {date} {habit} {quantity}");
                    }
                    Console.WriteLine("--------------------------------------\n");
                }

                connection.Close();
            }
        }

        public static string[] GetSingleHabit(string habitId)
        {
            using (var connection = new SqliteConnection(@"Data Source=habit-Tracker.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @$"SELECT * FROM habits WHERE Id='{habitId}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            string[] result = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                            return result;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The habit you're trying to find does not exist.");
                            string[] error = { "" };
                            return error;
                        }
                    }
                }
                string[] endError = { "" };
                return endError;
            }
        }

        public static void AddHabit(string habit, int quantity)
        {
            using (var connection = new SqliteConnection(@"Data Source=habit-Tracker.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @$"INSERT INTO habits (Date, Habit, Quantity)
                        VALUES ('{DateTime.Now.ToString("yyyy-MM-dd")}', '{habit}', '{quantity}'
                        )";

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void DeleteHabit(string id)
        {
            using (var connection = new SqliteConnection(@"Data Source=habit-Tracker.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @$"DELETE FROM habits WHERE Id='{id}'";

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void UpdateHabit(string[] habitInformation)
        {
            using (var connection = new SqliteConnection(@"Data Source=habit-Tracker.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    $@"UPDATE habits
                        SET Quantity='{habitInformation[3]}'
                        WHERE Id='{habitInformation[0]}'";

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}