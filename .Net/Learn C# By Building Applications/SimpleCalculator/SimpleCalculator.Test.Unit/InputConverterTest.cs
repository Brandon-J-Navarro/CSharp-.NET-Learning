namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class InputConverterTest
    {
        private readonly InputConverter _inputConverter = new InputConverter();

        [TestMethod]
        public void ConvertValidStringInputIntoDouble()
        {
            string inpuntNumber = "5";
            double convertedNumber = _inputConverter.ConvertInputToNumeric(inpuntNumber);
            Assert.AreEqual(5, convertedNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToConvertValidStringInputIntoDouble()
        {
            string inpuntNumber = "^";
            double convertedNumber = _inputConverter.ConvertInputToNumeric(inpuntNumber);
        }
    }
}
