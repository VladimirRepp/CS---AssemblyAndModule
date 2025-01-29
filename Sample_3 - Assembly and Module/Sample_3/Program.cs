using System;
using System.Reflection;

// Сборка (assembly) – запущенное приложение, JIT-скомпилированное и выгруженное в
// оперативную память. Как правило, сборка состоит из некоторого количества
// совместно исполняемых модулей, делящих одно и то же адресное пространство.

// Модуль (module) – под модулем мы будем понимать
// некоторый исполняемый файл: *.exe или *.dll, который
// загружен, как составной элемент некоторой сборки.

// Пример взаимодействия с объектами Assembly и Module
namespace Sample_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Загрузить библиотеку 
            Assembly asm = Assembly.Load(AssemblyName.GetAssemblyName("SampleLibrary.dll"));

            // Получить модули этой сборки 
            Module module = asm.GetModule("SampleLibrary.dll");

            // Вывод типов данных, объевленные в модуле 
            foreach(Type t in module.GetTypes())
                Console.WriteLine(t.FullName);

            // Получить тип данных из сборки 
            Type Person = module.GetType("SampleLibrary.Person");

            // Создаем объект из полученного типа
            object person = Activator.CreateInstance(Person, 
                new object[] {"Имя1", "Фамилия1", 30 });

            // Вызываем метод созданного объекта
            string dataPerson = Person.GetMethod("GetInfoToString").Invoke(person, null).ToString();
            Console.WriteLine($"Данные человека:\n{dataPerson}");

            Console.ReadLine();
        }
    }
}
