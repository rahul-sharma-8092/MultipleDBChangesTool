namespace ProductX.Models
{
    public class Script
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? ScriptFile { get; set; }
        public string? PhysicalPath { get; set; }
        public string? Serverpath { get; set; }
        public string? Query { get; set; }
        public DateTime CreatedAT { get; set; }
    }

    public class Database
    {
        public int DBId { get; set; }
        public string? ServerName { get; set; }
        public string? DBName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int AuthType { get; set; } = 1; // SQL Server Authentication = 1
        public bool IsAuthenticated { get; set; }
    }
}
