using PA1;






DriversUtility driversUtility = new DriversUtility();
MainMenu();



void MainMenu()
{
    
    Menu programMenu = new Menu();
    programMenu.DisplayMenu();
    int userInput = programMenu.GetMenuChoice();
    RegisterMenuChoice(userInput);
}



void RegisterMenuChoice(int choice)
{
    switch (choice)
    {
        case 1:
            ShowAllDrivers();
            break;

        case 2:
            AddNewDriver();
            break;

        case 3:
            UpdateDriversRating();
            break;

        case 4:
            FireDriver();
            break;

        case 5:
            ViewMaintenanceDateByMonth();
            break;

        case 6:
            System.Console.WriteLine("Farewell");
            break;



    }

    void ShowAllDrivers()
    {
        try{
        bool valid = false;
        driversUtility.DisplayDrivers();
        System.Console.WriteLine("_______________________________________________________");
        System.Console.WriteLine("1. Sort the drivers by rating.");
        System.Console.WriteLine("2. Sort the driver by hire date");
        System.Console.WriteLine("3. Return to the main menu.");
        Console.Write("Enter your choice: ");
        while (!valid)
        {
            try
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice >= 1 && choice <= 3)
                {
                    valid = true;
                    switch (choice)
                    {
                        case 1:
                            System.Console.WriteLine("Sorted by: Rating");
                            driversUtility.SortDriversByRating();
                            valid = false;
                            System.Console.WriteLine("_______________________________________________________");
                            System.Console.WriteLine("1. Sort the drivers by rating.");
                            System.Console.WriteLine("2. Sort the driver by hire date");
                            System.Console.WriteLine("3. Return to the main menu.");
                            Console.Write("Enter your choice: ");
                            break;

                        case 2:
                            System.Console.WriteLine("Sorted by: Hiring Date");
                            driversUtility.SortDriversByHireDate();
                            valid = false;
                            System.Console.WriteLine("_______________________________________________________");
                            System.Console.WriteLine("1. Sort the drivers by rating.");
                            System.Console.WriteLine("2. Sort the driver by hire date");
                            System.Console.WriteLine("3. Return to the main menu.");
                            Console.Write("Enter your choice: ");
                            break;

                        case 3:
                            System.Console.WriteLine("Returning to the main menu.");
                            MainMenu();
                            break;
                    }
                }


            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                System.Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                valid = false;
            }
        }

        }
        catch (NullReferenceException e)
        {
            System.Console.WriteLine(e.Message);
        }

    }

    void AddNewDriver()
    {
        driversUtility.AddDriver();
        System.Console.WriteLine("Returning to the main menu.");
        MainMenu();
    }

    void UpdateDriversRating()
    {
        driversUtility.UpdateDriversRating();
        MainMenu();
    }

    void FireDriver()
    {
        driversUtility.RemoveDriver();
        MainMenu();

    }

    void ViewMaintenanceDateByMonth()
    {
        driversUtility.ViewMaintenanceDateByMonth();
        MainMenu();
    }


}
