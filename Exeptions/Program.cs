namespace Exceptions
{
  internal class Program
  {
    static void Main(string[] args)
    {
      UserManager userManager = new UserManager();

      bool running = true;
      while (running)
      {
        Console.WriteLine("\n1.Добавить пользователя\n" +
            "2.Удалить пользователя\n" +
            "3.Найти пользователя\n" +
            "4.Показать всех\n" +
            "5.Выйти");

        switch (Console.ReadLine())
        {
          case "1":
            try
            {
              Console.WriteLine("Введите имя пользователя");
              string name = Console.ReadLine();
              Console.WriteLine("Введите почту пользователя");
              string mail = Console.ReadLine();

              if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mail))
              {
                userManager.AddUser(name, mail);
              };
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
            break;

          case "2":
            try
            {
              Console.WriteLine("Введите имя пользователя");
              string nameToDelete = Console.ReadLine();
              if (!string.IsNullOrEmpty(nameToDelete))
              {
                userManager.RemoveUser(nameToDelete);
              };
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
            break;

          case "3":
            try
            {
              Console.WriteLine("Введите имя пользователя");
              string nameToFind = Console.ReadLine();
              if (!string.IsNullOrEmpty(nameToFind))
              {
                var user = userManager.GetUser(nameToFind);
                Console.WriteLine($"Id: {user.Id} Имя : {user.Name}, Почта : {user.Email}");
              };
            }
            catch (Exception ex)
            {
              Console.WriteLine(ex.Message);
            }
            break;

          case "4":
            var users = userManager.ListUsers();

            if(users == null) 
            {
              throw new Exception("Ошибка получения пользователей");
            }
             
            foreach( var user in users) 
            {  
              Console.WriteLine($"Id: {user.Id} Имя : {user.Name}, Почта : {user.Email}"); 
            }
            break;

          case "5":
            running = false;
            break;
          default:
            break;
        }
      }
    }
  }
}
