using System;

public class Transaction
{
    // Properties for the transaction
    /*
     The { get; } syntax indicates that the property is read-only outside the class.
    This means that once these properties are set through the constructor (explained below), 
    their values cannot be changed directly from outside the class.
     */
    public string Description { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }

    // Constructor to initialize the transaction
    public Transaction(string description, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        }

        Description = description;
        Amount = amount;
        Date = DateTime.Now; // Automatically set to the current date and time
    }
    
    // Method to display transaction details as a string
    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Description}: {Amount:C}";
    }
    
}
