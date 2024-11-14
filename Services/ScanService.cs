using onepathapi.Data;
using onepathapi.Models;
using Microsoft.EntityFrameworkCore;

namespace onepathapi.Services
{
    public interface IScanService
    {
        object GetUserScans(string userId);
        string UploadScan();
    }

    public class ScanService : IScanService
    {

        private readonly ApplicationDbContext _context;

        public ScanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public object GetUserScans(string userId)
        {
            return new[]
            {
                new { ScanId = "S1", Type = "MRI", Date = "2024-10-01", Result = "Normal" },
                new { ScanId = "S2", Type = "X-Ray", Date = "2024-10-05", Result = "Minor fracture" }
            };
        }

        public string UploadScan()
        {
            return "Scan uploaded successfully!";
        }
    }
}
