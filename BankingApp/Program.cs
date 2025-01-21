// First we need a Bank Account Class, Defines a class named BankAccount that represents a bank account.
using System.Numerics;

class NegativeDepositException : Exception
{
    public NegativeDepositException(string message) : base(message) { }
}
public class BankAccount
{
    // A private field _balance of type decimal to store the account balance. decimal is chosen because it provides high precision for monetary values.
    private decimal _balance;
    private const decimal MinDepositAmount = 1.0m; // Minimum deposit amount
    private const decimal MaxDepositAmount = 10000.0m; // Maximum deposit amount
    private const decimal MinWithdrawalAmount = 10.0m; // Minimum withdrawal amount
    private const decimal DailyWithdrawalLimit = 5000.0m; // Daily withdrawal limit
    private decimal _dailyWithdrawalTotal = 0.0m; // Tracks total withdrawn today

    // Contructor for BankAccount, A constructor that initializes the bank account with an initial balance.
    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentException("nitial balance cannot be negative.");
        }
        _balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < MinDepositAmount)
            throw new ArgumentException($"Deposit amount must be at least {MinDepositAmount:C}.");
        if (amount > MaxDepositAmount)
            throw new ArgumentException($"Deposit amount cannot exceed {MaxDepositAmount:C}.");

        _balance += amount;
        Console.WriteLine($"Deposited: {amount:C}. New Balance: {_balance:C}");

    }
    public void WithDraw(decimal amount)
    {
        if (amount < MinWithdrawalAmount)
            throw new ArgumentException($"Withdrawal amount must be at least {MinWithdrawalAmount:C}.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        if (_dailyWithdrawalTotal + amount > DailyWithdrawalLimit)
            throw new InvalidOperationException($"Withdrawal exceeds the daily limit of {DailyWithdrawalLimit:C}.");

        _balance -= amount;
        _dailyWithdrawalTotal += amount;
        Console.WriteLine($"Withdrew: {amount:C}. Remaining Balance: {_balance:C}");
    }
    public void ShowBalance()
    {
        Console.WriteLine($"Current Balance: {_balance:C}");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome  to Banking Application");

        // Account initalization
        BankAccount? account = null;

        try
        {
            Console.Write("Enter your initial balance: ");
            string? input = Console.ReadLine(); // Nullable input
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }
            decimal initialBalance = decimal.Parse(input);
            account = new BankAccount(initialBalance);
            Console.WriteLine("Account created successfully!");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return;

        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            return;
        }
        while (true)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            try
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new ArgumentException("Input cannot be null or empty.");
                }
                int choice = int.Parse(input);
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ");
                        string? depositInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(depositInput))
                        {
                            throw new ArgumentException("Input cannot be null or empty.");
                        }
                        decimal depositAmount = decimal.Parse(depositInput);
                        account.Deposit(depositAmount);
                        break;
                    case 2:
                        Console.Write("Enter withdrawal amount: ");
                        string? withdrawInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(withdrawInput))
                        {
                            throw new ArgumentException("Input cannot be bull or empty.");
                        }
                        decimal withDrawAmount = decimal.Parse(withdrawInput);
                        account.WithDraw(withDrawAmount);
                        break;
                    case 3:
                        account.ShowBalance();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the banking application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }
            catch (NegativeDepositException ex)
            {
                Console.WriteLine($"Custom Exception: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
            }
            catch (SystemException ex) // Catching general system exceptions
            {
                Console.WriteLine($"System Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End of operation.\n");
            }
        }
    }
}