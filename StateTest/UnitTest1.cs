using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOM_Seminarski_State;


namespace StateTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InputCalculatorIsSetToAddOnStart()
        {
            InputCalculator calculator = new InputCalculator("asd");
            Assert.AreEqual(calculator.Operator, OperatorState.Add);
        }
        [TestMethod]
        public void OperatorStateChangesBasedOnInput()
        {
            InputCalculator calculator = new InputCalculator("-");
            calculator.Calculate();
            Assert.AreEqual(OperatorState.Subtract,calculator.Operator);
            calculator = new InputCalculator("+");
            calculator.Calculate();
            Assert.AreEqual(OperatorState.Add,calculator.Operator);
            calculator = new InputCalculator("*");
            calculator.Calculate();
            Assert.AreEqual(OperatorState.Multiply,calculator.Operator);
            calculator = new InputCalculator("/");
            calculator.Calculate();
            Assert.AreEqual(OperatorState.Divide,calculator.Operator);
        }
        [TestMethod]
        public void CalculatorDoesBasicCalculations()
        {
            InputCalculator calculator = new InputCalculator("2 3");
            Assert.AreEqual(calculator.Calculate(), 5);

            calculator = new InputCalculator("* 2 3");
            Assert.AreEqual(calculator.Calculate(), 6);

            calculator = new InputCalculator("- 2 3");
            Assert.AreEqual(calculator.Calculate(), -5);

            calculator = new InputCalculator("/ 6 2");
            Assert.AreEqual(calculator.Calculate(), 3);
        }
    }
}
