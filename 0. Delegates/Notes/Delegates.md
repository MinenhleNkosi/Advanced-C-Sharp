# What are delegates?
Delagates are simply a type safe function pointer. A variable defined as a delegate is a referance type variable that can hod a reference to a method.
In order for a delegate to reference a method, it must define parameters with types that match.

```cs
public class Program
{
    delegate int CalculateDel(int operand1, int operand2);

    static void Main (string[] args)
    {
        //Perform addition calculation
        CalculateDel addCalculationDel = new(AddIntegerValues);
        int resultAddition = addCalculationDel(10, 5);

        Console.WriteLine($"Addition result: {resultAddition}");

        //Perform subtraction
        CalculateDel subtractCalculationDel = new(SubtractIntegerValues);
        int resultSubtract = subtractCalculationDel(10, 5);

        Console.WriteLine($"Subtract result: {resultSubtract}");
    }

    static int AddIntegerValues(int operand1, int operand2)
    {
        return operand1 + operand2;
    }

    static int SubtractIntegerValues(int operand1, int operand2)
    {
        return operand1 - operand2;
    }
}
```

    **Note**
    A delegate can reference both a *static method* and an *instance method*.


## Delegates referencing static methods.
Let's say we want to encapsulate functionality that logs text and includes a date-time stamp that is followed by the expected text. We want the solution to:
* Be able to display date-time stamp and text in the console screen.
* Be able to log the date-time stamp and text in a text file.

First in our application:
1. We will define a delegate that reference a method that does not return a value (`void`) and accepts one string argument (`parameter`):
```cs 
    delegate void LogDel(string text);
```

2. Next we define the method that will be passed to our delegate to desplay text using the console screen:
```cs
    static void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }
```

3. We now create an instance for our `LogDel` type to use within the `Main` method scope:
```cs
    LogDel logDel = new(LogTextToScreen);
```

4. We can now use the instance object `logDel` to pass in the appropriate string value to display on the screen:
```cs
    logDel("Wola Jetro");
```

5. The final solution:
```cs
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
```

