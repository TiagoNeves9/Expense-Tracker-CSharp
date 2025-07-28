/***
 * Service for managing expenses CRUD operations.
 * This service allows adding, retrieving, removing expenses,
 * and filtering expenses by category or date.
 */
public class ExpenseService
{
    private List<ExpenseModel> expenses = new List<ExpenseModel>();

    public void AddIncome(string description, decimal amount, Category category)
    {
        // Ensure it's positive for income
        var income = new Expense(description, Math.Abs(amount), category);
        expenses.Add(income);
    }

    public void AddExpense(string description, decimal amount, Category category)
    {
        // Ensure it's negative for expenses
        var expense = new Expense(description, -Math.Abs(amount), category);
        expenses.Add(expense);
    }

    public List<ExpenseModel> GetAllExpenses()
    {
        return expenses;
    }

    public void RemoveExpense(ExpenseModel expense)
    {
        expenses.Remove(expense);
    }

    public List<ExpenseModel> GetExpensesByCategory(Category category)
    {
        return expenses.Where(e => e.Category == category).ToList();
    }

    public List<ExpenseModel> GetExpensesByDate(DateTime date)
    {
        return expenses.Where(e => e.Date.Date == date.Date).ToList();
    }

    public decimal GetTotalIncome()
    {
        return expenses.Where(e => e.Amount > 0).Sum(e => e.Amount);
    }

    public decimal GetTotalExpenses()
    {
        return Math.Abs(expenses.Where(e => e.Amount < 0).Sum(e => e.Amount));
    }

    public decimal GetTotalBalance()
    {
        // The magic happens here with LINQ!
        return expenses.Sum(e => e.Amount);
    }
}
