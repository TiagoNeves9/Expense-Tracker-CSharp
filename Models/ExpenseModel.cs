
/**
 * Represents an expense in the expense tracker application.
 */
public class ExpenseModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Category Category { get; set; }
    public string? Notes { get; set; }

    private static int getNextId()
    {
        // This method return the next ID for the expense
        // In a real application, this would likely query a database or use a static counter
        // For simplicity, we will just return a random number here
        return new Random().Next(1, 10000);
    }

    public ExpenseModel(string description, decimal amount, Category category, string? notes)
    {
        Id = getNextId();
        Description = description;
        Amount = amount;
        Date = DateTime.Now;
        Category = category;
        Notes = notes;
    }
}