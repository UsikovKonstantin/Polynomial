using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClassLibraryPolynomial;

namespace TestProjectPolynomial
{
    [TestClass]
    public class UnitTestPolinomial
    {
        Polynomial pol, pol2;

        [TestMethod]
        public void PolynomialTest()
        {
            pol = new Polynomial();
            pol2 = new Polynomial(new double[3] { 2, -3, 1 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void PolynomialTest2()
        {
            pol = new Polynomial(5);
            pol2 = new Polynomial(new double[5] { 0, 0, 0, 0, 0 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void AddPolTest()
        {
            pol = new Polynomial(new double[] { 1, 5, 8 });
            pol2 = new Polynomial(new double[] { 2, 3 });
            pol = pol + pol2;
            pol2 = new Polynomial(new double[] { 3, 8, 8 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void AddPolTest2()
        {
            pol = new Polynomial(new double[] { 3, 8, 6, 4, 7 });
            pol2 = new Polynomial(new double[] { 5, 9, 7, 2 });
            pol = pol + pol2;
            pol2 = new Polynomial(new double[] { 8, 17, 13, 6, 7 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void SubPolTest()
        {
            pol = new Polynomial(new double[] { 1, 5, 8 });
            pol2 = new Polynomial(new double[] { 2, 3 });
            pol = pol - pol2;
            pol2 = new Polynomial(new double[] { -1, 2, 8 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void SubPolTest2()
        {
            pol = new Polynomial(new double[] { 3, 2, 9, 7 });
            pol2 = new Polynomial(new double[] { 5, 6, 8, 2 });
            pol = pol - pol2;
            pol2 = new Polynomial(new double[] { -2, -4, 1, 5 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolTest()
        {
            pol = new Polynomial(new double[] { 1, 1, 1 });
            pol2 = new Polynomial(new double[] { 1, 1 });
            pol = pol * pol2;
            pol2 = new Polynomial(new double[] { 1, 2, 2, 1 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolsTest2()
        {
            pol = new Polynomial(new double[] { 5, 2, 1, 3 });
            pol2 = new Polynomial(new double[] { 9, 8, 7, 6 });
            pol = pol * pol2;
            pol2 = new Polynomial(new double[] { 45, 58, 60, 79, 43, 27, 18 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void DivPolsTest()
        {
            pol = new Polynomial(new double[] { 6, 1, 0, 4, 0, 2 });
            pol2 = new Polynomial(new double[] { 3, 4, 0, 4 });
            pol = pol / pol2;
            pol2 = new Polynomial(new double[] { 0.5, 0, 0.5 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void DivPolTest2()
        {
            pol = new Polynomial(new double[] { -12, 7, 5, 3 });
            pol2 = new Polynomial(new double[] { -12, 7, 5, 3 });
            pol = pol / pol2;
            pol2 = new Polynomial(new double[] { 1 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolNumTest()
        {
            pol = new Polynomial(new double[] { 5, 2, 1, 3 });
            pol2 = pol * 2;
            pol = new Polynomial(new double[] { 10, 4, 2, 6 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolNumTest2()
        {
            pol = new Polynomial(new double[] { 5, 2, 1, 3 });
            pol2 = 2 * pol;
            pol = new Polynomial(new double[] { 10, 4, 2, 6 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void ComparisonTest()
        {
            pol = new Polynomial(new double[] { 5, 2, 1, 3 });
            pol2 = new Polynomial(new double[] { 5, 2, 1, 3 });
            Assert.AreEqual(pol == pol2, true);
        }

        [TestMethod]
        public void ComparisonTest2()
        {
            pol = new Polynomial(new double[] { 5, 2, 1, 3 });
            pol2 = new Polynomial(new double[] { 12, 2, 1, 3 });
            Assert.AreEqual(pol == pol2, false);
        }

        [TestMethod]
        public void Comparison2Test()
        {
            pol = new Polynomial(new double[] { 5, 2, 1, 3 });
            pol2 = new Polynomial(new double[] { 5, 2, 1, 3 });
            Assert.AreEqual(pol != pol2, false);
        }

        [TestMethod]
        public void Comparison2Test2()
        {
            pol = new Polynomial(new double[] { 5, 2, 1, 3 });
            pol2 = new Polynomial(new double[] { 12, 2, 1, 3 });
            Assert.AreEqual(pol != pol2, true);
        }

        [TestMethod]
        public void GornersTest()
        {
            pol = new Polynomial(new double[] { 3, 2, 1, });
            Assert.AreEqual(pol.P(2), 11);
        }

        [TestMethod]
        public void GetDerivativeTest()
        {
            pol = new Polynomial(new double[] { 1, 5, 9, 1, 1 });
            pol2 = new Polynomial(new double[] { 5, 18, 3, 4 });
            Assert.AreEqual(pol.GetDerivative(), pol2);
        }

        [TestMethod]
        public void GetDerivativeTest2()
        {
            pol = new Polynomial(new double[] { 1 });
            pol2 = new Polynomial(new double[] { 0 });
            Assert.AreEqual(pol.GetDerivative(), pol2);
        }

        [TestMethod]
        public void GetPrimitiveTest()
        {
            pol = new Polynomial(new double[] { 1, 5, 9, 1, 1 });
            pol2 = new Polynomial(new double[] { 0, 1, 2.5, 3, 0.25, 0.2 });
            Assert.AreEqual(pol.GetPrimitive(), pol2);
        }

        [TestMethod]
        public void GetPrimitiveTest2()
        {
            //0,75x^4 + 3x^3 + 2x^2 + 5x
            pol = new Polynomial(new double[] { 5, 4, 9, 3 });
            pol2 = new Polynomial(new double[] { 0, 5, 2, 3, 0.75 });
            Assert.AreEqual(pol.GetPrimitive(), pol2);
        }

        [TestMethod]
        public void PowTest()
        {
            pol = new Polynomial(new double[] { 1, 5, 9, 1, 1 });
            pol2 = new Polynomial(new double[] { 1, 10, 43, 92, 93, 28, 19, 2, 1 });
            Assert.AreEqual(pol.Pow(2), pol2);
        }

        [TestMethod]
        public void PowTest2()
        {
            pol = new Polynomial(new double[] { 5, 4, 9, 3 });
            pol2 = new Polynomial(new double[] { 125, 300, 915, 1369, 2007, 1926, 1512, 837, 243, 27 });
            Assert.AreEqual(pol.Pow(3), pol2);
        }
    }

    [TestClass]
    public class UnitTestPolynomialWithRoots
    {
        PolynomialWithRoots pol, pol2;
        List<double> test;

        [TestMethod]
        public void PolynomialTest()
        {
            pol = new PolynomialWithRoots();
            pol2 = new PolynomialWithRoots(new double[3] { 2, -3, 1 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void PolynomialTest2()
        {
            pol = new PolynomialWithRoots(5);
            pol2 = new PolynomialWithRoots(new double[5] { 0, 0, 0, 0, 0 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void AddPolTest()
        {
            pol = new PolynomialWithRoots(new double[] { 1, 5, 8 });
            pol2 = new PolynomialWithRoots(new double[] { 2, 3 });
            pol = pol + pol2;
            pol2 = new PolynomialWithRoots(new double[] { 3, 8, 8 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void AddPolTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 3, 8, 6, 4, 7 });
            pol2 = new PolynomialWithRoots(new double[] { 5, 9, 7, 2 });
            pol = pol + pol2;
            pol2 = new PolynomialWithRoots(new double[] { 8, 17, 13, 6, 7 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void SubPolTest()
        {
            pol = new PolynomialWithRoots(new double[] { 1, 5, 8 });
            pol2 = new PolynomialWithRoots(new double[] { 2, 3 });
            pol = pol - pol2;
            pol2 = new PolynomialWithRoots(new double[] { -1, 2, 8 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void SubPolTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 3, 2, 9, 7 });
            pol2 = new PolynomialWithRoots(new double[] { 5, 6, 8, 2 });
            pol = pol - pol2;
            pol2 = new PolynomialWithRoots(new double[] { -2, -4, 1, 5 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolTest()
        {
            pol = new PolynomialWithRoots(new double[] { 1, 1, 1 });
            pol2 = new PolynomialWithRoots(new double[] { 1, 1 });
            pol = pol * pol2;
            pol2 = new PolynomialWithRoots(new double[] { 1, 2, 2, 1 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolsTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            pol2 = new PolynomialWithRoots(new double[] { 9, 8, 7, 6 });
            pol = pol * pol2;
            pol2 = new PolynomialWithRoots(new double[] { 45, 58, 60, 79, 43, 27, 18 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void DivPolsTest()
        {
            pol = new PolynomialWithRoots(new double[] { 6, 1, 0, 4, 0, 2 });
            pol2 = new PolynomialWithRoots(new double[] { 3, 4, 0, 4 });
            pol = pol / pol2;
            pol2 = new PolynomialWithRoots(new double[] { 0.5, 0, 0.5 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void DivPolTest2()
        {
            pol = new PolynomialWithRoots(new double[] { -12, 7, 5, 3 });
            pol2 = new PolynomialWithRoots(new double[] { -12, 7, 5, 3 });
            pol = pol / pol2;
            pol2 = new PolynomialWithRoots(new double[] { 1 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolNumTest()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            pol2 = pol * 2;
            pol = new PolynomialWithRoots(new double[] { 10, 4, 2, 6 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void MulPolNumTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            pol2 = 2 * pol;
            pol = new PolynomialWithRoots(new double[] { 10, 4, 2, 6 });
            Assert.AreEqual(pol, pol2);
        }

        [TestMethod]
        public void ComparisonTest()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            pol2 = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            Assert.AreEqual(pol == pol2, true);
        }

        [TestMethod]
        public void ComparisonTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            pol2 = new PolynomialWithRoots(new double[] { 12, 2, 1, 3 });
            Assert.AreEqual(pol == pol2, false);
        }

        [TestMethod]
        public void Comparison2Test()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            pol2 = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            Assert.AreEqual(pol != pol2, false);
        }

        [TestMethod]
        public void Comparison2Test2()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 2, 1, 3 });
            pol2 = new PolynomialWithRoots(new double[] { 12, 2, 1, 3 });
            Assert.AreEqual(pol != pol2, true);
        }

        [TestMethod]
        public void GornersTest()
        {
            pol = new PolynomialWithRoots(new double[] { 3, 2, 1, });
            Assert.AreEqual(pol.P(2), 11);
        }

        [TestMethod]
        public void GetDerivativeTest()
        {
            pol = new PolynomialWithRoots(new double[] { 1, 5, 9, 1, 1 });
            pol2 = new PolynomialWithRoots(new double[] { 5, 18, 3, 4 });
            Assert.AreEqual(pol.GetDerivative(), pol2);
        }

        [TestMethod]
        public void GetDerivativeTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 1 });
            pol2 = new PolynomialWithRoots(new double[] { 0 });
            Assert.AreEqual(pol.GetDerivative(), pol2);
        }

        [TestMethod]
        public void GetPrimitiveTest()
        {
            pol = new PolynomialWithRoots(new double[] { 1, 5, 9, 1, 1 });
            pol2 = new PolynomialWithRoots(new double[] { 0, 1, 2.5, 3, 0.25, 0.2 });
            Assert.AreEqual(pol.GetPrimitive(), pol2);
        }

        [TestMethod]
        public void GetPrimitiveTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 4, 9, 3 });
            pol2 = new PolynomialWithRoots(new double[] { 0, 5, 2, 3, 0.75 });
            Assert.AreEqual(pol.GetPrimitive(), pol2);
        }

        [TestMethod]
        public void PowTest()
        {
            pol = new PolynomialWithRoots(new double[] { 1, 5, 9, 1, 1 });
            pol2 = new PolynomialWithRoots(new double[] { 1, 10, 43, 92, 93, 28, 19, 2, 1 });
            Assert.AreEqual(pol.Pow(2), pol2);
        }

        [TestMethod]
        public void PowTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 5, 4, 9, 3 });
            pol2 = new PolynomialWithRoots(new double[] { 125, 300, 915, 1369, 2007, 1926, 1512, 837, 243, 27 });
            Assert.AreEqual(pol.Pow(3), pol2);
        }

        [TestMethod]
        public void ExistRootTest()
        {
            pol = new PolynomialWithRoots(new double[] { -6, 2, -1, -4, 3 });
            double a = -2;
            double b = 2;
            Assert.AreEqual(pol.ExistRoot(ref a, ref b, 0), true);
        }

        [TestMethod]
        public void ExistRootTest2()
        {
            pol = new PolynomialWithRoots(new double[] { 1, 5, 9, 1, 1 });
            double a = 0;
            double b = 10;
            Assert.AreEqual(pol.ExistRoot(ref a, ref b, 0), false);
        }

        [TestMethod]
        public void FindRootTest()
        {
            pol = new PolynomialWithRoots(new double[] { 5, -7, 2, 3 });
            Assert.AreEqual(pol.FindRoot(-3,3), -2.129723757505417);
        }
    }
}