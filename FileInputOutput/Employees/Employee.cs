using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }

        /// <summary>
        /// Default empty constructor for the Employee class
        /// </summary>
        public Employee()
        {
            FirstName = "";
            LastName = string.Empty;
            Email = string.Empty;
            Gender = string.Empty;
            Salary = 0.0;
        }

        /// <summary>
        /// Overloaded constructor taking all of the employees properties
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="gender"></param>
        /// <param name="salary"></param>
        public Employee(string firstName, string lastName, string email, string gender, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Salary = salary;
        }

        /// <summary>
        /// Convert an employee instance to a string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string employeeAsString = $"{FirstName} {LastName} {Gender.ToUpper()[0]} has an email of { Email} and has a salary of {Salary.ToString("C2")}.";

            return employeeAsString;
        }

        /// <summary>
        /// Determines whether or not this instance of Employee makes over a certain amount
        /// </summary>
        /// <param name="amount">The amount you want to see if the employee makes, this value is not inclusive</param>
        /// <returns></returns>
        public bool MakesOverCertainAmount(double amount)
        {
            bool result = false;
            if (Salary > amount)
            {
                result= true;
            }
            //else
            //{
            //    return false;
            //}
            return result;
        }

        /// <summary>
        /// Determines whether the employee has an e-mail from a certain domain.
        /// </summary>
        /// <param name="domain">The domain to check whether or not it is found in the current email.</param>
        /// <returns></returns>
        public bool HasEmailFromDomain(string domain)
        {
            return Email.Contains(domain);
        }
    }
}
