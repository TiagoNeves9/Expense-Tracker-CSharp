
/**
 * Represents an expense in the expense tracker application.
 */
public class ExpenseModel
{

    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type => Amount >= 0 ? TransactionType.Income : TransactionType.Expense;
    public DateTime Date { get; set; }
    public Category Category { get; set; }
    public string? Notes { get; set; }
    private static int lastId = 0; // Static variable to keep track of the last used ID
    private static int getNextId()
    {
        // This method return the next ID for the expense
        // In a real application, this would likely query a database or use a static counter
        // For simplicity, we will just return a random number here

        return lastId++;
    }

    public ExpenseModel(string description, decimal amount, Category category, string? notes)
    {
        if (amount == 0)
            throw new ArgumentException("Amount cannot be zero");

        Id = getNextId();
        Description = description;
        Amount = amount;
        Date = DateTime.Now;
        Category = category;
        Notes = notes;
    }
    
    public enum TransactionType
{
    Income,
    Expense
}
}