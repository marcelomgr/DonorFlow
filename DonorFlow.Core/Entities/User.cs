using System.Text;
using DonorFlow.Core.Enums;
using DonorFlow.Core.ValueObjects;
using System.Security.Cryptography;

namespace DonorFlow.Core.Entities
{
    public class User : Person
    {
        private User() : base("DefaultName", "DefaultEmail@example.com", DateTime.MinValue, Gender.Male)
        {
            CPF = string.Empty;
            Password = string.Empty;
            Status = UserStatus.Inactive;
            Role = UserRole.Basic;
        }

        public string CPF { get; private set; }
        public string Password { get; private set; }
        public UserStatus Status { get; private set; }
        public UserRole Role { get; private set; }
        public LocationInfo? Location { get; private set; }

        public User(string fullName, string cpf, string password, string email, DateTime birthDate, Gender gender, string role)
            : base(fullName, email, birthDate, gender)
        {
            CPF = NormalizeCPF(cpf);
            Password = HashPassword(password);
            Status = UserStatus.Active;

            if (Enum.TryParse<UserRole>(role, out UserRole parsedRole))
                Role = parsedRole;
            else
                Role = UserRole.Basic;
        }

        public void Update(string fullName, string cpf, string password, string email, UserRole role, LocationInfo location)
        {
            FullName = fullName;
            CPF = NormalizeCPF(cpf);
            Password = HashPassword(password);
            Email = email;
            Role = role;
            Location = location;
        }

        public void SetLocation(LocationInfo location)
        {
            Location = location;
        }

        public void SetPassword()
        {
            Password = HashPassword(Password);
        }

        public static string NormalizeCPF(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
