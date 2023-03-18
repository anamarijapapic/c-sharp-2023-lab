namespace Task3.Helpers
{
    public class InputHelpers
    {
        public static int InputNumberChoice(int minValue, int maxValue, string message = "\nEnter your choice:")
        {
            int input;
            bool tryParseSuccess;

            do
            {
                Console.WriteLine(message);
                tryParseSuccess = int.TryParse(Console.ReadLine().Trim(), out input);

                if (tryParseSuccess && input >= minValue && input <= maxValue) break;

                Console.WriteLine("Wrong input!");
            } while (!tryParseSuccess || input < minValue || input > maxValue);

            return input;
        }
    }
}
