# Checkout Kata

Implement the code for a checkout system that handles pricing schemes such as "pineapples cost 50, three pineapples cost 130."

Implement the code for a supermarket checkout that calculates the total price of a number of items. In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. In our store, we’ll use individual letters of the alphabet (A, B, C, and so on). Our goods are priced individually. In addition, some items are multi-priced: buy n of them, and they’ll cost you y pence. For example, item A might cost 50 individually, but this week we have a special offer: buy three As and they’ll cost you 130. In fact the prices are:

| SKU | Unit Price | Special Price |
| --- | ---------- | ------------- |
| A   | 50         | 3 for 130     |
| B   | 30         | 2 for 45      |
| C   | 20         |               |
| D   | 10         |               |

The checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two Bs and price them at 45 (for a total price so far of 95). **The pricing changes frequently, so pricing should be independent of the checkout.**

The interface to the checkout could look like:

``` csharp
interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}
```

## Additional guidance

Timebox to 30-60 minutes.

Mocking frameworks will not be required for this kata. Be sure to commit to version control frequently.

Your code should adhere to SOLID principles:

* **S**ingle responsibility principle
* **O**pen/closed principle
* **L**iskov substitution principle
* **I**nterface segregation principle
* **D**ependency inversion principle

Don't worry about reaching a full solution, we're interested in seeing your process and approach. Commit often to show red, green, refactor and solution evolution along with a growing design / complexity to bring in software design principles when required etc.

The checkout kata is designed on purpose to be a simple problem so you see the overarching solution from the outset, however the trick is not jump in to the big solution first but re-enforce TDD approaches of only implement the very smallest thing possible first, then the next then the next. True TDD promotes this practice, so consider Kent Becks ‘TDD by Example’ for the approach (<https://www.amazon.co.uk/Test-Driven-Development-Addison-Wesley-Signature/dp/0321146530)>.

In normal work, problems are big and hard to see the big solution, so TDD in the work place should still be, smallest thing first and grow, iterate and adapt the design. The kata is a way to practice and sharpen your sword with that approach
