using System.Text;

namespace Parser.Infrastructure.DataAccess.Models
{
    public class ConnectionStringSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
            => new StringBuilder()
                .Append($"Host={Host};")
                .Append($"Port={Port};")
                .Append($"Database={Database};")
                .Append($"Username={Username};")
                .Append($"Password={Password}")
                .ToString();
    }
}
