﻿namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string Phone { get; set; }
        public required decimal Salary { get; set; }
    }
}
