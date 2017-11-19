using System;
using EliteMFD.EliteDangerous;
using EliteMFD.EliteDangerous.JournalEntries;
using NUnit.Framework;
using Vector3D;

namespace EliteMFDTests
{
    [TestFixture]
    public class JournalParserTests
    {
        [Test]
        public void TestBounty()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"Bounty\", \"Target\":\"cobramkiii\", \"TotalReward\":3000, \"VictimFaction\":\"Imperial Nagas\", \"SharedWithOthers\":1 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "Bounty",
                    TotalReward = 3000
                });
        }

        [Test]
        public void TestCommitCrime()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"CommitCrime\", \"CrimeType\":\"collidedAtSpeedInNoFireZone\", \"Faction\":\"Pleiades Resource Enterprise\", \"Fine\":200 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "CommitCrime",
                    CrimeType = "collidedAtSpeedInNoFireZone",
                    Fine = 200,
                    Bounty = null
                });
        }

        [Test]
        public void TestPromotion()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"Promotion\", \"Combat\":4 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "Promotion",
                    Combat = 4
                });
        }

        [Test]
        public void TestFsdJump()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"FSDJump\", \"StarSystem\":\"Col 285 Sector AD-K a38-5\", \"StarPos\":[-1.188,-38.281,56.313], \"SystemAllegiance\":\"\", \"SystemEconomy\":\"$economy_None;\", \"SystemEconomy_Localised\":\"None\", \"SystemGovernment\":\"$government_None;\", \"SystemGovernment_Localised\":\"None\", \"SystemSecurity\":\"$GAlAXY_MAP_INFO_state_anarchy;\", \"SystemSecurity_Localised\":\"Anarchy\", \"Population\":0, \"JumpDist\":48.845, \"FuelUsed\":7.780167, \"FuelLevel\":56.219833 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "FSDJump",
                    StarSystem = "Col 285 Sector AD-K a38-5",
                    StarPos = new Vector(-1.188, -38.281, 56.313),
                    SystemAllegiance = "",
                    SystemEconomy = "$economy_None;",
                    SystemGovernment = "$government_None;",
                    SystemSecurity = "$GAlAXY_MAP_INFO_state_anarchy;",
                    JumpDist = 48.845,
                    FuelUsed = 7.780167,
                    FuelLevel = 56.219833
                });
        }

        private static void TestJournalEntry(string json, JournalEntry expectedJournalEntry)
        {
            var actualJournalEntry = JournalParser.ParseLine(json);
            Assert.That(actualJournalEntry, Is.EqualTo(expectedJournalEntry));
        }
    }
}
