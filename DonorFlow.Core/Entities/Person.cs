using DonorFlow.Core.Enums;

namespace DonorFlow.Core.Entities
{
    public abstract class Person : BaseEntity
    {
        public string FullName { get; protected set; }
        public string Email { get; protected set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }

        protected Person(string fullName, string email, DateTime birthDate, Gender gender)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
        }

        protected void UpdatePerson(string fullName, string email, DateTime birthDate, Gender gender)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
        }
    }
}
