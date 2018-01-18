## Data Structures, Algorithms and Complexity
### _Homework_

1. What is the expected running time of the following C# code? Explain why.
  - Assume the array's size is `n`.

```cs
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)
    {
        int start = 0, end = arr.Length-1;
        while (start < end)
            if (arr[start] < arr[end])
                { start++; count++; }
            else 
                end--;
    }
    return count;
}
```

    -   Explanation:
        -   Let`s start by analyzing the innermost code inside the loops. The if - else structure inside the while loop will execute with constant time complexity as its operations do not depend in any way on the size of the array.
        -   The times the code inside the while loop will execute depends on the while breaking condition.
        -   This condition on the other hand, depends on the arr.Length, which is 'n'. So we can say that it is linearly dependent on n.
        -   So far, all code inside the while loop is linearly dependent on 'n' and has constant time complexity. The while loop`s complexity is O(n).
        -   The code line before the while loop is simple variable assignment, and again its time complexity doesn`t depend on the size of the array. It is a constant, that depends on the hardware and software ect.
        -   So far all the code inside the for loop has time complexity O(n).
        -   It will be executed exactly 'n' times since the for loop upper limit is arr.Length and the step is 1.
        -   So, the total time complexity of the for loop and the code inside it is n*O(n) = O(n*n). It is dependent on the square of 'n' - O(n*n).
        -   The assignment statement on the first line and return statement on last line will execute exactly once, regardless of the array`s size, so their time complexity is constant again.
        -   The total time complexity for this method is O(n*n)

2. What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

```cs
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++)
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++)
                if (matrix[row,col] > 0)
                    count++;
    return count;
}
```

    -   Explanation
        -   Again let`s start with the innermost condition. The if construct has constant time complexity O(1).
        -   It will get executed exactly 'm' times, because of the parent for loop.
        -   This parent loop will execute at worst 'n' times, because it is in another for loop that iterates the first matrix size. We can disregard the if construct, because for time complexity Big O evaluation we take into account the worst possible scenario (assuming all matrix values are divisible by 2).
        -   So the inner loop`s compelxity is O(m) and it will get executed 'n' times at worst case scenario. The total time complexity is O(n*m).


3. * What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

```cs
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    for (int col = 0; col < matrix.GetLength(0); col++) 
        sum += matrix[row, col];
    if (row + 1 < matrix.GetLength(1)) 
        sum += CalcSum(matrix, row + 1);
    return sum;
}

Console.WriteLine(CalcSum(matrix, 0));
```

    -   Explanation
        -   The for loop will execute its code exactly 'n' times. The code inside has constant complexity (it is not dependent on the matrix size).
        -   The if condition will be true exactly 'm' times and  so will call the method recursively and therefore the for loop recursively m times.
        -   The for loop has O(n) complexity and will be called 'm' times, so the total complexity for the method is m*O(n) = O(n*m).