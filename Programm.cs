using System;

public class FirstClass
{
    public event Action<string> MyEvent; 

    private string _name;

    public FirstClass(string name)
    {
        _name = name;
    }

    public void RaiseEvent()
    {
        MyEvent?.Invoke(_name); 
    }
}

// Второй класс
public class SecondClass
{
    public void HandleEvent(string eventName)
    {
        Console.WriteLine($"Обработчик второго класса: Событие сгенерировано объектом {eventName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        FirstClass firstObject1 = new FirstClass("Первый объект");
        FirstClass firstObject2 = new FirstClass("Второй объект");
        SecondClass secondObject = new SecondClass();

        firstObject1.MyEvent += secondObject.HandleEvent; // Регистрация обработчика для первого объекта
        firstObject2.MyEvent += secondObject.HandleEvent; // Регистрация обработчика для второго объекта

        firstObject1.RaiseEvent(); // Генерация события для первого объекта
        firstObject2.RaiseEvent(); // Генерация события для второго объекта
    }
}
