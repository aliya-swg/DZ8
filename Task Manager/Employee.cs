using System;


namespace Task_Manager
{
    public abstract class Employee
    {
        public string name;

        protected Employee(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }
}
