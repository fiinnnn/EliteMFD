using System;
using System.Windows.Media.Media3D;
using EliteMFD.EliteDangerous;
using EliteMFD.EliteDangerous.JournalEntries;
using NUnit.Framework;

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
                    StarPos = new Point3D(-1.188, -38.281, 56.313),
                    SystemAllegiance = "",
                    SystemEconomy = "$economy_None;",
                    SystemGovernment = "$government_None;",
                    SystemSecurity = "$GAlAXY_MAP_INFO_state_anarchy;",
                    JumpDist = 48.845,
                    FuelUsed = 7.780167,
                    FuelLevel = 56.219833
                });
        }

        [Test]
        public void TestFuelScoop()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"FuelScoop\", \"Scooped\":0.942954, \"Total\":6.959383 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "FuelScoop",
                    Scooped = 0.942954,
                    Total = 6.959383
                });
        }

        [Test]
        public void TestHullDamage()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"HullDamage\", \"Health\":0.768989, \"PlayerPilot\":true, \"Fighter\":true }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "HullDamage",
                    Health = 0.768989,
                    PlayerPilot = true,
                    Fighter = true
                });

            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"HullDamage\", \"Health\":0.768989, \"PlayerPilot\":true }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "HullDamage",
                    Health = 0.768989,
                    PlayerPilot = true,
                    Fighter = false
                });
        }

        [Test]
        public void TestJetConeBoost()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"JetConeBoost\", \"BoostValue\":4.000000 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "JetConeBoost",
                    BoostValue = 4.0
                });
        }

        [Test]
        public void TestLaunchFighter()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"LaunchFighter\", \"Loadout\":\"four\", \"PlayerControlled\":false }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "LaunchFighter",
                    PlayerControlled = false
                });
        }

        [Test]
        public void TestLoadGame()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"LoadGame\", \"Commander\":\"Example\", \"Ship\":\"FerDeLance\", \"ShipID\":34, \"ShipName\":\"Shipname\", \"ShipIdent\":\"BL-28F\", \"FuelLevel\":8.000000, \"FuelCapacity\":8.000000, \"GameMode\":\"Open\", \"Credits\":276497802, \"Loan\":0 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "LoadGame",
                    Commander = "Example",
                    Ship = "FerDeLance",
                    ShipName = "Shipname",
                    ShipIdent = "BL-28F",
                    FuelLevel = 8.000000,
                    FuelCapacity = 8.000000,
                    GameMode = "Open",
                    Credits = 276497802,
                    Loan = 0
                });
        }

        [Test]
        public void TestLocation()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"Location\", \"Docked\":true, \"StationName\":\"Roentgen Hub\", \"StationType\":\"Coriolis\", \"StarSystem\":\"LFT 37\", \"StarPos\":[14.438,-61.875,16.500], \"SystemAllegiance\":\"Independent\", \"SystemEconomy\":\"$economy_Agri;\", \"SystemEconomy_Localised\":\"Agriculture\", \"SystemGovernment\":\"$government_Democracy;\", \"SystemGovernment_Localised\":\"Democracy\", \"SystemSecurity\":\"$SYSTEM_SECURITY_low;\", \"SystemSecurity_Localised\":\"Low Security\", \"Population\":554133105, \"Body\":\"Roentgen Hub\", \"BodyType\":\"Station\", \"Factions\":[ { \"Name\":\"Independents of LFT 37\", \"FactionState\":\"None\", \"Government\":\"Democracy\", \"Influence\":0.165834, \"Allegiance\":\"Federation\", \"PendingStates\":[ { \"State\":\"Boom\", \"Trend\":1 } ] }, { \"Name\":\"Pilots Federation Local Branch\", \"FactionState\":\"None\", \"Government\":\"Democracy\", \"Influence\":0.000000, \"Allegiance\":\"PilotsFederation\" }, { \"Name\":\"LFT 37 Purple Comms Corp.\", \"FactionState\":\"Boom\", \"Government\":\"Corporate\", \"Influence\":0.044955, \"Allegiance\":\"Independent\" }, { \"Name\":\"LTT 464 Gold Vision Limited\", \"FactionState\":\"Retreat\", \"Government\":\"Corporate\", \"Influence\":0.066933, \"Allegiance\":\"Federation\" }, { \"Name\":\"Nationalists of LFT 37\", \"FactionState\":\"Boom\", \"Government\":\"Dictatorship\", \"Influence\":0.050949, \"Allegiance\":\"Independent\" }, { \"Name\":\"LFT 37 Blue Natural Corp.\", \"FactionState\":\"Boom\", \"Government\":\"Corporate\", \"Influence\":0.053946, \"Allegiance\":\"Federation\" }, { \"Name\":\"LFT 37 Bureau\", \"FactionState\":\"Boom\", \"Government\":\"Dictatorship\", \"Influence\":0.045954, \"Allegiance\":\"Independent\" }, { \"Name\":\"Paladin Consortium\", \"FactionState\":\"Expansion\", \"Government\":\"Democracy\", \"Influence\":0.571429, \"Allegiance\":\"Independent\", \"RecoveringStates\":[ { \"State\":\"Boom\", \"Trend\":1 }, { \"State\":\"CivilUnrest\", \"Trend\":0 } ] } ], \"SystemFaction\":\"Paladin Consortium\", \"FactionState\":\"Expansion\" }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "Location",
                    Docked = true,
                    StationName = "Roentgen Hub",
                    StationType = "Coriolis",
                    StarSystem = "LFT 37",
                    StarPos = new Point3D(14.438, -61.875, 16.5),
                    SystemAllegiance = "Independent",
                    SystemEconomy = "$economy_Agri;",
                    SystemGovernment = "$government_Democracy;",
                    SystemSecurity = "$SYSTEM_SECURITY_low;",
                    Body = "Roentgen Hub",
                    BodyType = "Station",
                    SystemFaction = "Paladin Consortium"
                });
        }

        [Test]
        public void TestMiningRefined()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"MiningRefined\", \"Type\":\"$painite_name;\", \"Type_Localised\":\"Painite\" }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "MiningRefined",
                    Type = "$painite_name;"
                });
        }

        [Test]
        public void TestRank()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"Rank\", \"Combat\":5, \"Trade\":7, \"Explore\":7, \"Empire\":12, \"Federation\":4, \"CQC\":0 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "Rank",
                    Combat = 5,
                    Trade = 7,
                    Explore = 7,
                    Empire = 12,
                    Federation = 4,
                    CQC = 0
                });
        }

        [Test]
        public void TestReceiveText()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"ReceiveText\", \"From\":\"$ShipName_PassengerLiner_Wedding;\", \"From_Localised\":\"Wedding Barge\", \"Message\":\"$ConvoyWedding_Patrol06;\", \"Message_Localised\":\"I still haven\'t written my vows. What can I say?\", \"Channel\":\"npc\" }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "ReceiveText",
                    From = "$ShipName_PassengerLiner_Wedding;",
                    Message = "$ConvoyWedding_Patrol06;",
                    Channel = "npc"
                });
        }

        [Test]
        public void TestRefuelAll()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"RefuelAll\", \"Cost\":646, \"Amount\":12.893879 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "RefuelAll",
                    Cost = 646,
                    Amount = 12.893879
                });
        }

        [Test]
        public void TestRefuelPartial()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"RefuelPartial\", \"Cost\":326, \"Amount\":6.507000 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "RefuelPartial",
                    Cost = 326,
                    Amount = 6.507000
                });
        }

        [Test]
        public void TestSetUserShipName()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"SetUserShipName\", \"Ship\":\"ferdelance\", \"ShipID\":34, \"UserShipName\":\"Shipname\", \"UserShipId\":\"BL-28F\" }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "SetUserShipName",
                    Ship = "ferdelance",
                    UserShipName = "Shipname",
                    UserShipId = "BL-28F"
                });
        }

        [Test]
        public void TestShieldState()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"ShieldState\", \"ShieldsUp\":false }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "ShieldState",
                    ShieldsUp = false
                });
        }

        [Test]
        public void TestShipyardTransfer()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"ShipyardTransfer\", \"ShipType\":\"Hauler\", \"ShipID\":6, \"System\":\"LP 532-81\", \"Distance\":61.878189, \"TransferPrice\":2539,  \"TransferTime\":387 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "ShipyardTransfer",
                    ShipType = "Hauler",
                    System = "LP 532-81",
                    Distance = 61.878189,
                    TransferPrice = 2539,
                    TransferTime = 387
                });
        }

        [Test]
        public void TestUSSDrop()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"USSDrop\", \"USSType\":\"$USS_Type_Aftermath;\", \"USSType_Localised\":\"Combat aftermath detected\", \"USSThreat\":0 }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "USSDrop",
                    USSType = "$USS_Type_Aftermath;",
                    USSThreat = 0
                });
        }

        [Test]
        public void TestVehicleSwitch()
        {
            TestJournalEntry(
                "{ \"timestamp\":\"2017-01-14T00:29:37Z\", \"event\":\"VehicleSwitch\", \"To\":\"Mothership\" }",
                new JournalEntry
                {
                    Timestamp = new DateTime(2017, 1, 14, 0, 29, 37),
                    Event = "VehicleSwitch",
                    To = "Mothership"
                });
        }

        private static void TestJournalEntry(string json, JournalEntry expectedJournalEntry)
        {
            var actualJournalEntry = JournalParser.ParseLine(json);
            Assert.That(actualJournalEntry, Is.EqualTo(expectedJournalEntry));
        }
    }
}
