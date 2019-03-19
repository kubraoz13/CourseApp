using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class EfCourseRepository:ICourseRepository
    {
        private DataContext context;
        public EfCourseRepository(DataContext _context)
        {
            context = _context;
        }

        public IQueryable<Course> Courses => context.Courses; 

        public int CreateCourse(Course newCourse)
        {
            context.Courses.Add(newCourse);
            context.SaveChanges();
            return newCourse.Id;
        }

        public void DeleteCourse(int courseid)
        {
            var entity = GetById(courseid);
            context.Courses.Remove(entity); //kaydı silmeden önce buradan kursla eğitmenin bağlantısı kaldırıcak.

            if (entity.Instructor!=null)
            {
                context.Remove(entity.Instructor);
            }
            context.SaveChanges();
        }

        public Course GetById(int courseid)
        {
            return context.Courses //bir sorguyla 4 tablodan veri çekebiliyoruz.
                .Include(x => x.Instructor)
                .ThenInclude(x=>x.Contact) //ikinci defa include edilmez.oyüzden "theninclude" kullanılır.
                .ThenInclude(x=>x.Address)
                .FirstOrDefault(x => x.Id == courseid);
        }

        public IEnumerable<Course> GetCourseByActive(bool isActive)
        {
           return context.Courses.Where(x => x.isActive == true).ToList();
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }
        //filter kısmı arama yapıyor
        public IEnumerable<Course> GetCoursesByFilters(string name = null, decimal? price = null, string isActive = null) 
        {
            IQueryable<Course> query = context.Courses;
            if (name!=null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (price!=null)
            {
                query = query.Where(x => x.Price >= price);
            }
            if (isActive=="on")
            {
                query = query.Where(x => x.isActive == true);
            }
            return query.Include(x => x.Instructor).ToList();
        }

        public void UpdateCourse(Course updateCourse,Course originalCourse=null)
        {
            if (originalCourse==null)
            {
                originalCourse = context.Courses.Find(updateCourse.Id);
            }
            else
            {
                context.Courses.Attach(originalCourse);
            }
            originalCourse.Name = updateCourse.Name;
            originalCourse.Description = updateCourse.Description;
            originalCourse.Price = updateCourse.Price;
            originalCourse.isActive = updateCourse.isActive;

            originalCourse.Instructor.Name = updateCourse.Instructor.Name;
            originalCourse.Instructor.Contact.Email = updateCourse.Instructor.Contact.Email;
            originalCourse.Instructor.Contact.Phone = updateCourse.Instructor.Contact.Phone;
            originalCourse.Instructor.Contact.Address.City = updateCourse.Instructor.Contact.Address.City;
            originalCourse.Instructor.Contact.Address.Country = updateCourse.Instructor.Contact.Address.Country;
            originalCourse.Instructor.Contact.Address.Text = updateCourse.Instructor.Contact.Address.Text;

            EntityEntry entry = context.Entry(originalCourse);

            //Modifies,Unchanged,Added,Deleted,Detached
            Console.WriteLine($"Entity State :{entry.State}");
            foreach(var property in new string[] { "Name","Description","Price","isActive"})
            {
                Console.WriteLine($"{property}-old:{entry.OriginalValues[property]} new:{entry.CurrentValues[property]}");
            }

            context.SaveChanges();        }
    }
}
