using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public interface IRepository
    {
        IEnumerable<Request> Requests { get; } //liste getirmesini istediğimiz için get yeterli
        IEnumerable<Course> Courses { get; } //değişiklik yapmıyacağımız için set yok.
    }
    // IEnumerable ile veritabanı bağlantısı olan bir nesne üzerinden sorgu isterseniz tüm liste hafızaya alınacak ve daha sonra bu liste üzerinden filtrelerinize göre seçme işlemi yapılacaktır.

    // IQueryable ile LINQ sorgusu yapıldığında ise  veritabanı üzerinde çalıştırılacak sorguda tüm filtreler yer alalacak ve sadece istenen kayıtlar yüklenecektir.(Lazy Loading) kullanır. Yani veritabanından kayıtları siz  kullanmaya başlayana kadar çağırmaz. Bu da sayfalama gibi bir çok işlemde çok faydalıdır.
}
