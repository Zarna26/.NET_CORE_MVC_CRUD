﻿namespace StudentPortal.Models.Entites
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Subscribe { get; set; }
    }
}
