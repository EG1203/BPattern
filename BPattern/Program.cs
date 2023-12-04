using System;
using System.Collections;
using System.Collections.Generic;

// Абстрактный класс для элементов оптической системы
public abstract class OpticalElement
{
    public abstract void PerformOperation();
}

// Класс для линзы
public class Lens : OpticalElement
{
    public override void PerformOperation()
    {
        Console.WriteLine("Операция с линзой");
    }
}

// Класс для зеркала
public class Mirror : OpticalElement
{
    public override void PerformOperation()
    {
        Console.WriteLine("Операция со зеркалом");
    }
}

// Контейнер для оптических элементов, реализующий IEnumerable
public class OpticalSystem : IEnumerable<OpticalElement>
{
    private List<OpticalElement> elements = new List<OpticalElement>();

    public void AddElement(OpticalElement element)
    {
        elements.Add(element);
    }

    // Реализация GetEnumerator для IEnumerable<OpticalElement>
    public IEnumerator<OpticalElement> GetEnumerator()
    {
        foreach (var element in elements)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        OpticalSystem opticalSystem = new OpticalSystem();
        opticalSystem.AddElement(new Lens());
        opticalSystem.AddElement(new Mirror());

        // Итерация по элементам оптической системы с использованием foreach
        foreach (OpticalElement element in opticalSystem)
        {
            element.PerformOperation();
        }
    }
}