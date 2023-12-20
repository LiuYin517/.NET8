// See https://aka.ms/new-console-template for more information

#region Lambda表达式

//属于匿名方法
//无返回值的匿方法
Action<string, int> f1 = delegate(string a, int i)
{
    Console.WriteLine($"姓名={a},年龄={i}");
};
f1("大福宝", 2);//姓名=大福宝,年龄=2
             
//有返回值的匿名方法
Func<int, int, int> f2 = delegate(int j, int i)
{
    return j + i;
};
var j = f2(3, 5);
Console.WriteLine(j);// 8
//Lambda写法
Func<int, int, int> f3 = (int i,int j) =>
{
    return i + j;
};
Console.WriteLine(f3(2,5));// 7

Func<int, int, int> f4 = (i,j) =>
{
    return i + j;
};
Console.WriteLine(f4(5,5));// 10

Func<int, int, int> f5 = (j, i) => j + i;
Console.WriteLine(f5(3,8)); // 11


// Func<int,bool> f6 = i =>i>=5;  
Func<int, bool> f6 = delegate(int i)
{
    return i >= 5;
};
var a = f6(9);
Console.WriteLine(a);//True

// Action<string> f7 = s => Console.WriteLine(s);
Action<string> f7 = delegate(string s)
{
    Console.WriteLine(s);
};
f7("hello");

#endregion

