# Data Structures in C#

This lesson introduces common data structures in C#: arrays, lists, dictionaries, and sets. Each section includes simple code snippets and their outputs.

---

## 1. Arrays

Arrays are fixed-size collections of elements of the same type. Items in an array can be accessed using an index, starting from 0. The size of an array is defined at the time of creation and cannot be changed. The number of elements can be read using the `Length` property.

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
Console.WriteLine(numbers[2]);
Console.WriteLine(numbers.Length);
```
**Output:**
```
3
5
```

---

## 2. Lists

Lists (`List<T>`) are dynamic collections that can grow or shrink. They provide more flexibility than arrays, allowing you to add or remove items at runtime. The number of elements can be read using the `Count` property.

```csharp
using System.Collections.Generic;

List<string> fruits = new List<string>();
fruits.Add("apple");
fruits.Add("banana");
fruits.Add("orange");
Console.WriteLine(fruits[1]);
Console.WriteLine(fruits.Count);
```
**Output:**
```
banana
3
```

---

## 3. Dictionaries

Dictionaries (`Dictionary<TKey, TValue>`) store key-value pairs for fast lookup. You can access values using their keys, and the collection can grow dynamically. The `ContainsKey` method checks if a key exists in the dictionary. The number of key-value pairs can be read using the `Count` property.

```csharp
using System.Collections.Generic;

Dictionary<string, int> ages = new Dictionary<string, int>();
ages["Alice"] = 21;
ages["Bob"] = 25;
Console.WriteLine(ages["Bob"]);
Console.WriteLine(ages.ContainsKey("Charlie"));
Console.WriteLine(ages.Count);
```
**Output:**
```
25
False
2
```

---

## 4. Sets

Sets (`HashSet<T>`) store unique elements and are useful for membership tests. They do not allow duplicate values and provide efficient methods for adding, removing, and checking for existence of items. The `Count` property returns the number of elements in the set.

```csharp
using System.Collections.Generic;

HashSet<int> uniqueNumbers = new HashSet<int>();
uniqueNumbers.Add(1);
uniqueNumbers.Add(2);
uniqueNumbers.Add(2); // Duplicate, will not be added
Console.WriteLine(uniqueNumbers.Contains(2));
Console.WriteLine(uniqueNumbers.Count);
```
**Output:**
```
True
2
```

---

## 5. Practice Exercise

Write a C# program that:
- Reads a list of names from the user.
- Stores them in a list.
- Prints the number of unique names using a set.


