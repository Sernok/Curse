namespace MyProject.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public bool IsManagedByUs { get; set; }
        public bool HasExternalManagementContract { get; set; }
        public int? ExternalManagementCompanyId { get; set; }
        public ExternalManagementCompany? ExternalManagementCompany { get; set; }
    }
}
