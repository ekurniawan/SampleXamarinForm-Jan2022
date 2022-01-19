namespace BackendServices.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public int? EmployeeId { get; set; }
    }
}
