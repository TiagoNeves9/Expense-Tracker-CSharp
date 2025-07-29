namespace Utilities
{
    using Models;
    using System;
    using Services;
    public class ConsoleUtilities
    {
        public static void Help()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("  expense / add expense - Add a new expense");
            Console.WriteLine("  income / add income   - Add a new income");
            /* Console.WriteLine("  list        - Show all transactions"); */
            Console.WriteLine("  balance / show balance - Show current balance");
            Console.WriteLine("  help        - Show this help message");
            Console.WriteLine("  quit / exit - Exit the program");
        }

        public static void AddExpense(ExpenseService expenseService)
        {
            try
            {
                Console.Write("Description: ");
                string? description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Description cannot be empty.");
                    return;
                }

                Console.Write("Amount: $");
                string? amountInput = Console.ReadLine();
                if (!decimal.TryParse(amountInput, out decimal amount) || amount <= 0)
                {
                    Console.WriteLine("Please enter a valid positive amount.");
                    return;
                }

                Console.Write("Category (Food/Transportation/Entertainment/Bills/Healthcare/Shopping/Other): ");
                string? categoryInput = Console.ReadLine();
                if (!Enum.TryParse<Category>(categoryInput, true, out Category category))
                {
                    Console.WriteLine("Invalid category. Using 'Other'.");
                    category = Category.Other;
                }

                expenseService.AddExpense(description, amount, category);
                Console.WriteLine($"✓ Added expense: {description} - ${amount:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding expense: {ex.Message}");
            }
        }

        public static void AddIncome(ExpenseService expenseService)
        {
            try
            {
                Console.Write("Description: ");
                string? description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Description cannot be empty.");
                    return;
                }

                Console.Write("Amount: $");
                string? amountInput = Console.ReadLine();
                if (!decimal.TryParse(amountInput, out decimal amount) || amount <= 0)
                {
                    Console.WriteLine("Please enter a valid positive amount.");
                    return;
                }

                expenseService.AddIncome(description, amount, Category.Income);
                Console.WriteLine($"✓ Added income: {description} - ${amount:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding income: {ex.Message}");
            }
        }

        /* public static void ShowAllTransactions(ExpenseService expenseService)
        {
            var transactions = expenseService.GetAllTransactions();
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }
            
            Console.WriteLine("\n=== All Transactions ===");
            foreach (var transaction in transactions)
            {
                string type = transaction.Amount >= 0 ? "Income" : "Expense";
                Console.WriteLine($"{transaction.Date:MM/dd/yyyy} | {type} | {transaction.Description} | ${Math.Abs(transaction.Amount):F2} | {transaction.Category}");
            }
        } */

        public static void ShowBalance(ExpenseService expenseService)
        {
            decimal totalIncome = expenseService.GetTotalIncome();
            decimal totalExpenses = expenseService.GetTotalExpenses();
            decimal balance = expenseService.GetTotalBalance();

            Console.WriteLine("\n=== Financial Summary ===");
            WriteSuccess($"Total Income:  ${totalIncome:F2}");
            WriteError($"Total Expenses: ${totalExpenses:F2}");
            WriteInfo($"Current Balance: ${balance:F2}");

            if (balance >= 0)
                WriteSuccess("💰 You're in the green!");
            else
                WriteError("⚠️  You're spending more than you earn.");
        }

        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
