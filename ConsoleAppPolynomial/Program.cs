using ClassLibraryPolynomial;

Polynomial pol;

// 1
pol = new Polynomial();
Console.WriteLine(pol);

// 2.1
pol = new Polynomial(4);
Console.WriteLine(pol);

// 2.2
pol = new Polynomial(0);
Console.WriteLine(pol);

// 3.1
pol = new Polynomial(4, 5, -6, 1, -1, 0, 8);
Console.WriteLine(pol);

// 3.2
pol = new Polynomial(new double[] { 0, 1, -1, 8 });
Console.WriteLine(pol);

// 4
pol = new Polynomial(new List<double> { -1, 2, 3, 4, 5 });
Console.WriteLine(pol);

// 5
pol = new Polynomial(10, -5.3, 5.9, 2);
Console.WriteLine(pol);

// 6
pol = new Polynomial(10, -5, 5);
Console.WriteLine(pol);