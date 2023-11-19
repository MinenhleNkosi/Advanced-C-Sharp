namespace DelegateExample
{
    public class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            LogDel logDel = new(LogTextToScreen);

            Console.WriteLine("Please Enter Your Name and Surname");
            var saveNameSurname = Console.ReadLine();
            logDel($"Your name is {saveNameSurname}!");
        }

        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}
