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
            Assert.AreEqual(calculator.currentState.GetType(), new Add().GetType());
        }
        [TestMethod]
        public void OperatorStateChangesBasedOnInput()
        {
            InputCalculator calculator = new InputCalculator("-");
            calculator.Calculate();
            Assert.AreEqual(new Subtract().GetType(), calculator.currentState.GetType());
            calculator = new InputCalculator("+");
            calculator.Calculate();
            Assert.AreEqual(new Add().GetType(), calculator.currentState.GetType());
            calculator = new InputCalculator("*");
            calculator.Calculate();
            Assert.AreEqual(new Multiply().GetType(), calculator.currentState.GetType());
            calculator = new InputCalculator("/");
            calculator.Calculate();
            Assert.AreEqual(new Divide().GetType(), calculator.currentState.GetType());
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
