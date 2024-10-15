// Expenses (c) 2024 Baltasar MIT License <baltasarq@gmail.com>


using System;

namespace MyExpenses.Core;


/// <summary>An individual expense.</summary>
public class Expense {
    public enum Kind { Leisure, Food, Clothing };
    public required DateTime Date { get; init; }
    
    /// <summary>The date of the expense, as an ISO string.</summary>
    public string DateAsIsoString() => this.Date.ToString( "yyyy-MM-dd" );

    /// <summary>The amount of the expense.
    /// The amount is stored as an int, and converted into a double when necessary.
    /// </summary>
    public required double Amount {
        get => this._amount / 100.0;
        init => this._amount = (ulong) ( value * 100 );
    }
    
    /// <summary>The amount in cents, 1 eur == 100 cents.</summary>
    public ulong AmountInCents => this._amount;
    
    /// <summary>The type of expense.</summary>
    public required Kind Type { get; init; }
    

    public override string ToString()
    {
        return $"{this.DateAsIsoString()}, Type: {this.Type}: Amount: {this.Amount}";
    }

    private ulong _amount;
}
