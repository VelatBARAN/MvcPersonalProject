using MvcPersonalProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPersonalProject.DAL.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            User user = new User
            {
                Name = "Welat",
                Surname = "BARAN",
                Degree = "Proje Yöneticisi",
                Email = "baranvelat021@gmail.com",
                Password = "liceli21",
                Github = "https://github.com/velatbaran",
                Twitter = "https://twitter.com/baranvelat021",
                Instagram = "https://www.instagram.com/baranvelat021/",
                Telegram = "https://t.me/baranvelat",
                Image = "user.jpg",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddDays(2)
            };
            context.User.Add(user);
            context.SaveChanges();

            About about = new About
            {
                Text = "Selçuk Üniversitesi Bilgisayar Mühendisi mezunuyum. Şu an aktif olarak Bağlar Belediyesi Bilgi İşlem Departmanında çalışmaktayım. " +
                "Boş zamanlarımda Asp.Net Mvc5,C#,Jquery,Javascript,Ajax,Mssql,LinQ,TSql programlama araçlarını kullanarak projeler geliştirmekteyim.",
                Image = "user.jpg",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddDays(2)
            };
            context.About.Add(about);
            context.SaveChanges();


            Contact contact = new Contact
            {
                Location = "Bağcılar mah. Bağlar Belediyesi Bağlar/Diyarbakır",
                Email = "baranvelat021@gmail.com",
                Phone = "05393711268",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddDays(2)
            };
            context.Contact.Add(contact);
            context.SaveChanges();
        }
    }
}
