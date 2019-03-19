using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public static class SeedDatabase
    //eğer bekleyen migrations işlemleri yoksa aşağıdakileri kontrol ediyor.
    //databasemizde sıralama işlemi yapıyor.eğer bu tabloların işi boşsa Courses daki bilgiler varsa yükleme yapmıyor.yoksa aşağıdaki yazılanları alıyor.
    {
        public static void Seed(DbContext context)
        {
            //if (context.Database.GetPendingMigrations().Count() == 0)
            //getpendingmigrations=Databse oluşturulmuş fakat içine veri aktarılmamış dışarıdan boş kayıtları alıyor.
            if (!context.Database.GetPendingMigrations().Any())  //sırada bekleyen bir migrations yoksa devam et demek. üstteki kod ise bunun alternatifi.
            {
                if (context is DataContext)
                {
                    DataContext _context = context as DataContext;
                    if (_context.Courses.Count() == 0)
                    {
                        _context.Courses.AddRange(Courses);
                    }
                    if (_context.Instructors.Count() == 0)
                    {
                        _context.Instructors.AddRange(Instructors);
                    }

                }
                if (context is UserContext)
                {
                    UserContext _context = context as UserContext;
                    if (_context.Users.Count() == 0)
                    {
                        _context.Users.AddRange(Users);
                    }
                }
                context.SaveChanges();
            }
        }

        private static Course[] Courses
        {
            get
            {
                Course[] course = new Course[]
                {
                    new Course(){Name="Html",Price=10,Description="about Html",isActive=true,Instructor=Instructors[0] },
            new Course() { Name = "Css", Price = 10, Description = "about Css", isActive = true, Instructor = Instructors[1] },
            new Course() { Name = "JavaScript", Price = 20, Description = "about JavaScript", isActive = true, Instructor = Instructors[2] },
            new Course() { Name = "NodeJs", Price = 10, Description = "about NodeJs", isActive = true, Instructor = Instructors[3] },
            new Course() { Name = "Angular", Price = 30, Description = "about Angular", isActive = true, Instructor = Instructors[4] },
            new Course() { Name = "React", Price = 20, Description = "about React", isActive = true, Instructor = Instructors[0] },
            new Course() { Name = "MVC", Price = 10, Description = "about MVC", isActive = true },
                 };
                return course;

            }

        }
        private static Instructor[] Instructors =
        {
            new Instructor(){Name="Kübra",Contact=new Contact(){Email="ozkbraa@gmail.com",Phone="05456421235",Address=new Address(){City="İstanbul",Country="Türkiye",Text="Tuzla"}} },
            new Instructor(){Name="Gözde",Contact=new Contact(){Email="gozdebstn@gmail.com",Phone="05456424568",Address=new Address(){City="Sakarya",Country="Türkiye",Text="Serdivan"}} },
            new Instructor(){Name="Gökçe",Contact=new Contact(){Email="gokceasln@gmail.com",Phone="05451258965",Address=new Address(){City="Sivas",Country="Türkiye",Text="Sivas"}} },
            new Instructor(){Name="Gamze",Contact=new Contact(){Email="gamzetrkmn@gmail.com",Phone="05456879235",Address=new Address(){City="Gaziantep",Country="Türkiye",Text="Antep"}} },
            new Instructor(){Name="Buse",Contact=new Contact(){Email="buse@gmail.com",Phone="05456421235",Address=new Address(){City="İstanbul",Country="İspanya",Text="Barcelona"}} },
            new Instructor(){Name="Hatice",Contact=new Contact(){Email="htckbr@gmail.com",Phone="05456421235",Address=new Address(){City="İstanbul",Country="Fransa",Text="Paris"}} },
        };
        private static User[] Users =
        {
            new User(){UserName="kubraoz",Email="ozkbraa@gmail.com",Password="1234",City="İstanbul"},
            new User(){UserName="gozdebostanci",Email="gozdebostanci@gmail.com",Password="1234",City="İstanbul"},
        };
    }
}
