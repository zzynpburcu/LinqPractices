using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            //Find() - veriye erişmenizi sağlar (arama methodu)
            Console.WriteLine("********* Find *********");
            var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
            student = _context.Students.Find(2);
            Console.WriteLine(student.Name);

            //FirstOrDefault() - gelen çoklu veri setinden ilkini getirir
            Console.WriteLine("********* FirstOrDefault *********");
            student = _context.Students.Where(student => student.Surname == "Arda").FirstOrDefault();
            Console.WriteLine(student.Name);

            student = _context.Students.FirstOrDefault(x => x.Surname == "Arda");
            Console.WriteLine(student.Name);

            //SingleOrDefault() - bir veya 0 veri bekler, çoklu veri gelirse hata fırlatır
            Console.WriteLine("********* SingleOrDefault *********");
            student = _context.Students.SingleOrDefault(student => student.Name == "Deniz");
            Console.WriteLine(student.Surname);

            //ToList()
            Console.WriteLine("********* ToList *********");
            var studentList = _context.Students.Where(student => student.ClassId ==2).ToList();
            Console.WriteLine(studentList.Count);

            //OrderBy() - belli bir kolona göre dönüyor sıralı olarak
            Console.WriteLine("********* OrderBy *********");
            students = _context.Students.OrderBy(x=>x.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId+" - "+st.Name+" "+st.Surname);
            }

            //OrderByDescending() - ters dönüyor
            Console.WriteLine("********* OrderByDescending *********");
            students = _context.Students.OrderByDescending(x=>x.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId+" - "+st.Name+" "+st.Surname);
            }

            //Anonymous Object Result 
            Console.WriteLine("********* Anonymous Object Result *********");
            var anonymousObject = _context.Students
            .Where(x=>x.ClassId == 2)
            .Select(x=> new {
                Id = x.StudentId,
                FullName = x.Name + " " + x.Surname
            });

            foreach (var obj in anonymousObject)
            {
                Console.WriteLine(obj.Id+ " - "+obj.FullName);
            }

        }
    }
}
