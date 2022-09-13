namespace PA1
{

    public class Menu
    {
        //this is the method that will display the menu options to the user
        public void DisplayMenu()
        {
            Console.WriteLine("1. Show and Sort all drivers");
            Console.WriteLine("2. Hire a new driver ");
            Console.WriteLine("3. Update a driver's rating");
            Console.WriteLine("4. Fire a driver (by employee ID)");
            Console.WriteLine("5. View maintenance date by month");
            Console.WriteLine("6. Exit");

        }

        //this is the method that will get the user's input and return it to the main method
        public int GetMenuChoice()
        {
            int choice = 0;
            bool valid = false;
            while (!valid)
            {
                Console.Write("Enter your choice: ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice >= 1 && choice <= 6)
                    {
                        valid = true;
                    }
                    else
                    {
                        System.Console.WriteLine("____________________________________________");
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                        System.Console.WriteLine("____________________________________________");

                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("____________________________________________");
                    System.Console.WriteLine(e.Message);
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                    System.Console.WriteLine("____________________________________________");
                    valid = false;
                }
            }
            return choice;
        }



    }
}