// Expenses (c) 2024 Baltasar MIT License <baltasarq@gmail.com>


using System;
using Avalonia.Controls;
using Av = Avalonia.Controls;
using MyExpenses.Core;

namespace MyExpenses.View;


public partial class DlgAdd : Av.Window {
    public DlgAdd()
    {
        this.InitializeComponent();
        
        // Load combo box
        foreach (Expense.Kind et in Enum.GetValuesAsUnderlyingType( typeof( Expense.Kind )))
        {
            this.EdType.Items.Add( et.ToString() );
        }
        this.EdType.SelectedIndex = 0;
        
        // Set the date
        this.EdDate.SelectedDate = DateTime.Now;

        this.BtOk.Click += (_, _) => this.OnOk();
        this.BtCancel.Click += (_, _) => this.OnCancel();
    }

    /// <summary>When the user presses the insert button.</summary>
    private void OnOk()
    {
        var edAmount = this.FindControl<TextBox>( "EdAmount" ) ?? new TextBox();
        var edType = this.FindControl<ComboBox>( "EdType" ) ?? new ComboBox();
        var edDate = this.FindControl<DatePicker>( "EdDate" ) ?? new DatePicker();
        int kindPos = Math.Max( 0, edType.SelectedIndex );
        Expense.Kind type = Enum.GetValues<Expense.Kind>()[ kindPos ];
        DateTime date = ( edDate.SelectedDate ?? new DateTimeOffset( DateTime.Now ) ).Date; 
        double amount;
        
        if ( !double.TryParse( edAmount.Text, out amount ) ) {
            amount = 0;
        }
        
        this.Expense = new Expense { Date = date, Amount = amount, Type = type };
        this.Close();
    }

    private void OnCancel()
    {
        this.Expense = null;
        this.Close();
    }

    public Expense? Expense { get; set; }
}
