using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONDepth;

namespace JSONDepthTest
{
    [TestClass]
    public class JSONDepthTests
    {
        //check JSON with depth 4
        [TestMethod]
        public void DepthCase4()
        {
            string input = "{\"identity\": {\"name\": \"Test\", \"translations\": [{\"order\": 1, \"language\": \"ru\", \"value\": \"Тест\"}]}}";
            string output = "{\"levels\" : 4}";

            WebForm1 wf = new WebForm1();
            Assert.AreEqual(output, wf.Output(input));
        }

        //check JSON with depth 1
        [TestMethod]
        public void DepthCase1()
        {
            string input = "{ \"key\": \"value\"}";
            string output = "{\"levels\" : 1}";

            WebForm1 wf = new WebForm1();
            Assert.AreEqual(output, wf.Output(input));
        }

        //check invalid JSON
        [TestMethod]
        public void JSONCaseInvalid()
        {
            string input = "{\"incorrect: \"value\"}";
            string output = "{\"error\": \"Invalid JSON\"}";

            WebForm1 wf = new WebForm1();
            Assert.AreEqual(output, wf.Output(input));
        }

        [TestMethod]
        public void JSONCaseEmptyInput()
        {
            string input = "";
            string output = "{\"error\": \"Invalid JSON\"}";

            WebForm1 wf = new WebForm1();
            Assert.AreEqual(output, wf.Output(input));
        }
    }
}
