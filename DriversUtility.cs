

namespace PA1
{
    public class DriversUtility
    {
        //removed static, could be issue

        public List<Driver> driversList;  //possible issue with static
        private DriverFileHandle driverFileHandler = new DriverFileHandle();

        public DriversUtility()
        {
            driversList = driverFileHandler.driversList;
        }

        public void DisplayDrivers()
        {
            foreach (Driver driver in driversList)
            {
                Console.WriteLine($"NAME:{driver.name}  ID:{driver.EmployeeID}  DATEHIRED:{driver.dateOfHire}   RATING:{driver.rating}  VEHICLEID:{driver.vehicle.vehicleID}    VEHICLEMODEL:{driver.vehicle.model}     VEHICLEMAINTENANCEDATE:{driver.vehicle.maintenanceDate.Month}");
            }
        }
        public void SortDriversByRating()
        {
            driversList.Sort((x, y) => y.rating.CompareTo(x.rating));
            DisplayDrivers();
        }

        public void SortDriversByHireDate()
        {
            driversList.Sort((x, y) => y.dateOfHire.CompareTo(x.dateOfHire));
            DisplayDrivers();

        }

        public void AddDriver() // fix this method
        {
            System.Console.WriteLine("Add a new driver to our employee list, type 'finish' to exit");
            string userInput = "";
            while (userInput != "finish")
            {
                driversList.Add(new Driver() { name = "", rating = 0.0 });
                System.Console.Write("Enter the drivers name:");
                userInput = Console.ReadLine();
                driversList[driversList.Count - 1].name = userInput;
                System.Console.Write("Enter the drivers rating (double of '0.0'):");
                userInput = Console.ReadLine();
                driversList[driversList.Count - 1].rating = double.Parse(userInput);
                SaveAllDrivers();
                System.Console.WriteLine("Driver added, type 'finish' to exit, to continue adding drivers type anything else");
                userInput = Console.ReadLine();
            }
        }

        public void UpdateDriversRating() // still need handler if not found 
        {
            DisplayDrivers();
            System.Console.WriteLine("Enter the EmployeeID (int) of the driver who's rating you wish to change :");
            string userInput = Console.ReadLine();
            bool found = false;
            foreach (Driver driver in driversList)
            {
                if (userInput == driver.EmployeeID)
                {
                    System.Console.WriteLine("Enter the drivers new rating (double of '0.0'):");
                    driver.rating = double.Parse(Console.ReadLine());
                    SaveAllDrivers();
                    System.Console.WriteLine("Driver rating updated");
                    System.Console.WriteLine("Press any key to return to the main menu");
                    Console.ReadKey();
                    found = true;

                }



            }
            if (!found)
            {
                System.Console.WriteLine("Driver not found");
                System.Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
            }


        }

        public void RemoveDriver()  //need handler for driver not found 
        {
            DisplayDrivers();
            System.Console.WriteLine("Enter the EmployeeID (int) of the driver you wish to remove :");
            bool found = false;
            string userInput = Console.ReadLine();
            foreach (Driver driver in driversList)
            {
                if (userInput == driver.EmployeeID)
                {
                    driversList.Remove(driver);
                    SaveAllDrivers();
                    System.Console.WriteLine("Driver removed");
                    found = true;

                }
            }
            if (!found)
            {
                System.Console.WriteLine("Driver not found");
            }
            System.Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();

        }

        public void ViewMaintenanceDateByMonth() 
        {
            System.Console.WriteLine("Enter the interger value of the month you wish to view:");
            bool found = false;
            int userInput = int.Parse(Console.ReadLine());
            int yearCount = 0;
            int count = 0;
            List<Driver> driversListCopy = new List<Driver>(driversList);
            driversListCopy.Sort((x, y) => x.vehicle.maintenanceDate.Year.CompareTo(y.vehicle.maintenanceDate.Year));
            System.Console.WriteLine($"Here are the vehicles that need maintenance in the {userInput} month of the year:");
            foreach (Driver driver in driversListCopy)
            {
            try{
                if (userInput == driver.vehicle.maintenanceDate.Month && !driversListCopy[count].vehicle.maintenanceDate.Year.Equals(driversListCopy[count + 1].vehicle.maintenanceDate.Year))
                {
                    System.Console.WriteLine($"Vehicle ID: {driver.vehicle.vehicleID}   Model: {driver.vehicle.model}    Maintenance Date: {driver.vehicle.maintenanceDate}");
                    yearCount++;
                    System.Console.WriteLine($"There are {yearCount} vehicles due for maintenance in month {userInput} of {driversListCopy[count ].vehicle.maintenanceDate.Year}");
                    yearCount = 0;
                    //yearCount++;
                 

                }

                else if (userInput == driver.vehicle.maintenanceDate.Month && driversListCopy[count].vehicle.maintenanceDate.Year.Equals(driversListCopy[count + 1].vehicle.maintenanceDate.Year))
                {
                    System.Console.WriteLine($"Vehicle ID: {driver.vehicle.vehicleID}   Model: {driver.vehicle.model}    Maintenance Date: {driver.vehicle.maintenanceDate}");
                    yearCount++;
                    found = true;
                   
                }
                count++;
            }
           
            catch(System.ArgumentOutOfRangeException)
            {
                System.Console.WriteLine($"Vehicle ID: {driver.vehicle.vehicleID}   Model: {driver.vehicle.model}    Maintenance Date: {driver.vehicle.maintenanceDate}");
                yearCount++;
                System.Console.WriteLine($"There are {yearCount} vehicles due for maintenance in month {userInput} of {driversListCopy[count ].vehicle.maintenanceDate.Year}");
                yearCount = 0;
            }
            
               

            }
            if (!found)
            {
                System.Console.WriteLine("No vehicles need maintenance in that month");
            }
            
            System.Console.WriteLine("__________________________________________________________");
            System.Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

        }

        private void SaveAllDrivers()
        {
            driverFileHandler.SaveAllDrivers();
        }

       


    }



}
