using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("add", number1, number2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("+", number1, number2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("subtract", number1, number2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("-", number1, number2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 2;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("multiply", number1, number2);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 2;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("*", number1, number2);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void DevidesTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 4;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("devide", number1, number2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void DevidesTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 4;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("/", number1, number2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FailsToAddTwoNumbersAndReturnResultForNonSymbolOperation()
        {
            int number1 = 4;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("add them", number1, number2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FailsToAddTwoNumbersAndReturnResultForSymbolOperation()
        {
            int number1 = 4;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("$", number1, number2);
        }
    }
}

