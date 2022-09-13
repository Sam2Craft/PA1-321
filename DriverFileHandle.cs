using Newtonsoft.Json;

namespace PA1
{
    public class DriverFileHandle
    {
        public List<Driver> driversList;

        public DriverFileHandle()
        {
            GetAllDrivers();
        }

        private void GetAllDrivers()
        {
            try
            {
                string json = File.ReadAllText("drivers.txt");
                driversList = JsonConvert.DeserializeObject<List<Driver>>(json);

            }

            catch (FileNotFoundException e)
            {
                System.Console.WriteLine("File not found, creating new file");
                File.Create(e.FileName);
            }

        }

        public void SaveAllDrivers()
        {
            string json = JsonConvert.SerializeObject(driversList);
            File.WriteAllText("drivers.txt", json);
        }
    }
}