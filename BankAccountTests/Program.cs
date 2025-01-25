namespace MSUnitTestDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bank_account = new BankAccount("Umar Hayat", 0);
          
            try
            {
                bank_account.Debit(5); // This should throw an ArgumentOutOfRangeException
            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine("amount <= 0 or amount > balance");
            }
            catch (Exception e)
            {
                // If another exception is thrown, verify its message
                Console.WriteLine("balance==0");
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
