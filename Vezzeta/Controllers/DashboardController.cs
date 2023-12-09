using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Vezzeta.Data;
using Vezzeta.Models;
using static Vezzeta.Models.DashboardData;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetDashboardData")]
    public async Task<IActionResult> GetDashboardData(int pageSize = 10)
    {
        var dashboardData = new DashboardData();

        dashboardData.NumOfDoctors = await _context.Doctors.CountAsync();
        dashboardData.NumOfPatients = await _context.Patients.CountAsync();
        dashboardData.NumOfRequests = await _context.Requests.CountAsync();
        dashboardData.NumOfPendingRequests = await _context.Requests.CountAsync(r => r.Status == RequestStatus.Pending);
        dashboardData.NumOfCompletedRequests = await _context.Requests.CountAsync(r => r.Status == RequestStatus.Completed);
        dashboardData.NumOfCancelledRequests = await _context.Requests.CountAsync(r => r.Status == RequestStatus.Cancelled);

        dashboardData.Top5Specializations = await _context.Specializations
            .OrderByDescending(s => s.NumberOfRequests)
            .Take(5)
            .Select(s => new { s.FullName, s.NumberOfRequests })
            .ToListAsync();

        dashboardData.Top10Doctors = await _context.Doctors
            .OrderByDescending(d => d.NumberOfRequests)
            .Take(10)
            .Select(d => new { d.Image, d.FullName, d.Specialize, d.NumberOfRequests })
            .ToListAsync();

        return Ok(dashboardData);
    }
}