
internal class Program
{
    public static bool IsPrime(int number)
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите конечное значение диапазона");
        
        if ((!int.TryParse(Console.ReadLine(), out int result)) || (result < 0))
            Console.WriteLine("Число должно быть положительным и целым");
        Console.WriteLine($"Простые числа из диапазона от 1 до {result}");
        int count = 0;
        for (int i = 1; i <= result; i++)
        {
            if (IsPrime(i))
            {
                Console.Write($"{i} ");
                count++;
            }
        }
        Console.WriteLine("");
        Console.WriteLine($"Найдено {count} простых чисел из диапазона от 1 до {result}");
    }
}

    
   
    