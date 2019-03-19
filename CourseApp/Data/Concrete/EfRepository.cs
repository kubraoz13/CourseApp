﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class  EfRepository:IRepository
    {
        private DataContext context; 
        public EfRepository(DataContext _context)
        {
            context = _context; 
        }
        //databaseye bağlantı yaptık yukarıdakilerle.

           // IRepository kısmına ctrl+. ile ilk çıkanı seçtik alttakiler geldi.
        public IEnumerable<Request> Requests => context.Requests;

        public IEnumerable<Course> Courses => context.Courses;
        
    }
}
