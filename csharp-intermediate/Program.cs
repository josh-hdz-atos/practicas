using System;

namespace csharp_intermediate
{
    class Program
    {
        static void Main(string[] args)
        {
          //-------------------- 1) Ternary operator --------------------------
          int random = new Random().Next(0, 1000);
          String description = random > 500 ? "Greater than 500" : "Less than 500";
          Console.WriteLine(description);
          //-------------------- 2) Exeptions and nullables --------------------------
          try{
            int? nil = null;
            Console.WriteLine(nil == null ? throw new NullExeption("Nullable values require check statement") : "valid value");
          }
          catch (NullExeption err) {
            Console.WriteLine(err.Message);
          }

          //-------------------- 3) Anonymous and dynamic types   --------------------------
          var anonymous = new { name="anonymous", age=43 };
          Console.WriteLine($"name:{anonymous.name}\nage:{anonymous.age}");

          dynamic dyno = 10;
          Console.WriteLine(dyno);

          dyno = "dynamic value";
          Console.WriteLine(dyno);

          dyno = new { val1=1, val2 = "dos", val3=3.0 };
          Console.WriteLine($"val1:{dyno.val1}\nval2:{dyno.val2}\nval3:{dyno.val3}");

          //-------------------- 4) Generics and Indexers --------------------------
          var map = new Map<derived>(4);

          try
          {
            map[0] = new derived("Hola1234" ,"osi osi");
            Console.WriteLine(map[0]);
            map[1] = new derived("Adios4321", "ono ono");
            Console.WriteLine(map[1]);
            map["Jordan"] = new derived("Jordan", 23);
            Console.WriteLine(map["Jordan"]);
            map[2] = new derived("kobe", 24);
            Console.WriteLine(map["Jordan"]);
          }
          catch (ArgumentException err)
          { 
            Console.WriteLine(err.Message);
            Console.WriteLine(map["kobe"]);


          }
          //-------------------- 5) Extenssion method --------------------------
          Console.WriteLine(map.First());
          //-------------------- 5) Regex --------------------------
          Console.WriteLine("kobe".ValidKey());
        }
    }
}
