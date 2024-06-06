namespace MenuLibrary
{
    public class MenuUtilities
    {
        public static string GetHabitModes()
        {
            Console.WriteLine("MAIN MENU\n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("Type 0 to Close Application");
            Console.WriteLine("Type 1 to View All Records");
            Console.WriteLine("Type 2 to Insert Record");
            Console.WriteLine("Type 3 to Delete Record");
            Console.WriteLine("Type 4 to Update Record");
            Console.WriteLine("-------------------------------------------------\n");

            string userResponse = Console.ReadLine();

            while (true)
            {
                switch (userResponse.Trim()[0])
                {
                    case '0':  case '1': case '2': case '3': case '4':
                        Console.WriteLine("\n");
                        return userResponse;
                    default:
                        Console.WriteLine("Response not valid. Make sure the first character is one of the numbers above");
                        userResponse = Console.ReadLine();
                        break;
                } 
            }
        }

        public static string[] GetHabitInputs()
        {
            Console.WriteLine("What's the habit you're going to log?");
            string habit = Console.ReadLine();

            Console.WriteLine("What is the quantity of this habit? (Include number only)");
            string quantity = Console.ReadLine();

            while(!int.TryParse(quantity.Trim(), out int value))
            {
                Console.WriteLine("The quantity you entered is not a number. Try again!");
                quantity = Console.ReadLine();
            }

            string[] result = { habit, quantity };
            return result;
        }

        public static string GetHabitId()
        {
            Console.WriteLine("What habit Id would you like to effect?");
            string habitId = Console.ReadLine();

            while (!int.TryParse(habitId.Trim(), out int value))
            {
                Console.WriteLine("The id you've chosen is not a number. Try again!");
                habitId = Console.ReadLine();
            }
            return habitId;
        }

        
    }
}