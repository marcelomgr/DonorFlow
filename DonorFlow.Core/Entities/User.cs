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

        public User(string fullName, string cpf, string password, string email, DateTime birthDate, Gender gender, UserRole role)
            : base(fullName, email, birthDate, gender)
        {
            CPF = NormalizeCPF(cpf);
            Password = HashPassword(password);
            Status = UserStatus.Active;
            Role = role;
        }

        public void Update(string fullName, string cpf, string email, string password, DateTime birthDate, Gender gender, UserRole role, LocationInfo location)
        {
            CPF = NormalizeCPF(cpf);
            Email = email;
            Password = password;

            Role = role;
            Location = location;

            UpdatePerson(fullName, email, birthDate, gender);
        }

        public void SetLocation(LocationInfo location)
        {
            Location = location;
        }

        public void ResetPassword(string password)
        {
            Password = HashPassword(password);
        }

        public static string NormalizeCPF(string cpf)
        {
            return cpf.Trim().Replace(".", "").Replace("-", "");
        }

        public void Inactive()
        {
            Status = UserStatus.Inactive;
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
