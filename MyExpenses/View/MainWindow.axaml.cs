// Expenses (c) 2024 Baltasar MIT License <baltasarq@gmail.com>


using System;
using Av = Avalonia.Controls;
using MyExpenses.Core;

namespace MyExpenses.View;


public partial class MainWindow : Av.Window {
    public MainWindow()
    {
        this.InitializeComponent();

        this._expenses = new ExpensesControl();
        
        this.BtNext.Click += (_, _) => this.OnNext();
        this.BtPrev.Click += (_, _) => this.OnPrev();
        this.BtAdd.Click += (_, _) => this.OnAdd();

        this._pos = 0;
        this.Update();
    }

    /// <summary>When the user presses the previous button.</summary>
    private void OnPrev()
    {
        this._pos = Math.Max( this._pos - 1, 0 );
        this.Update();
    }

    /// <summary>When the user presses the next button.</summary>
    private void OnNext()
    {
        this._pos = Math.Min( this._pos + 1, this._expenses.Count - 1 );
        this.Update();
    }

    /// <summary>When the user presses the insert button.</summary>
    private async void OnAdd()
    {
        var dlgAdd = new DlgAdd();
        
        await dlgAdd.ShowDialog( this );
        
        if ( dlgAdd.Expense != null ) {
            this._expenses.Add( dlgAdd.Expense );
        }
        
        this.Update();
    }

    private void Update()
    {
        if ( this._expenses.IsPosValid( this._pos ) ) {
            var expense = this._expenses.Get( this._pos );
            
            this.EdDate.Text = expense.DateAsIsoString();
            this.EdAmount.Text = "" + expense.Amount;
            this.EdType.Text = expense.Type.ToString();
            this.LblPos.Content = $"{this._pos + 1} / {this._expenses.Count}";
        }        
    }

    private int _pos;
    private ExpensesControl _expenses;
}
