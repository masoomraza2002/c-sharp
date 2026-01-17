// using System;

// class Ind
// {
//     private string[] stu = new string[5];

//     public string this[int ind]
//     {
//         get
//         {
//             if(ind < 0 || ind >= stu.Length) return "invalid";
//             return stu[ind];
//         }
//         set
//         {
//             if(ind >= 0 && ind < stu.Length)
//             {
//                 stu[ind] = value;
//             }
//         }
//     }
// }

// class MainInd
// {
//     public static void mainInd()
//     {
//         Ind ll  = new Ind();
//         ll[0] = "masoom";
//         ll[1] = "arsj";
//         Console.WriteLine(ll[1]);
//     }
// }

