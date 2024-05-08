using System;
using System.Collections.Generic;

public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
}

public class UserArray<T> : GenericArray<T> where T : User
{
    public UserArray(int size) : base(size) { }

    public void RegisterUser(string login, string password)
    {
        T user = (T)Activator.CreateInstance(typeof(T));
        user.Login = login;
        user.Password = password;
        Add(user);
    }
}

class Program
{
    static void Main(string[] args)
    {
        UserArray<User> userArray = new UserArray<User>(3);

        userArray.RegisterUser("user1", "password1");
        userArray.RegisterUser("user2", "password2");
        userArray.RegisterUser("user3", "password3");

        Console.WriteLine("Пользователи:");
        for (int i = 0; i < userArray.Length; i++)
        {
            User user = userArray.Get(i);
            Console.WriteLine($"Логин: {user.Login}, Пароль: {user.Password}");
        }
    }
}
