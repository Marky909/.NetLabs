using Delegate;

//DelegateExample D = new DelegateExample();
//DelegateExample.MyDel del = D.Func;
//Console.WriteLine("function called one time via delegate");
//del();

//Console.WriteLine("function called second time via delegate");
//del();


Calc c = new Calc();
MyDel Deli = c.Sum;
Deli += c.Diff;
Deli += c.Product;
Deli += c.Div;
Deli(5, 6);
Deli -= c.Diff;
Deli += c.Modulus;
Deli(3, 2);
