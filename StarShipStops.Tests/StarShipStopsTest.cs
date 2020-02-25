using NUnit.Framework;
using StarShipStops.Classes;

namespace StarShipStops.Tests
{
    public class StarShipStopsTests
    {

        [Test]
        public void StarShipShouldNotStopIfDistanceEqualsZero()
        {
            StarShip starShip = new StarShip("1 week", "80");

            Assert.AreEqual(0, starShip.CalculateStops(0));
        }

        [Test]
        public void StarShipShouldNotLeaveIfMGLTEqualsZero()
        {
            StarShip starShip = new StarShip("1 week", "0");

            Assert.AreEqual(-1, starShip.CalculateStops(100000));
        }

        [Test]
        public void StarShipShouldNotLeaveIfThereAreNoConsumables()
        {
            StarShip starShip = new StarShip("0 hour", "80");

            Assert.AreEqual(-1, starShip.CalculateStops(100000));
        }

        [Test]
        public void StarShipWithMinutesOfConsumableShouldNotDetermineTheStops()
        {
            StarShip starShip = new StarShip("3 minutes", "40");

            Assert.AreEqual(-1, starShip.CalculateStops(1000000));
        }

        [Test]
        public void StarShipWithUnknownMGLTShouldNotDetermineTheStops()
        {
            StarShip starShip = new StarShip("3 minutes", "unknown");

            Assert.AreEqual(-1, starShip.CalculateStops(1000000));
        }

        [Test]
        public void StarShipWith1HourOfConsumables1MGLTAnd1OfDistanceShouldNotStop()
        {
            StarShip starShip = new StarShip("1 hour", "1");

            Assert.AreEqual(0, starShip.CalculateStops(1));
        }

        [Test]
        public void StarShipWith1WeekOfConsumables80MGLTAnd1MOfDistanceShouldStop74Times()
        {
            StarShip starShip = new StarShip("1 week", "80");

            Assert.AreEqual(74, starShip.CalculateStops(1000000));
        }

        [Test]
        public void StarShipWith2MounthsOfConsumables75MGLTAnd1MOfDistanceShouldStop9Times()
        {
            StarShip starShip = new StarShip("2 months", "75");

            Assert.AreEqual(9, starShip.CalculateStops(1000000));
        }

        [Test]
        public void StarShipWith2YearsOfConsumables40MGLTAnd10MOfDistanceShouldStop14Times()
        {
            StarShip starShip = new StarShip("2 years", "40");

            Assert.AreEqual(14, starShip.CalculateStops(10000000));
        }

        [Test]
        public void StarShipWith3DaysOfConsumables40MGLTAnd1MOfDistanceShouldStop347Times()
        {
            StarShip starShip = new StarShip("3 days", "40");

            Assert.AreEqual(347, starShip.CalculateStops(1000000));
        }


    }
}