namespace onepathapi.Services
{
    public interface IScanService
    {
        object GetUserScans(string userId);
        string UploadScan();
    }

    public class ScanService : IScanService
    {
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
