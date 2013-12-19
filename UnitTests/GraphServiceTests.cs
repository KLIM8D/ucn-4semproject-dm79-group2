using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Resources;
using Utils.Serialization;
using Repository.Models;
namespace UnitTests
{
    /// <summary>
    /// Summary description for GraphServiceTests
    /// </summary>
    [TestClass]
    public class GraphServiceTests
    {

        private GraphService _graphService;
        private TransitLogic _transitLogic;
        public GraphServiceTests()
        {
            _graphService = new GraphService();
            _transitLogic = new TransitLogic();
        }

        [TestMethod]
        public void TestTravelPrice()
        {
            var price = _graphService.TravelPrice(1, 1, 88);
            var price2 = _graphService.TravelPrice(1, 1, 1);

            Assert.IsTrue(price > 0 && price2 > 0);
        }

        [TestMethod]
        public void TestRoute()
        {
            var list = _graphService.GetDirections(194, 97);

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void TestRouteReversals()
        {
            var list = _graphService.GetDirections(62, 26);
            var list2 = _graphService.GetDirections(26, 62);
            var listlist = list.Except(list2);

            Assert.IsNull(listlist);
        }

        [TestMethod]
        public void TestContinousTravel()
        {
            int price = _graphService.TravelPrice(12, 1, 88);
            //This test will only pass if the data in the database is actually reflecting a Continous Journey
            Assert.IsTrue(price == 0);
        }

        [TestMethod]
        public void TestNonContinousTravel()
        {
            var zone = _transitLogic.GetAreaIdFromStationId(63);
            var zone2 = _transitLogic.GetAreaIdFromStationId(63);
            int price = _graphService.TravelPrice(12, zone, zone2);
            //This test will only pass if the data in the database is actually not reflecting a Continous Journey
            Assert.IsTrue(price > 0);
        }

        [TestMethod]
        public void ParseJson()
        {
            List<RootObject> stations = null;
            if (1 > 2)
            {
                RKConn db = new RKConn();

                for (int zoneNo = 192; zoneNo < 195; ++zoneNo)
                {
                    //int zoneNo = 1;
                    using (StreamReader r = new StreamReader(@"Z:\workspace\holdepladser\zone" + zoneNo + ".json"))
                    {
                        string json = r.ReadToEnd();
                        stations = JsonHelper.DeserializeJson<List<RootObject>>(json, true);
                    }

                    foreach (var rootObject in stations)
                    {
                        int zoneType = Convert.ToInt32(rootObject.type.nr);
                        var zone = db.routing_zones.FirstOrDefault(x => x.rot_zon_area_id.Equals(zoneNo));
                        var ok = new transit_locations
                                 {
                                     rot_zon_id = zone.rot_zon_id,
                                     tra_loc_active = true,
                                     tra_loc_area_id = zoneNo,
                                     tra_loc_title = rootObject.navn,
                                     //transit_type = type,
                                     tra_typ_id = zoneType
                                 };

                        db.transit_locations.Add(ok);
                        db.SaveChanges();
                    }
                }
            }

            Assert.IsNotNull(stations);
        }

        public class Type
        {
            public string nr { get; set; }
            public string navn { get; set; }
            public string ikon { get; set; }
        }

        public class RootObject
        {
            public string holdepladsnr { get; set; }
            public string navn { get; set; }
            public Type type { get; set; }
        }
    }
}
