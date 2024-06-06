using Microsoft.Data.Sqlite;
using DatabaseLibrary;
using MenuLibrary;

DatabaseLibrary.DbUtilities.Initiate();
string userResponse;

while (true)
{
    userResponse = MenuLibrary.MenuUtilities.GetHabitModes();
    string habitId;

    switch (userResponse.Trim()[0])
    {
        case '0':
            Environment.Exit(1);
            break;

        case '1':
            DatabaseLibrary.DbUtilities.ViewAllHabits();
            break;

        case '2':
            string[] habitToAdd = MenuLibrary.MenuUtilities.GetHabitInputs();
            DatabaseLibrary.DbUtilities.AddHabit(habitToAdd[0], int.Parse(habitToAdd[1]));
            break;

        case '3':
            habitId = MenuLibrary.MenuUtilities.GetHabitId();
            DatabaseLibrary.DbUtilities.DeleteHabit(habitId);
            break;

        case '4':
            habitId = MenuLibrary.MenuUtilities.GetHabitId();
            string[] habitInformation = DatabaseLibrary.DbUtilities.GetSingleHabit(habitId);

            if (habitInformation[0] != "" && habitInformation[1] != "")
            {
                Console.WriteLine($"Change the quantity for {habitInformation[2]}. Press enter with no text to not change anything.");
                userResponse = Console.ReadLine();

                while (!int.TryParse(userResponse, out int value))
                {
                    if (userResponse == "")
                    {
                        break;
                    }
                    Console.WriteLine("The value was not a number, try again");
                    userResponse = Console.ReadLine();
                }

                habitInformation[3] = userResponse;

                DatabaseLibrary.DbUtilities.UpdateHabit(habitInformation);

                Console.WriteLine("Updated!");
            }

            break;
    }
}
