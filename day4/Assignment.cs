// using System;
// using System.Collections.Generic;

// sealed class Security
// {
//     public void Authenticate()
//     {
//         Console.WriteLine("authenticated");
//     }
// }

// abstract class Insurance
// {
//     public int policyNumber { get; init; }
//     public string HolderName { get; set; }

//     private double premium;
//     public double Premium
//     {
//         get => premium;
//         set
//         {
//             if (value <= 0) throw new ArgumetException("must be greater than 0");
//             premium = value;
//         }
//     }

//     public virtual double CalPrem()
//     {
//         return Premium;
//     }

//     public void ShowPolicy()
//     {
//         Console.WriteLine("insurance policy");
//     }
// }



// class LifeIns : Insurance
// {
//     private const double lifeCharge = 500;
//     public override double CalPrem()
//     {
//         return Premium + lifeCharge;
//     }

//     public new void ShowPolicy()
//     {
//         Console.WriteLine("life ins policy");
//     }
// }



// class HealthIns : Insurance
// { 
//     public sealed override double CalPrem()
//     {
//         return Premium  * 2;
//     }
     
// }


// class Policy
// {
//     private List<Insurance> ll = new List<Insurance>();

//     public void AddPolicy(Insurance policy)
//     {
//         ll.Add(policy);
//     }

//     public Insurance this[int ind]
//     {
//         get => ll[ind];
//     }

//     public Insurance this[String name]
//     {
//         get
//         {
//             foreach(var l in ll)
//             {
//                 if (l.HolderName == name) return l;
                
//             }
//             return null;
//         }
//     }
// }




// class Main8
// {
//     static void main8()
//     {
//         Security sec = new Security();
//         sec.Authenticate();
//         Console.WriteLine();

//         LifeIns life = new LifeIns
//         {
//             policyNumber = 101,
//             HolderName = "amit",
//             Premium = 5000
//         };

//         HealthIns health = new HealthIns
//         {
//             policyNumber = 102,
//             HolderName = "neha",
//             Premium = 4000
//         };

//         Policy pol = new Policy();
//         pol.AddPolicy(life);
//         pol.AddPolicy(health);

//         Console.WriteLine(pol[0].HolderName);
//         Console.WriteLine(pol["neha"].policyNumber);

//         Insurance p1 = life;
//         Insurance p2 = health;

//         Console.WriteLine("Life prem " + p1.CalPrem());
//         Console.WriteLine("health prem " + p2.CalPrem());


//         life.ShowPolicy();
//         p1.ShowPolicy();
//     }
// }