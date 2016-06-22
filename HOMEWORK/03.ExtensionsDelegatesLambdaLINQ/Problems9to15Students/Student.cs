namespace Problems9to15
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string facultyNumber;
        private string phoneNumber;
        private string email;
        private List<int> marks;
        private byte groupNumber;

        private EmailValidator emailValidator = new EmailValidator();

        public Student(
            string firstName,
            string lastName,
            string facultyNbr,
            string phoneNbr,
            string email,
            List<int> marks,
            byte groupNumber
            )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNbr;
            this.PhoneNumber = phoneNbr;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
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
                return this.facultyNumber;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) 
                    || value.Length < 6
                    || !Char.IsDigit(value[4])
                    || !Char.IsDigit(value[5]))
                {
                    throw new ArgumentNullException("Faculty number must have minimum 6 symbols with digits as symbols 5 and 6");
                }
                else
                {
                    this.facultyNumber = value;
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

        public List<int> Marks
        {
            get
            {
                return new List<int>(this.marks);               
            }
            private set
            {                
                    this.marks = value;                
            }
        }

        public byte GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            private set
            {                
                    this.groupNumber = value;
            }
            
        }

        public override string ToString()
        {
            return string.Format("First name: {0}\nLast name: {1}\nFaculty number: {2}\n" +
                                 "Group number: {3}\nMarks: {4}\nPhone: {5}\nEmail: {6}",
                this.firstName, this.lastName, this.facultyNumber, this.groupNumber,
                string.Join(", ", this.marks), this.phoneNumber, this.email);
        }

    }
}
