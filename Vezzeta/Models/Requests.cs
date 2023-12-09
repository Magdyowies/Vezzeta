namespace Vezzeta.Models
{
    public enum RequestStatus
    {
        Pending,
        Completed,
        Cancelled
    }

    public class Request
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public decimal Price { get; set; }
        public string DiscountCode { get; set; }
        public decimal FinalPrice { get; set; }
        public RequestStatus Status { get; set; }
    }
}