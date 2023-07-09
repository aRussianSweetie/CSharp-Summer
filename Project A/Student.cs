using System;

namespace ProjectA
{
    public class Student : IEquatable<Student>
    {
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _group;
        private string _course;

// "??" используется, только если null выдается в качестве value
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string MiddleName
        {
            get => _middleName;
            set => _middleName = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Group
        {
            get => _group;
            set => _group = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Course
        {
            get => _course;
            set => _course = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int CourseNumber
        {
            get
            {
                var groupParts = Group.Split('-');
                if (groupParts.Length != 3)
                    throw new FormatException("Неверный формат учебной группы");

                if (!int.TryParse(groupParts[2], out int admissionYear))
                    throw new FormatException("Неверный формат учебной группы");

                int currentYear = 23;
                int courseNumber = currentYear - admissionYear;

                return courseNumber;
            }
        }

        public Student(string firstName, string lastName, string middleName, string group, string course)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Group = group;
            Course = course;

            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;
            _group = group;
            _course = course;
        }

// "object?" - то же самое, что и Nullable<object>, может занулливаться, вообщем
        public override bool Equals(object? obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student? other)
        {
            return other != null &&
                   FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   MiddleName == other.MiddleName &&
                   Group == other.Group &&
                   Course == other.Course;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, MiddleName, Group, Course);
        }

// то же само, что и f-строки в питоне
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, группа {Group}, курс {CourseNumber}, выбранный курс: {Course}";
        }
    }
}
