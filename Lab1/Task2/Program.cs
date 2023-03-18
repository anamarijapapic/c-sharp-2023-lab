// var num1 = int.MinValue; // sum will not overflow
var num1 = int.MaxValue; // sum will overflow
var num2 = long.MaxValue;

try
{
    var result = checked(num1 + num2);
    Console.WriteLine($"{num1} + {num2} = {result}");
}
catch (OverflowException e)
{
    Console.WriteLine(e.Message);
}
