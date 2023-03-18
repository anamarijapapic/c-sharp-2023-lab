Console.WriteLine("Enter two integer numbers:");
var input1 = Console.ReadLine();
var input2 = Console.ReadLine();

Console.WriteLine($"----- Result for: {input1} / {input2} -----");

if (int.TryParse(input1, out int num1)
    && int.TryParse(input2, out int num2)
    && num2 != 0)
{
    var result = num1 / Convert.ToDouble(num2);

    Console.WriteLine(@"Currency: {0:C}
Integer: {1}
Scientific: {0:E}
Fixed-point: {0:F}
General: {0:G}
Number: {0:N}
Hexadecimal: {1:X}
", result, Convert.ToInt32(result));
}
else
{
    Console.WriteLine("Wrong input!\nProblem: Parsing error or division by zero.\nPlease check your input & try again!");
}
