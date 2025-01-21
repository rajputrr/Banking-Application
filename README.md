Banking Application

This project is a simple console-based banking application implemented in C#. It allows users to manage their bank accounts with features like deposits, withdrawals, and balance inquiry. The application also includes validation and error handling to ensure a robust user experience.

Features

Account Initialization:

Create a new bank account with an initial balance.

Validates that the initial balance is non-negative.

Deposit Funds:

Allows users to deposit money into their account.

Validates that the deposit amount meets minimum and maximum thresholds.

Withdraw Funds:

Enables users to withdraw money from their account.

Enforces daily withdrawal limits and ensures sufficient balance.

Balance Inquiry:

Displays the current account balance.

Error Handling:

Handles invalid inputs, negative deposits, and other edge cases with appropriate messages.

Requirements

.NET SDK (version 5.0 or higher)

A C# compiler (e.g., Visual Studio, Visual Studio Code, or dotnet CLI)

How to Run

Clone the Repository:

git clone https://github.com/rajputrr/banking-application.git
cd banking-application

Build the Project:

Using Visual Studio:

Open the project in Visual Studio.

Build the solution (Ctrl+Shift+B).

Using the dotnet CLI:

dotnet build

Run the Application:

Using Visual Studio:

Press F5 or click "Start Debugging."

Using the dotnet CLI:

dotnet run

Instructions

After running the application, you'll be prompted to enter an initial balance.

Navigate through the menu options:

1: Deposit funds.

2: Withdraw funds.

3: Show current balance.

4: Exit the application.

Follow the on-screen instructions for each operation.

Example

Welcome to Banking Application
Enter your initial balance: 500
Account created successfully!

--- Menu ---
1. Deposit
2. Withdraw
3. Show Balance
4. Exit
Choose an option: 1
Enter deposit amount: 1000
Deposited: $1,000.00. New Balance: $1,500.00

--- Menu ---
1. Deposit
2. Withdraw
3. Show Balance
4. Exit
Choose an option: 3
Current Balance: $1,500.00

Error Handling

Input validation ensures that invalid or null inputs are handled gracefully.

Negative deposit amounts throw a custom NegativeDepositException.

Withdrawal operations ensure sufficient balance and daily limits are respected.

General system exceptions are caught and displayed to the user.

File Structure

.
├── Program.cs       // Main application logic
├── BankAccount.cs   // Defines the BankAccount class and operations
└── README.md        // Project instructions and documentation

Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your improvements or fixes.

License

This project is licensed under the MIT License. See the LICENSE file for details.

Contact

If you have any questions or issues, please feel free to reach out to [your-email@example.com].

