using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary
{
    public enum EPersonMaritalStatus
    {
        Married,
        Single
    }

    [Serializable]
    public class Person
    {
        public string Name;
        public string LastName;
        public int Age;
        public EPersonMaritalStatus MaritalStatus;

        public Person(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            MaritalStatus = EPersonMaritalStatus.Single;
        }

        public string GetInfoToString()
        {
            return $"Имя: {Name}\n" +
                $"Фамилия: {LastName}\n" +
                $"Возраст: {Age}";
        }
    }

    public class Employee : Person
    {
        public string Position;
        public decimal Salary;

        public Employee(string name, string lastName, int age,
            string position, decimal salary) : 
            base(name, lastName, age) 
        {
            Position = position;
            Salary = salary;
        }
    }
}
