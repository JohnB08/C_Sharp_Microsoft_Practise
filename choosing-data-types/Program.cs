
/* Value types */

/* These are stored directly in the stack, or the memory allocated to the code currently running on the cpu. Are limited in size.*/

Console.WriteLine("Signed integral types:");

/* Signed types represent positive and negative numbers. */
Console.WriteLine($"sbyte: {sbyte.MinValue} to {sbyte.MaxValue}");
Console.WriteLine($"short: {short.MinValue} to {short.MaxValue}");
Console.WriteLine($"int: {int.MinValue} to {int.MaxValue}");
Console.WriteLine($"long: {long.MinValue} to {long.MaxValue}");

Console.WriteLine("\nUnsigned integral types: ");

/* Unsigned only positive. */
Console.WriteLine($"sbyte: {byte.MinValue} to {byte.MaxValue}");
Console.WriteLine($"short: {ushort.MinValue} to {ushort.MaxValue}");
Console.WriteLine($"int: {uint.MinValue} to {uint.MaxValue}");
Console.WriteLine($"long: {ulong.MinValue} to {ulong.MaxValue}");


Console.WriteLine("\nFloating point types:");
Console.WriteLine($"float: {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
Console.WriteLine($"double: {double.MinValue} to {float.MaxValue} (with ~15-17 digits of precision)");
Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");

/* Reference types */

/* These are stored in the heap, a memory area shared across many applications. 
Can hold larger values than value types. 
Initialized by using the new keyword to createa an instance of the class.*/

/* Arrays. */
int[] data = new int[3];

/* Strings. */
string shortenedString = "Hello world!";

/* Equivalent to: */
string shortenedStringTwo = new string("Hello World!");

/* Copying Value types: */
int val_A = 2;
/* This is copying a value. */
int val_B = val_A;
/* Overriding the copy, but the original remains intact. */
val_B = 5;
Console.WriteLine($"val_A: {val_A}\nVal_B: {val_B}");

/* Copying Reference types: */

int[] ref_A = new int[1];
ref_A[0] = 2;
/* Creating a copy of ref_A */
int[] ref_B = ref_A;
/* Assigning a new value to the copy, also assignes the original.
Since the copy is just a reference. */
ref_B[0] = 5;
Console.WriteLine($"ref_A: {ref_A[0]}\nref_B: {ref_B[0]}");





