using System;

namespace WebService.Dtos
{
    public class MessageDto
    {
        public string Content { get; set; }

        public string DotnetVersion { get; set; } = $"{Environment.Version}";

        public DateTime UtcNow { get; set; } = DateTime.UtcNow;
    }
}
