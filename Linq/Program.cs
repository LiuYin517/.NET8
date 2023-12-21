// See https://aka.ms/new-console-template for more information

using Linq;

var list = new List<Employee>();
list.Add(new Employee(){Id = 1,Name = "jerry",Age = 28,Gender = true,Salary = 5000});
list.Add(new Employee(){Id = 2,Name = "jim",Age = 33,Gender = true,Salary = 3000});
list.Add(new Employee(){Id = 3,Name = "lily",Age = 35,Gender = false,Salary = 9000});
list.Add(new Employee(){Id = 4,Name = "lucy",Age = 16,Gender = false,Salary = 2000});
list.Add(new Employee(){Id = 5,Name = "kimi",Age = 25,Gender = true,Salary = 8000});
list.Add(new Employee(){Id = 6,Name = "nancy",Age = 35,Gender = false,Salary = 4500});
list.Add(new Employee(){Id = 7,Name = "zack",Age = 27,Gender = true,Salary = 6000});
list.Add(new Employee(){Id = 8,Name = "jack",Age = 45,Gender = false,Salary = 3000});
list.Add(new Employee(){Id = 9,Name = "day",Age = 33,Gender = true,Salary = 5000});

/*
 * Where关键字，遍历集合中每一个元素
 * e代表当前元素，如果条件为True
 * 则返回到一个集合中
 */
var result = list.Where(e => e.Age >= 30);
foreach (var i in result)
{
    Console.WriteLine(i);
}
/*
 *  Single关键字，有且只有一条满足要求的数据
 * 如果查询的集合里有多条，或没有满足要求的数据，会报错。
 */
var s1 = list.Single(e=>e.Age==27);
Console.WriteLine(s1); //Id=7,Name=zack,Age=27,Gender=True,Salary=6000
                       
 
 /*
  * SingleOrDefault关键字，最多只有一条满足要求的数据。
  * 如果查询的集合里有多条，或没有满足要求的数据，会返回数据的默认值。
  */
 var s2 = list.SingleOrDefault(e => e.Id == 10);
Console.WriteLine(s2==null);//True
                            
  
 /*
  *  First关键字，至少有一条，返回第一条。
  *  如果有多条数据会返回第一条，如果没有满足条件的数据，会报错
  */
 var f1 = list.First(e => e.Age > 35);
Console.WriteLine(f1);//Id=8,Name=jack,Age=45,Gender=False,Salary=3000

  
 /*
  *  FirstOrDefault关键字，返回第一条或者默认值。
  * 如果有多条数据会返回第一条，如果没有满足条件的数据，会返回默认值。
  */
  
 var f2 = list.First(e => e.Salary > 4000);
 Console.WriteLine(f2.Name);//jerry
/*
 * OrderBy关键字，根据条件对数据进行正序排序。
 * OrderByDescending关键字，根据条件对数据进行倒序排序。
 */
 var o1 = list.OrderBy(e=>e.Salary);
 foreach (var i in o1)
 {
  Console.WriteLine(i); 
  /*
     Id=4,Name=lucy,Age=16,Gender=False,Salary=2000
     Id=2,Name=jim,Age=33,Gender=True,Salary=3000
     Id=8,Name=jack,Age=45,Gender=False,Salary=3000
     Id=6,Name=nancy,Age=35,Gender=False,Salary=4500
     Id=1,Name=jerry,Age=28,Gender=True,Salary=5000
     Id=9,Name=day,Age=33,Gender=True,Salary=5000
     Id=7,Name=zack,Age=27,Gender=True,Salary=6000
     Id=5,Name=kimi,Age=25,Gender=True,Salary=8000
     Id=3,Name=lily,Age=35,Gender=False,Salary=9000
     
   */
 }
 
 /*
  * 聚合函数
  * Max(),获取最大值
  * Min(),获取最小值
  * Average(),获取平均值
  */
  var m1=list.Max(e=>e.Id);
  Console.WriteLine(m1);// 9
  var m2 = list.Min(e=>e.Salary);
  Console.WriteLine(m2);//2000
  var a1= list.Average(e=>e.Salary);
  Console.WriteLine(a1);//5055.555555555556

/*
 * GroupBy()分组
 * 它会返回一个字典类型
 * key代表条件查询的元素类型值
 * 对应的值是符合条件对应的集合
 * 以下代码是根据年龄分组，返回年龄相同的集合为一组
 */
  var g1 = list.GroupBy(e => e.Age);
  foreach (var g in g1)
  {
    Console.WriteLine(g.Key);
    Console.WriteLine($"最大工资：{g.Max(e=>e.Salary)}");
    foreach (var i in g)
    {
        Console.WriteLine(i);
    }
    Console.WriteLine("***********************************");
  }
  
/*
 * Select()投影
 * 把集合中的每一项转换为另外一种类型
 */
//通过Select取出集合所有中符合条件的元素，返回到另一个集合中。
 var s = list.Select(e=>e.Name);
 foreach (var i in s)
 {
    Console.WriteLine(i);
 }
//以下代码解释为根据年龄筛选条件，在根据ID排序，取出所有工资信息
 var s3 = list.Where(e => e.Age >= 30).OrderBy(e => e.Id).Select(e => e.Salary);
 foreach (var i in s3)
 {
   Console.WriteLine(i);
 }
 //以下代码根据年龄分组，使用投影生成一个匿名类型。
 var i1 = list.GroupBy(e=>e.Age).Select(g=>new {Age=g.Key,MaxS=g.Max(e=>e.Salary),MinS=g.Min(e=>e.Salary),RenShu=g.Count()});
 foreach (var i in i1)
 {
   Console.WriteLine($"{i.Age}年龄组，最大工资{i.MaxS},最小工资{i.MinS},人数为{i.RenShu}人");
 }