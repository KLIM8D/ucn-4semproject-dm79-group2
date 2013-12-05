using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Resources;

namespace UnitTests
{
    /// <summary>
    /// Summary description for GraphServiceTests
    /// </summary>
    [TestClass]
    public class GraphServiceTests
    {

        private GraphService _graphService;
        public GraphServiceTests()
        {
            _graphService = new GraphService();
        }

        [TestMethod]
        public void TestRoute()
        {
            var list = _graphService.GetDirections(1, 5);

            Assert.IsNotNull(list);
        }
    }
}
