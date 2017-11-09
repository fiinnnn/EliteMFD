using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class JournalParser
    {
        public static JournalEntry ParseLine(string line)
        {
            JObject entry = JObject.Parse(line);

            switch (entry.Value<string>("event"))
            {
                default:
                    return new JournalEntry(entry);

                case "Bounty":
                    return new BountyEntry(entry);

                case "CommitCrime":
                    return new CommitCrimeEntry(entry);

                case "Docked":
                    return new DockedEntry(entry);

                case "DockingDenied":
                    return new DockingDeniedEntry(entry);

                case "DockingGranted":
                    return new DockingGrantedEntry(entry);

                case "FSDJump":
                    return new FSDJumpEntry(entry);

                case "FuelScoop":
                    return new FuelScoopEntry(entry);

                case "HullDamage":
                    return new HullDamageEntry(entry);

                case "JetConeBoost":
                    return new JetConeBoostEntry(entry);

                case "LaunchFighter":
                    return new LaunchFighterEntry(entry);

                case "LoadGame":
                    return new LoadGameEntry(entry);

                case "Location":
                    return new LocationEntry(entry);

                case "MiningRefined":
                    return new MiningRefinedEntry(entry);

                case "Promotion":
                    return new PromotionEntry(entry);

                case "Rank":
                    return new RankEntry(entry);

                case "ReceiveText":
                    return new ReceiveTextEntry(entry);

                case "RefuelAll":
                    return new RefuelEntry(entry);

                case "RefuelPartial":
                    return new RefuelEntry(entry);

                case "SetUserShipName":
                    return new SetUserShipName(entry);

                case "ShieldState":
                    return new ShieldStateEntry(entry);

                case "ShipyardTransfer":
                    return new ShipyardTransferEntry(entry);

                case "StartJump":
                    return new StartJumpEntry(entry);

                case "USSDrop":
                    return new USSDropEntry(entry);

                case "VehicleSwitch":
                    return new VehicleSwitchEntry(entry);
            }
        }
    }
}
