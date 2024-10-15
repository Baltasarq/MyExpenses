// Expenses (c) 2024 Baltasar MIT License <baltasarq@gmail.com>


using System;
using System.Collections.Generic;

namespace MyExpenses.Core;


public class ExpensesControl {
    public ExpensesControl()
    {
        this._expenses = new List<Expense>();
    }

    /// <summary>Adds a given expense.</summary>
    /// <param name="expense">The expense to add.</param>
    public void Add(Expense expense)
    {
        this._expenses.Add( expense );
    }
    
    /// <summary>Returns a collection of all expenses.</summary>
    public IList<Expense> All => new List<Expense>( this._expenses );

    /// <summary>Return an specific expense.</summary>
    /// <param name="pos">The poisition of the expense to retrieve.</param>
    /// <returns>An <see cref="Expense"/>.</returns>
    /// <exception cref="ArgumentException">
    /// if the position is incorrect: 0 &lt;= pos &lt; <see cref="Count"/>.
    /// </exception>
    public Expense Get(int pos)
    {
        if ( !this.IsPosValid( pos ) ) {
            throw new ArgumentException( $"invalid position: {nameof(pos)}" );
        }
        
        return this._expenses[ pos ];
    }

    /// <summary>Calculates the total expense smount in this list.</summary>
    public double Total()
    {
        ulong total = 0;
        
        foreach(Expense exp in this._expenses) {
            total += exp.AmountInCents;
        }
        
        return total / 100.0;
    }
    
    /// <summary>Returns whether a position is valid or not.</summary>
    /// <param name="pos">The position to test.</param>
    /// <returns>true if the position is correct: 0 &lt;= pos &lt; <see cref="Count"/>,
    ///          false otherwise.</returns>
    public bool IsPosValid(int pos) => pos >= 0 && pos < this.Count;
    
    /// <summary>Returns the number of expenses stored.</summary>
    public int Count => this._expenses.Count;
    
    private readonly List<Expense> _expenses;
}
