using ClassLibraryPolynomial;
using System.Diagnostics;

Polynomial pol, pol2;

// 1
pol = new Polynomial();
Console.WriteLine(pol);

// 2.1
pol = new Polynomial(4);
Console.WriteLine(pol);

// 2.2
pol = new Polynomial(0);
Console.WriteLine(pol);

// 3
pol = new Polynomial(new double[] { 0, 1, -1, 8 });
Console.WriteLine(pol);

// 4
pol = new Polynomial(new double[] { -1, 2, 3, 4, 5 });
Console.WriteLine(pol);

// 5
pol = new Polynomial(10, -5.3, 5.9, 2);
Console.WriteLine(pol);

// 6
pol = new Polynomial(10, -5, 5);
Console.WriteLine(pol);


pol = new Polynomial(new double[] { 3, 2, 1, });
Console.WriteLine(pol.P(2));

pol = new Polynomial(new double[] { 1, 5, 9, 1, 1 });
Console.WriteLine(pol);
Console.WriteLine(pol.GetDerivative());

pol = new Polynomial(new double[] { 1 });
Console.WriteLine(pol);
Console.WriteLine(pol.GetDerivative());


pol = new Polynomial(new double[] { 1, 5, 8 });
pol2 = new Polynomial(new double[] { 2, 3 });
Console.WriteLine(pol + pol2);

pol = new Polynomial(new double[] { 1, 5, 8 });
pol2 = new Polynomial(new double[] { 2, 3 });
Console.WriteLine(pol - pol2);


pol = new Polynomial(new double[] { 1, 1, 1 });
Console.WriteLine(pol);
pol2 = new Polynomial(new double[] { 1, 1 });
Console.WriteLine(pol2);
Console.WriteLine(pol * pol2);


pol = new Polynomial(new double[] { 6, 1, 0, 4, 0, 2 });
Console.WriteLine(pol);
pol2 = new Polynomial(new double[] { 3, 4, 0, 4 });
Console.WriteLine(pol2);
Console.WriteLine(pol / pol2);

pol = new Polynomial(new double[] { 6, 1, 0, 4, 0, 2 });
Console.WriteLine(pol);
pol2 = pol * 2;
Console.WriteLine(pol2);


pol = new Polynomial(new double[] { 1, 1, 1 });
Console.WriteLine(pol);
pol2 = new Polynomial(new double[] { 1, 1, 1 });
Console.WriteLine(pol2);
Console.WriteLine(pol == pol2);


PolynomialWithRoots p = new PolynomialWithRoots(new List<double> { 1, 1 });
PolynomialWithRoots p2 = new PolynomialWithRoots(new List<double> { 1, 1 });
Console.WriteLine(p);
//Console.WriteLine(p + p2);

//Console.WriteLine(p / p2);


//p = new PolynomialWithRoots(new double[] { 2, -3, 1});
//var r = p.FindAllStationaryPoints(-100000, 100000);
//foreach (var item in r)
//{
//    Console.WriteLine($"{item}");
//}
//pol = new Polynomial(new double[] { 1, 1, 1 });
//p = new PolynomialWithRoots(new double[] { 1, 1, 1 });
//Stopwatch sw = new Stopwatch();
//sw.Start();
//for (int i = 0; i < 100000000; i++)
//{
//    pol = pol + pol;
//}
//sw.Stop();
//Console.WriteLine(sw.ElapsedMilliseconds);
//sw.Restart();

//for (int i = 0; i < 100000000; i++)
//{
//    p = p + p;
//}
//sw.Stop();
//Console.WriteLine(sw.ElapsedMilliseconds);

//p = new PolynomialWithRoots(new double[] { 2, -3, 1 });
//r = p.FindAllRootsEin(-100000, 100000);
//foreach (var item in r)
//{
//    Console.WriteLine($"{item}");
//}


PolynomialPrediction pp = new PolynomialPrediction();
//Console.WriteLine(pp.GetPredictionPol(new double[] { -1, 0, 1, 2}, new double[] { 4, 2, 0, 1}));
//Console.WriteLine(pp.MNK(3, new double[] { -1, 0, 1, 2 }, new double[] { 4, 2, 0, 1 }));