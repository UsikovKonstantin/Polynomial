using ClassLibraryPolynomial;

Polynomial pol, pol2, pol3;

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
Console.WriteLine(pol.GetValue(2));

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
Console.WriteLine(p + p2);
