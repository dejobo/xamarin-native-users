using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppExercise.Tests
{
    [TestClass]
    public class PasswordStringTests
    {
        public PasswordStringTests()
        {
        }

        [TestMethod]
        public void test_consecutive_characters()
        {
            //var hasConsecutiveChar = new Regex(@"^(?!.*(.)\1)[a-zA-Z][a-zA-Z\d._-]*$");
            var hasConsecutiveChar = new Regex(@"([a-zA-Z0-9])\1"); 
            //new Regex(@"(.)\1");

            string text = "aabc1";
            var result = hasConsecutiveChar.IsMatch(text);
            Assert.IsTrue(result);
        }
    }
}
