namespace Vezzeta.Models
{
    
        public class DashboardData
        {
            public int NumOfDoctors { get; set; }
            public int NumOfPatients { get; set; }
            public int NumOfRequests { get; set; }
            public int NumOfPendingRequests { get; set; }
            public int NumOfCompletedRequests { get; set; }
            public int NumOfCancelledRequests { get; set; }
        public List<TopSpecialization> Top5Specializations { get; set; }
        public List<Doctor> Top10Doctors { get; set; }
        }
    
}
