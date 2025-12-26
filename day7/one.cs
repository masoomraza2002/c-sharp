using System;

class One
{
    public static void one()
    {
        int[] arr = {-1,2,3,4,5,5,44};
        foreach(int i in arr)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();

        int[,] arr2 =
        {
            {1,2,4},
            {3,5,6}
        };
        Console.WriteLine(arr2[0,2]);

        for(int i = 0; i < arr2.GetLength(0); i++)
        {
            for(int j = 0; j < arr2.GetLength(1); j++)
            {
                Console.Write(arr2[i,j]+" ");
            }
            Console.WriteLine();
        }

        int[][] jagged = new int[2][];
        jagged[0] = new int[]{1,2};
        jagged[1] = new int[]{3,4,5};
        Console.WriteLine(jagged[1][2]);

        for(int i = 0; i < jagged.Length; i++)
        {
            for(int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j]+ " ");
            }
            Console.WriteLine();
        }

        //clear
        Array.Clear(arr,0,2);
        foreach(int i in arr)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();


        //copy
        int[] src = [1,2,3];
        int[] des = [4,5,6];

        Array.Copy(src,des , 2);
        foreach(int i in src)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();
        foreach(int i in des)
        {
            Console.Write(i+" ");
        }
        // Array.Copy(src, des , 2);
        // foreach(int i in arr)
        // {
        //     Console.Write(i+" ");
        // }
    }
}