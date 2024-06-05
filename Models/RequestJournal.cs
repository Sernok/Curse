namespace MyProject.Models
{
    public class RequestJournal
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; } // Добавленное свойство
        public string ApartmentNumber { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ProblemDescription { get; set; }
        public string Notes { get; set; }
        public int RequestStatusId { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }
        public bool IsUrgent { get; set; }
        public bool RequiresClientPresence { get; set; }
        public int ExecutorId { get; set; }
        public Executor Executor { get; set; }
        //public int EmployeeId { get; set; } // Добавленное свойство
    }
}
