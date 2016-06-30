namespace Problem1StudentClass
{

    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Student :ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string sSNumber;
        private string permanentAddress;
        private string phoneNumber;
        private string email;
        private string course;
        private Faculties faculty;
        private Specialties specialty;
        private Universities university;


        private EmailValidator emailValidator = new EmailValidator();

        public Student(
            string firstName,
            string middleName,
            string lastName,
            string sSN,
            string address,
            string phoneNbr,
            string email,
            string course,
            Faculties faculty,
            Specialties specialty,
            Universities university

            )
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.FacultyNumber = sSN;
            this.PhoneNumber = phoneNbr;
            this.Email = email;
            this.PermanentAddress = address;
            this.Course = course;
            this.Faculty = faculty;
            this.Specialty = specialty;
            this.University = university;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Middle name cannot be null or empty");
                }
                else
                {
                    this.middleName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or empty");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string FacultyNumber
        {
            get
            {
                return this.sSNumber;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) 
                    || value.Length < 6
                    )
                {
                    throw new ArgumentNullException("SS Number must have minimum 6 symbols");
                }
                else
                {
                    this.sSNumber = value;
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            private set
            {
                //checking symbols after the first if they are digits only
                bool isDigit = true;
                for (int i = 1; i < value.Length; i++)
                {
                    if (!Char.IsDigit(value[i]))
                    {
                        isDigit = false;
                    }
                }

                if (String.IsNullOrEmpty(value)
                    || value.Length < 9
                    || isDigit == false
                    || (value[0] != '+' && value[0] != '0'))
                {
                    throw new ArgumentNullException("Phone number must have minimum 9 digits, no spaces, and start with 0 or +359");
                }
                else
                {
                    this.phoneNumber = value;
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            private set
            {
                if (!emailValidator.IsValidEmail(value))
                {
                    throw new ArgumentNullException("This is not a valid e-mail address!");
                }
                else
                {
                    this.email = value;
                }
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            private set
            {
                if (String.IsNullOrEmpty(value)
                    || value.Length < 6
                    )
                {
                    throw new ArgumentNullException("Permanent address must have minimum 6 symbols");
                }
                else
                {
                    this.permanentAddress = value;
                }
            }
        }

        public string Course
        {
            get
            {
                return this.course;               
            }
            private set
            {                
                    this.course = value;                
            }
        }

        public Faculties Faculty { get { return this.faculty; } private set { this.faculty = value; } }
        public Specialties Specialty { get { return this.specialty; } private set { this.specialty = value; } }
        public Universities University { get { return this.university; } private set { this.university = value; } }


        public override bool Equals(object param) 
        {
            // If the cast is invalid, the result will be null
            Student student = param as Student;
            // Check if we have valid not null Student object
            if (student == null)
                return false;
            // Compare the reference type member fields
            if (    (!Object.Equals(this.FirstName, student.FirstName))
                || (!Object.Equals(this.MiddleName, student.MiddleName))
                || (!Object.Equals(this.LastName, student.LastName))
                || (!Object.Equals(this.FacultyNumber, student.FacultyNumber))
                || (!Object.Equals(this.PhoneNumber, student.PhoneNumber))
                || (!Object.Equals(this.Email, student.Email))
                || (!Object.Equals(this.PermanentAddress, student.permanentAddress))
                || (!Object.Equals(this.Course, student.Course))
                || (!Object.Equals(this.Faculty, student.Faculty))
                || (!Object.Equals(this.Specialty, student.Specialty))
                || (!Object.Equals(this.University, student.University)))
                return false;            
            return true;
        }

        public static bool operator ==(Student student1,
                                  Student student2)
        {
            return Student.Equals(student1, student2);
        }
        public static bool operator !=(Student student1,
                           Student student2)
        {
            return !(Student.Equals(student1, student2));
        }
        public override int GetHashCode()
        {
            return (FirstName.GetHashCode() ^ Email.GetHashCode()) * LastName.GetHashCode() ; // For example...
        }

        public override string ToString()
        {
            return string.Format("First name: {0}\nMiddle name: {1}\nLast Name: {2}\n", this.FirstName, this.MiddleName, this.LastName) 
                + string.Format("SSN: {0}\nPhone: {1}\nEmail: {2}\nAddress: {3}\nCourse: {4}",this.FacultyNumber,
                this.PhoneNumber, this.Email, this.PermanentAddress, this.Course)
                +string.Format("\nFaculty: {0}\nSpecialty:{1}\nUniversity:{2}", this.Faculty, this.Specialty, this.University);
                
        }

        public object Clone()
        {
            object output;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(stream, this);
                stream.Position = 0;
                output = formatter.Deserialize(stream);

                stream.Close();
            }

            return output;
        }

        public int CompareTo(Student other)
        {
            var comapre = new[]
            {
                "FirstName",
                "LastName",
                "MiddleName",
                "SSN"
            };

            var len = comapre.Length;
            for (int i = 0; i < len; i++)
            {
                var property = this.GetType().GetProperty(comapre[i]);

                var valueThis = property.GetValue(this);
                var strThis = valueThis == null ?
                            string.Empty : valueThis.ToString();

                var valueOther = property.GetValue(other);
                var strOther = valueOther == null ?
                            string.Empty : valueOther.ToString();

                var result = strThis.CompareTo(strOther);

                if (result != 0) return -result;
            }

            return 0;
        }
    }

}

