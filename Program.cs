/* Лабораторная2. Упражнение 4 */

/* 
Требуется создать класс Operation, в котором необходимо определить: 
•  статический метод расчета площади треугольника по формуле Герона (см. 
упражнение 1 лабораторной работы 2). Этот метод должен принимать три 
параметра (стороны треугольника) и возвращать значение площади; 
•  статический закрытый метод проверки наличия треугольника. Этот метод 
должен возвращать значение логического типа; 
•  перегруженный статический метод, который будет принимать один 
параметр – сторону и вычислять площадь равностороннего треугольника. 

Указание. Вызов метода проверки наличия треугольника реализуйте в 
методе расчета площади.
*/
using System;

public static class Operation
{
    // Метод рассчета площади треугольника
    public static double CalculateArea(double a, double b, double c)
    {
        if (!IsTriangle(a, b, c)) // Если возвращаем не true (т.е. false) это не треугольник - возвращаем 0
            return 0;

        double p = (a + b + c) / 2; // Рассчитываем полупериметр
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // Рассчет площади и возврат
    }

    // Метод проверки, что это треугольник
    private static bool IsTriangle(double a, double b, double c)
    {
        // Проверяем, что введено положительное число и сумма длин любых двух сторон больше длины третьей стороны
        return (a + b > c) && (a + c > b) && (b + c > a) && (a > 0) && (b > 0) && (c > 0);
    }

    // Метод рассчета площади равностороннего треугольника
    public static double CalculateArea(double a)
    {
        if (!IsTriangle(a, a, a)) // Если возвращаем не true (т.е. false) это не треугольник - возвращаем 0
            return 0;

        return (Math.Sqrt(3) / 4) * a * a;
    }
}

class Program
{
    static void Main()
    {
        bool cheked = false;

        while (!cheked) // Цикл для повторного ввода
        {
            try
            {
                Console.WriteLine("Enter type of triangle (equilateral (e) or NOT equilateral (n)):");
                string str = Console.ReadLine();

                if (str == "e" || str == "E") //проверка ввода E
                {
                    Console.WriteLine("Enter side:"); // приглашение к вводу
                    double a = double.Parse(Console.ReadLine()); // инициализируем а

                    double area = Operation.CalculateArea(a); // вызываем перегруженный метод CalculateArea()
                    if (area == 0)
                    {
                        Console.WriteLine("It's not a triangle!"); // это не треугольник
                    }
                    else
                    {
                        Console.WriteLine("Area of equilateral triangle = {0:F3}", area); // форматируем до 3 знаков после запятой
                        cheked = true;
                    }
                }
                else if (str == "n" || str == "N") //проверка ввода N
                {
                    Console.WriteLine("Enter side a:"); // приглашение к вводу
                    double a = double.Parse(Console.ReadLine()); // инициализируем а

                    Console.WriteLine("Enter side b:"); // приглашение к вводу
                    double b = double.Parse(Console.ReadLine()); // инициализируем b

                    Console.WriteLine("Enter side c:"); // приглашение к вводу
                    double c = double.Parse(Console.ReadLine()); // инициализируем c

                    double area = Operation.CalculateArea(a, b, c); // вызываем метод CalculateArea()
                    if (area == 0)
                    {
                        Console.WriteLine("It's not a triangle!"); // это не треугольник
                        cheked = true;
                    }
                    else
                    {
                        Console.WriteLine($"Area of triangle = {area:F3}"); // форматируем до 3 знаков после запятой
                        cheked = true;
                    }
                }
                else
                {
                    Console.WriteLine("You must enter \"e\" or \"n\"");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number value!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Other error: {e.Message}");
            }
        }
    }
}
