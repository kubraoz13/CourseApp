﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool isActive { get; set; } //bool=true false-databaseye 1 ve 0 olarak kaydeder

        //Navigation Properity

        public virtual Instructor Instructor { get; set; }
    }
}
