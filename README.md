# Smart Sorting API

[![Build Status](https://travis-ci.org/evgomes/smart-sorting.svg?branch=master)](https://travis-ci.org/evgomes/smart-sorting)

Sorting algorithms library to use with .NET Standard. All algorithms work over arrays and enumerations of items that implement IComparable<T> interface.

The following algorithms are implemented:
  - Bubble Sort
  - Heap Sort
  - Insertion Sort
  - Merge Sort
  - Quick Sort
  - Selection Sort

## How to install

Via Nuget Package Manager Console, type:

```
Install-Package SmartSortingAPI -Version 1.0.0
```

Or, via command line tools, type the following:

```
dotnet add package SmartSortingAPI --version 1.0.0
```

## How to use

To use extension methods to sort data, add the following code block at the top of your .CS file: 

```using SmartSorting.Extensions.SortableExtensions;```

If you prefer, you can create instances by hand of the sort algorithms from ```SmartSorting.Algorithms``` namespace.

## Sorting arrays

To sort an array, use extension method ```SortUsing``` as below:

```
int[] array = { 1, 3, 4, 5, 2 };
array.SortUsing(ESortAlgorithm.BubbleSort, ESortOrder.Ascending);
```

The first parameter defines the algorithm to sort the data structure, and the second one indicates wheter we want to sort data in ascending or descending direction.

## Sorting Enumerations

You can sort every data structure that implements ```IEnumerable<T>``` calling ```SortUsing```:

```
var integerEnumeration = new List<int> { 1, 3, 5, 4, 2 };
var orderedEnumeration = integerEnumeration.SortUsing(ESortAlgorithm.MergeSort, ESortOrder.Descending);
```

## Sorting Enumerations of Custom Types

You can also sort arrays and enumerations of your own types and also type from .NET library that implement  ```IComparable<T>```. Let's take a look at the following example:

```
public class TodoItem : IComparable<TodoItem>
{
  public int Id { get; private set; }

  public TodoItem(int id)
  {
    this.Id = id;
  }
  
  public int CompareTo(TodoItem other)
  {
    return this.Id.CompareTo(other.Id);
  }
}
```

The ```TodoItem``` class implements a comparison between other items of the same type by comparing the IDs. With this implementation we have a way to check which items are "smaller than", "bigger than" or equals to others. This way we can sort arrays or enumerations of this type:

```
var enumeration = new List<TodoItem>
{
  new TodoItem(1),
  new TodoItem(5),
  new TodoItem(3),
  new TodoItem(2),
  new TodoItem(4),
};

var orderedEnumeration = enumeration.SortUsing(ESortAlgorithm.SelectionSort, ESortOrder.Ascending);
```

## Fast Sorting with Multiple Algorithms

Sometimes we are not sure about which algorithm will sort our enumeration faster. The library provides an extensions method which we can call to run many sort algorithms asynchronously over an enumeration, this way getting the sorted data structure from the first algorithm that finished its execution. 

```
var enumeration = new List<TodoItem>
{
  new TodoItem(1),
  new TodoItem(5),
  new TodoItem(3),
  new TodoItem(2),
  new TodoItem(4),
};

var resultingEnumeration = await enumeration.FastSortUsingAsync(ESortOrder.Ascending, ESortAlgorithm.BubbleSort, ESortAlgorithm.InsertionSort);
```