using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int> //buradaki int ile IdentityUser<int> sınıfındaki Id tipi eşleşiyor böylelikle primary key olarak int kullanmış oluyoruz ve atama yapmış oluyoruz
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
    }
}
