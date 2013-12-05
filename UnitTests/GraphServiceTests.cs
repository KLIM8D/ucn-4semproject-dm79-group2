using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Resources;
using Utils.Serialization;

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

        [TestMethod]
        public void ParseJson()
        {
            JsonHelper.DeserializeJson<Stations>("http://geo.oiorest.dk/takstzoner.json?operat%C3%B8rnr=280");
        }

        public class Operator
        {
            public string nr { get; set; }
            public string navn { get; set; }
        }

        public class Stations
        {
            public string nr { get; set; }
            public Operator op { get; set; }
        }
    }
}
