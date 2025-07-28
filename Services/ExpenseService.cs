/***
 * Service for managing expenses CRUD operations.
 * This service allows adding, retrieving, removing expenses,
 * and filtering expenses by category or date.
 */
public class ExpenseService
{
    private List<ExpenseModel> expenses = new List<ExpenseModel>();

    public void AddExpense(ExpenseModel expense)
    {
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
}
