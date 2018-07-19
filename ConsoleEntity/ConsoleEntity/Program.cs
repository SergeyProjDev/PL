using System;
using System.Data.Entity;

namespace ConsoleEntity
{
    class Program : DbContext
    {
        static void Main(string[] args)
        {
            Program Starter = new Program();
            Console.WriteLine("Program started!");

            Starter.StartApp();

            Console.WriteLine("\nProgram ended!");
            Console.Read();
        }

        public void StartApp() 
        {
            using (UserContext db = new UserContext())
            {
                string name;
                int age;

                while (true)
                {
                    try {
                        Console.WriteLine("\nНадо добавить себя. \nВаше имя:");
                        name = Console.ReadLine();
                        Console.WriteLine("Ваш возраст:");
                        age = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) { Console.WriteLine("Вы ввели неверные параметры!"); continue; }
                
                    AddUser(db, name, age);

                    //объекты из бд в users
                    var users = db.Users;

                    Console.WriteLine("1 - Очистить бд\n2 - Показать бд\n");
                    string Key = ChooseOne();
                    if (Key.Equals("1"))
                        RemoveAll(db, users);
                            else
                                if (Key.Equals("2"))
                                    ShowAll(db, users);
                                        else Console.WriteLine("Nothing :)");

                    Console.WriteLine("\n   ***   \nRestarting...\n   ***");
                }
                
            }
        }

        private string ChooseOne()
        {
            string kod = "";
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter)
                kod += key.KeyChar;

            return kod;
        }


        private void AddUser(UserContext db, string name, int age)
        {
            if ((age > 100) || (age < 10)) Console.WriteLine("У вас ПОДОЗРИТЕЛЬНЫЙ возраст. Но я вас пропускаю!. Добавление...");
            // создаем объект User
            User user1 = new User { Name = name, Age = age };

            // добавляем в бд
            db.Users.Add(user1);
            db.SaveChanges();
        }

        private void RemoveAll(UserContext db, dynamic users)
        {
            foreach (User u in users)
                db.Users.Remove(u);
            db.SaveChanges();
        }

        private void ShowAll(UserContext db, dynamic users)
        {
            foreach (User u in users)
                Console.WriteLine("{0} - {1} - {2}", u.Id, u.Name, u.Age);
        }        
    }




    class UserContext : DbContext //нужно
    {
        public UserContext() : base("DbConnection") { }
        public DbSet<User> Users { get; set; }
    }

    class User //поля таблицы sql
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
}
