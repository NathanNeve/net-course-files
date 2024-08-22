namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public static int Add(string input)
        {
            if (input == "")
            {
                return 0;
            } 
            var numbers = input.Split(',');
            int total = 0;
            foreach ( var number in numbers )
            {
                if (int.Parse(number) <= 1000) 
                {
                    if (int.Parse(number) < 0)
                    {
                        throw new Exception();
                    }
                total += int.Parse(number);
                }
            }
            return total;
        }
    }
}