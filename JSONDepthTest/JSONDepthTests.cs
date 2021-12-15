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

            JSONDepthCalculatingWebForm wf = new JSONDepthCalculatingWebForm();
            Assert.AreEqual(output, wf.ProcessJSON(input));
        }

        //check JSON with depth 1
        [TestMethod]
        public void DepthCase1()
        {
            string input = "{ \"key\": \"value\"}";
            string output = "{\"levels\" : 1}";

            JSONDepthCalculatingWebForm wf = new JSONDepthCalculatingWebForm();
            Assert.AreEqual(output, wf.ProcessJSON(input));
        }

        //check invalid JSON
        [TestMethod]
        public void JSONCaseInvalid()
        {
            string input = "{\"incorrect: \"value\"}";
            string output = "{\"error\": \"Invalid JSON\"}";

            JSONDepthCalculatingWebForm wf = new JSONDepthCalculatingWebForm();
            Assert.AreEqual(output, wf.ProcessJSON(input));
        }

        [TestMethod]
        public void JSONCaseEmptyInput()
        {
            string input = "";
            string output = "{\"error\": \"Invalid JSON\"}";

            JSONDepthCalculatingWebForm wf = new JSONDepthCalculatingWebForm();
            Assert.AreEqual(output, wf.ProcessJSON(input));
        }
    }
}
