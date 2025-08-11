# String Manipulation

Strings are sequences of characters used to represent text. In C#, strings are objects of the System.String class and are immutable (cannot be changed after creation). String manipulation is a common task in programming, such as formatting output, parsing input, or processing data.

---

## 1. Declaring and Initializing Strings

Strings in C# can be declared using double quotes. Here are some examples:

```csharp
string greeting = "Hello, World!";
string empty = "";
Console.WriteLine(greeting);
```
**Output:**
```
Hello, World!
```

---

## 2. String Concatenation

You can concatenate strings using the `+` operator or string interpolation.

```csharp
string firstName = "Jane";
string lastName = "Doe";
string fullName = firstName + " " + lastName;
Console.WriteLine(fullName);
```
**Output:**
```
Jane Doe
```

---

## 3. String Interpolation

You can use string interpolation to embed expressions within a string. This is done using the `$` symbol before the string; and curly braces `{}` to include variables or expressions.

```csharp
int age = 20;
string message = $"Name: {fullName}, Age: {age}";
Console.WriteLine(message);
```
**Output:**
```
Name: Jane Doe, Age: 20
```

---

## 4. Common String Methods

C# provides many built-in methods for string manipulation. Here are some commonly used methods. Remember that strings are immutable, so these methods return a new string rather than modifying the original.

**Length:**

Returns the number of characters in the string. Notice that this is not a method, but a property (i.e., no parentheses).

```csharp
Console.WriteLine(fullName.Length);
```
**Output:**
```
8
```

**ToUpper / ToLower:**

Creates a new string with all characters converted to uppercase or lowercase. 

```csharp
Console.WriteLine(fullName.ToUpper());
Console.WriteLine(fullName.ToLower());
```
**Output:**
```
JANE DOE
jane doe
```

**Substring:**

Creates a substring from the original string given an index and the length of the desired substring.

```csharp
Console.WriteLine(fullName.Substring(0, 4));
```
**Output:**
```
Jane
```

**Replace:**

You can replace occurrences of a specified substring with another substring. You can also use `Replace` to remove substrings by replacing with an empty string.

```csharp
Console.WriteLine(fullName.Replace("Jane", "John"));
Console.WriteLine(fullName.Replace(" Doe", ""));
```
**Output:**
```
John Doe
John
```

**Trim**

Trims whitespace from the beginning and end of a string.

```csharp
string input = "  hello  ";
Console.WriteLine(input.Trim());
```

**Output:**
```
hello
```

**Split:**

Creates an array of substrings based on a specified delimiter. The delimiter can be a character or a string.

```csharp
string csv = "apple,banana,orange";
string[] fruits = csv.Split(',');
Console.WriteLine(fruits[1]);
```
**Output:**
```
banana
```

**Join:**

On the other hand, you can join an array of strings into a single string with a specified delimiter.

```csharp
string joined = string.Join(" | ", fruits);
Console.WriteLine(joined);
```
**Output:**
```
apple | banana | orange
```

---

## 5. String Comparison

You can compare strings using the `==` operator or the `Equals` method. The `==` operator checks for value equality, while `Equals` can also take a `StringComparison` parameter to specify how the comparison should be done (e.g., case-sensitive or case-insensitive).

```csharp
Console.WriteLine(firstName == "Jane");
Console.WriteLine(firstName.Equals("jane", StringComparison.OrdinalIgnoreCase));
```
**Output:**
```
True
True
```

---

## 6. Escape Sequences

Special characters in strings can be represented using escape sequences, which begin with the `\` (backslash) character. Common escape sequences include:
- `\\` - Backslash (since `\` is used for escaping, a double backslash is "escaped" into a single one)
- `\"` - Double quote
- `\n` - New line
- `\t` - Tab

```csharp
string path = "C:\\Users\\Student";
string multiline = "Line1\nLine2";
Console.WriteLine(path);
Console.WriteLine(multiline);
```
**Output:**
```
C:\Users\Student
Line1
Line2
```

---

## 7. Practice Exercise

Write a C# program that:
- Asks the user for their full name.
	- Use `Console.ReadLine()` to get input in a console application.
- Prints the name in uppercase.
- Prints the number of characters (excluding spaces).
- Prints the initials.


