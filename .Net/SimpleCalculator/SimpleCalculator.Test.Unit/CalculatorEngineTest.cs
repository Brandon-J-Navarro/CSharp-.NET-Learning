namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calulatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("add", number1, number2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("+", number1, number2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("subtract", number1, number2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("-", number1, number2);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("multiply", number1, number2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("*", number1, number2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForNonSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("divide", number1, number2);
            Assert.AreEqual(.5, result);
        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForSymbolOpertion()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calulatorEngine.Calculate("/", number1, number2);
            Assert.AreEqual(.5, result);
        }
    }
}