using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using CourseApp.Data.Abstract;
using CourseApp.Data.Concrete;

namespace CourseApp
{
    public class Startup //bütün işlemleri startupta yapıyoruz.
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Core ilk açılışta MVC gereksinimlerini yüklemek için bu koda ihtiyaç duymaktadır.
            services.AddMvc();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection"));
                options.EnableSensitiveDataLogging(true);
                
            });
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
            services.AddTransient<ICourseRepository, EfCourseRepository>(); //Addtransient:nesneye yapılan her çağrıda yeni bir nesne oluşturur.
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IInstructorRepository, EfInstructorRepository>();
            services.AddTransient<IGenericRepository<Contact>, GenericRepository<Contact>>();
            services.AddTransient<IGenericRepository<Address>, GenericRepository<Address>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,DataContext dataContext,UserContext userContext)
        {
            if (env.IsDevelopment()) //eğer uygulama geliştiricisiysen hata kodlarını göster demek.
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed(dataContext);
                SeedDatabase.Seed(userContext);
            }

            app.UseDeveloperExceptionPage(); //eğer uygulama geliştirici değilsende hataları göstersin diye  yukarıdaki if döngüsünün dışınada yazdık.

            //response contexte cevap veriyor.ekrana yazdır(writeasync).

            //404 yada server hatası olduğunda hata sonucunu bize göstersin istiyoruz.
            app.UseStatusCodePages();

            app.UseStaticFiles(); //statik bir dosya oluşturmamızı sağlar.
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"node_modules")),RequestPath=new PathString("/vendor")
            }); //dosya sağlayıcı=fileprovider --path dosya yolunu yazıyoruz.
            //node moduls gördüğümüz yere /vendor gelicek. ındexteki js-ve bostrap csslerdeki nodemodulesi silip vendor yazdık

            //Route işlemi için gerekli kodu yazıyoruz basit bir route yapısı allta
            //Örnek olarak- controller/Home/Index/Id(opsiyonel)
            app.UseMvcWithDefaultRoute(); //mvcdeki route config kısmı gelsin diye bu kodu yazıyoruz.



        }
    }
}
