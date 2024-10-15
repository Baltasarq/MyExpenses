// Expenses (c) 2024 Baltasar MIT License <baltasarq@gmail.com>


using MyExpenses.Core;
using NUnit.Framework;

namespace Tests;


[TestFixture]
public class TestExpensesControl {
    public TestExpensesControl()
    {
        this.SetUp();    
    }
    
    [SetUp]
    public void SetUp()
    {
        this._expenses = new ExpensesControl();
        this._expense1 = new Expense { Amount = 0.1, Date = DateTime.Now, Type = Expense.Kind.Food };
        this._expense2 = new Expense { Amount = 0.1, Date = DateTime.Now, Type = Expense.Kind.Clothing };
        this._expense3 = new Expense { Amount = 0.1, Date = DateTime.Now, Type = Expense.Kind.Leisure };
        this._vexpenses = new Expense[] { this._expense1, this._expense2, this._expense3 };
    }    

    [Test]
    public void TestEmpty()
    {
        Assert.That( this._expenses.Count, Is.EqualTo( 0 ) );
    }
    
    [Test]
    public void TestAdd()
    {
        int loaded = 0;

        // Load
        foreach (var exp in this._vexpenses) {
            this._expenses.Add( exp );
            ++loaded;
            Assert.That( this._expenses.Count, Is.EqualTo( loaded ) );    
        }
        
        // Test
        for(int i = 0; i < this._expenses.Count; ++i) {
            Assert.That( this._expenses.Get( i ) == this._vexpenses[ i ] );
        }
    }

    [Test]
    public void TestAll()
    {
        // Load
        foreach (var exp in this._vexpenses) {
            this._expenses.Add( exp );
        }
        
        // Load
        var all = this._expenses.All;
        
        // Test
        for(int i = 0; i < this._expenses.Count; ++i) {
            Assert.That( this._expenses.Get( i ) == all[ i ] );
        }
        
        all.RemoveAt( 0 );
        Assert.That( this._expenses.Count, Is.EqualTo( all.Count + 1 ) );
    }

    [Test]
    public void TestTotal()
    {
        ulong total = 0;
        
        // Load
        foreach (var exp in this._vexpenses) {
            this._expenses.Add( exp );
            total += exp.AmountInCents;
        }
        
        Assert.That( total / 100.0,  Is.EqualTo( this._expenses.Total() ) );
    }

    private ExpensesControl _expenses;
    private Expense[] _vexpenses;
    private Expense _expense1;
    private Expense _expense2;
    private Expense _expense3;
}
