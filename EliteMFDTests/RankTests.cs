
using EliteMFD.EliteDangerous;
using NUnit.Framework;

namespace EliteMFDTests
{
    [TestFixture]
    public class RankTests
    {
        [Theory]
        public void TestCombatRankNameIsNotUnknown(CombatRank rank)
        {
            Assert.That(rank.Name(), Is.Not.EqualTo("Unknown"));
        }

        [Theory]
        public void TestExplorationRankNameIsNotUnknown(ExplorationRank rank)
        {
            Assert.That(rank.Name(), Is.Not.EqualTo("Unknown"));
        }

        [Theory]
        public void TestTradeRankNameIsNotUnknown(TradeRank rank)
        {
            Assert.That(rank.Name(), Is.Not.EqualTo("Unknown"));
        }

        [Theory]
        public void TestFederationRankNameIsNotUnknown(FederationRank rank)
        {
            Assert.That(rank.Name(), Is.Not.EqualTo("Unknown"));
        }

        [Theory]
        public void TestEmpireRankNameIsNotUnknown(EmpireRank rank)
        {
            Assert.That(rank.Name(), Is.Not.EqualTo("Unknown"));
        }

        [Theory]
        public void TestCqcNameIsNotUnknown(CqcRank rank)
        {
            Assert.That(rank.Name(), Is.Not.EqualTo("Unknown"));
        }
    }
}
