using Notebook.BL.Models;
using Notebook.BL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationService serService = new SerializationService();

            List<People> note = new List<People>();

            note.Add(new People
            {
                Id = Guid.NewGuid().ToString(),
                Surname = "Иванов",
                Name = "Петр",
                DateBirthday = 10101996,
                PhoneNumber = "89272500011"
            });

            note.Add(new People
            {
                Id = Guid.NewGuid().ToString(),
                Surname = "Петрова",
                Name = "Анна",
                DateBirthday = 10101960,
                PhoneNumber = "892772010085"
            });

            note.Add(new People
            {
                Id = Guid.NewGuid().ToString(),
                Surname = "Сидоров",
                Name = "Иван",
                DateBirthday = 11051986,
                PhoneNumber = "892772010085"
            });

            note.Add(new People
            {
                Id = Guid.NewGuid().ToString(),
                Surname = "Алексеев",
                Name = "Олег",
                DateBirthday = 16051998,
                PhoneNumber = "892772010085"
            });


            note.Add(new People
            {
                Id = Guid.NewGuid().ToString(),
                Surname = "Иванова",
                Name = "Ирина",
                DateBirthday = 10051985,
                PhoneNumber = "892772010085"
            });


            note.Add(new People
            {
                Id = Guid.NewGuid().ToString(),
                Surname = "Романенкова",
                Name = "Виктория",
                DateBirthday = 10021955,
                PhoneNumber = "892772010085"
            });


            note.Add(new People
            {
                Surname = "Семёнова",
                Name = "Алёна",
                DateBirthday = 10031950,
                PhoneNumber = "892772010085"
            });

            serService.Serializer(note);

            //Console.WriteLine("Введите поисковый запрос");
            //string search = Console.ReadLine();
            //var ppl = note
            //    .Where(x =>
            //    x.Surname.StartsWith(search)
            //    || x.PhoneNumber.StartsWith(search)
            //    || x.Name.StartsWith(search)
            //    ).ToList();

            //foreach (var item in ppl)
            //{
            //    Console.WriteLine("0={0}\n", item.Name)s;
            //    Console.WriteLine("1={0}\n", item.Surname);
            //    Console.WriteLine("2={0}\n", item.DateBirthday);
            //    Console.WriteLine("3={0}\n", item.PhoneNumber);
            //}






            Console.ReadKey();
        }
    }
}