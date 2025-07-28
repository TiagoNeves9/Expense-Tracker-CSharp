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
            // Initialize the expense tracker application
            RunExpenseTracker();
        }

        private static void RunExpenseTracker()
        {
            // Here you would typically set up your application, such as initializing services, loading data, etc.
            Console.WriteLine("Welcome to the Expense Tracker!");
            // For demonstration purposes, we can create a simple flow.
            InitializeExpenses();
        }

        private static void InitializeExpenses()
        {
            // Example of how to use the InputValidator and ExpenseService
            var expenseService = new ExpenseService();

            // Add some expenses and incomes
            expenseService.AddIncome("Salary", 3000m, Category.Income);
            expenseService.AddExpense("Groceries", 150m, Category.Food);
            expenseService.AddExpense("Gas", 60m, Category.Transport);

            // Display total balance
            decimal balance = expenseService.GetTotalBalance();
            Console.WriteLine($"Total Balance: {balance:C}");
        }
    }

}