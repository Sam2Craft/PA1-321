

namespace PA1
{
    public class Driver
    {

        public string name { get; set; }
        public string EmployeeID { get; set; }
        public DateTime dateOfHire { get; set; }
        public double rating { get; set; }

        public Vehicle vehicle { get; set; }

        public Driver()
        {
            this.vehicle = new Vehicle();
            {
                this.vehicle.model = "BMW Sedan";
                this.vehicle.maintenanceDate = DateTime.Now.AddMonths(6);
                this.vehicle.vehicleID = Guid.NewGuid().ToString();
            }
            this.dateOfHire = DateTime.Now;
            this.EmployeeID = Guid.NewGuid().ToString();
        }


    }
}