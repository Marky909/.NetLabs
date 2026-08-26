
////1D array
//using System;
//Console.Write("Enter the size of array: ");
//int n = Convert.ToInt32(Console.ReadLine());
//int[] numbers = new int[n];
//int SumResult = 0;

//for (int i = 0; i< n;i++)
//{
//    Console.Write($"Enter the element for array {i}: ");
//    numbers[i] = Convert.ToInt32(Console.ReadLine());


//    SumResult += numbers[i]; 

//}

//Console.WriteLine($"The sum of the elements of the array is : {SumResult}");

////Rectangular matrix
//using System;

//class Program
//{
//    static void Main()
//    {
//        int[,] marks =
//        {
//            {80,85,90},
//            {70,75,88},
//            {95,99,92}
//        };

//        for (int row = 0; row < 3; row++)
//        {
//            for (int col = 0; col < 3; col++)
//            {
//                Console.Write(marks[row, col] + " ");
//            }

//            Console.WriteLine();
//        }
//    }
//}

////jagged array
//using System;

//class Program
//{
//    static void Main()
//    {
//        int[][] scores =
//        {
//            new int[] {80,85},
//            new int[] {70,75,88},
//            new int[] {95}
//        };

//        for (int i = 0; i < scores.Length; i++)
//        {
//            for (int j = 0; j < scores[i].Length; j++)
//            {
//                Console.Write(scores[i][j] + " ");
//            }

//            Console.WriteLine();
//        }
//    }
//}