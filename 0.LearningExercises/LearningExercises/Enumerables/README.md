# IEnumerables and LINQ

## What is IEnumerable?

`IEnumerable<T>` is an interface in C# that represents a sequence of elements that can be enumerated (iterated) one at a time. Any collection-like data structure in C#—such as arrays, lists, dictionaries, sets, and even strings—implements `IEnumerable` or `IEnumerable<T>`. This means you can use the same iteration patterns for all these types.

---

## Iterating with foreach

The most common way to process elements in an `IEnumerable` is with the `foreach` loop:

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
foreach (int n in numbers)
{
    Console.WriteLine(n);
}
```
**Output:**
```
1
2
3
4
5
```

---

## Introduction to LINQ

LINQ (Language Integrated Query) is a set of methods that make it easy to query and manipulate data in any `IEnumerable` collection. LINQ methods are available by adding `using System.Linq;` at the top of your file.

Here are some of the most common LINQ methods:

### 1. Where
Filters elements based on a condition.

```csharp
using System.Linq;
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var even = numbers.Where(n => n % 2 == 0);
foreach (int n in even)
{
    Console.WriteLine(n);
}
```
**Output:**
```
2
4
```

### 2. Select
Projects each element into a new form.

```csharp
using System.Linq;
var numbers = new List<int> { 1, 2, 3 };
var squares = numbers.Select(n => n * n);
foreach (int n in squares)
{
    Console.WriteLine(n);
}
```
**Output:**
```
1
4
9
```

### 3. OrderBy
Sorts elements by a key.

```csharp
using System.Linq;
var words = new List<string> { "pear", "apple", "banana" };
var sorted = words.OrderBy(w => w);
foreach (string w in sorted)
{
    Console.WriteLine(w);
}
```
**Output:**
```
apple
banana
pear
```

### 4. ToList
Converts an `IEnumerable` to a `List`.

```csharp
using System.Linq;
var numbers = new int[] { 1, 2, 3 };
List<int> list = numbers.ToList();
Console.WriteLine(list.Count);
```
**Output:**
```
3
```

---

## Practice Exercise

Write a C# program that demonstrates the use of `IEnumerable` and LINQ methods. The program should:
- Create an array of integers from 1 to 100.
- Use `Where` to filter even numbers.
- Use `Select` to square those even numbers.
- Sort the squared numbers in descending order.
- Print the first 10 squared numbers.