namespace ExpenseTracker
{
    using System;
    using Models;
    using Services;
    using Utilities;

    class Program
    {
        static void Main(string[] args)
        {   
            ExpenseService expenseService = new ExpenseService();
            Console.WriteLine("Welcome to the Expense Tracker!");
            Console.WriteLine("Type 'help' for available commands or 'quit/exit' to exit.");
            while (true)
            {
                Console.Write("> ");

                string? input = Console.ReadLine();

                //Handle empty input
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                string command = input.Trim().ToLower();

                switch (command)
                {
                    case "help":
                    case "h":
                        ConsoleUtilities.Help();
                        break;

                    case "quit":
                    case "exit":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    case "expense":
                    case "add expense":
                        ConsoleUtilities.AddExpense(expenseService);
                        break;

                    case "income":
                    case "add income":
                        ConsoleUtilities.AddIncome(expenseService);
                        break;

                    case "balance":
                    case "show balance":
                        ConsoleUtilities.ShowBalance(expenseService);
                        break;
                    default:
                        Console.WriteLine("Unknown command. Type 'help' for available commands.");
                        break;
                }

                Console.WriteLine();

            }
        }

    }

}