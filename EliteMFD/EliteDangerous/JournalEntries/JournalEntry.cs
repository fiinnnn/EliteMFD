using System;

namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IJournalEntry
    {
        DateTime Timestamp { get; set; }
        string Event { get; set; }
    }

    partial class JournalEntry
    {
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }

        protected bool Equals(JournalEntry other)
        {
            return Timestamp.Equals(other.Timestamp) && string.Equals(Event, other.Event) && Combat == other.Combat && Trade == other.Trade && Explore == other.Explore && Empire == other.Empire && Federation == other.Federation && CQC == other.CQC && Equals(StarPos, other.StarPos) && string.Equals(Body, other.Body) && string.Equals(BodyType, other.BodyType) && string.Equals(SystemFaction, other.SystemFaction) && string.Equals(SystemAllegiance, other.SystemAllegiance) && string.Equals(SystemEconomy, other.SystemEconomy) && string.Equals(SystemGovernment, other.SystemGovernment) && string.Equals(SystemSecurity, other.SystemSecurity) && JumpDist.Equals(other.JumpDist) && FuelUsed.Equals(other.FuelUsed) && FuelLevel.Equals(other.FuelLevel) && BoostUsed == other.BoostUsed && string.Equals(USSType, other.USSType) && USSThreat == other.USSThreat && string.Equals(To, other.To) && string.Equals(StationName, other.StationName) && string.Equals(StationType, other.StationType) && string.Equals(StarSystem, other.StarSystem) && string.Equals(StationFaction, other.StationFaction) && string.Equals(StationAllegiance, other.StationAllegiance) && string.Equals(StationEconomy, other.StationEconomy) && string.Equals(StationGovernment, other.StationGovernment) && DistFromStarLS.Equals(other.DistFromStarLS) && string.Equals(JumpType, other.JumpType) && string.Equals(ShipType, other.ShipType) && string.Equals(System, other.System) && Distance.Equals(other.Distance) && TransferPrice == other.TransferPrice && TransferTime == other.TransferTime && ShieldsUp == other.ShieldsUp && string.Equals(UserShipName, other.UserShipName) && string.Equals(UserShipId, other.UserShipId) && Cost == other.Cost && Amount.Equals(other.Amount) && string.Equals(From, other.From) && string.Equals(Message, other.Message) && string.Equals(Channel, other.Channel) && string.Equals(Type, other.Type) && string.Equals(Commander, other.Commander) && string.Equals(Ship, other.Ship) && string.Equals(ShipName, other.ShipName) && string.Equals(ShipIdent, other.ShipIdent) && FuelCapacity.Equals(other.FuelCapacity) && string.Equals(GameMode, other.GameMode) && string.Equals(Group, other.Group) && Credits == other.Credits && Loan == other.Loan && Docked == other.Docked && PlayerControlled == other.PlayerControlled && BoostValue.Equals(other.BoostValue) && Health.Equals(other.Health) && PlayerPilot == other.PlayerPilot && Fighter == other.Fighter && Scooped.Equals(other.Scooped) && Total.Equals(other.Total) && CockpitBreach == other.CockpitBreach && LandingPad == other.LandingPad && string.Equals(CrimeType, other.CrimeType) && Fine == other.Fine && Bounty == other.Bounty && TotalReward == other.TotalReward && string.Equals(Reason, other.Reason);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((JournalEntry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Timestamp.GetHashCode();
                hashCode = (hashCode * 397) ^ (Event != null ? Event.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Combat.GetHashCode();
                hashCode = (hashCode * 397) ^ Trade.GetHashCode();
                hashCode = (hashCode * 397) ^ Explore.GetHashCode();
                hashCode = (hashCode * 397) ^ Empire.GetHashCode();
                hashCode = (hashCode * 397) ^ Federation.GetHashCode();
                hashCode = (hashCode * 397) ^ CQC.GetHashCode();
                hashCode = (hashCode * 397) ^ (StarPos != null ? StarPos.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Body != null ? Body.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BodyType != null ? BodyType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SystemFaction != null ? SystemFaction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SystemAllegiance != null ? SystemAllegiance.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SystemEconomy != null ? SystemEconomy.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SystemGovernment != null ? SystemGovernment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SystemSecurity != null ? SystemSecurity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ JumpDist.GetHashCode();
                hashCode = (hashCode * 397) ^ FuelUsed.GetHashCode();
                hashCode = (hashCode * 397) ^ FuelLevel.GetHashCode();
                hashCode = (hashCode * 397) ^ BoostUsed.GetHashCode();
                hashCode = (hashCode * 397) ^ (USSType != null ? USSType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ USSThreat;
                hashCode = (hashCode * 397) ^ (To != null ? To.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StationName != null ? StationName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StationType != null ? StationType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StarSystem != null ? StarSystem.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StationFaction != null ? StationFaction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StationAllegiance != null ? StationAllegiance.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StationEconomy != null ? StationEconomy.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StationGovernment != null ? StationGovernment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DistFromStarLS.GetHashCode();
                hashCode = (hashCode * 397) ^ (JumpType != null ? JumpType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShipType != null ? ShipType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (System != null ? System.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Distance.GetHashCode();
                hashCode = (hashCode * 397) ^ TransferPrice.GetHashCode();
                hashCode = (hashCode * 397) ^ TransferTime.GetHashCode();
                hashCode = (hashCode * 397) ^ ShieldsUp.GetHashCode();
                hashCode = (hashCode * 397) ^ (UserShipName != null ? UserShipName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UserShipId != null ? UserShipId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Cost.GetHashCode();
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ (From != null ? From.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Message != null ? Message.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Channel != null ? Channel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Commander != null ? Commander.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Ship != null ? Ship.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShipName != null ? ShipName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShipIdent != null ? ShipIdent.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ FuelCapacity.GetHashCode();
                hashCode = (hashCode * 397) ^ (GameMode != null ? GameMode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Group != null ? Group.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Credits.GetHashCode();
                hashCode = (hashCode * 397) ^ Loan.GetHashCode();
                hashCode = (hashCode * 397) ^ Docked.GetHashCode();
                hashCode = (hashCode * 397) ^ PlayerControlled.GetHashCode();
                hashCode = (hashCode * 397) ^ BoostValue.GetHashCode();
                hashCode = (hashCode * 397) ^ Health.GetHashCode();
                hashCode = (hashCode * 397) ^ PlayerPilot.GetHashCode();
                hashCode = (hashCode * 397) ^ Fighter.GetHashCode();
                hashCode = (hashCode * 397) ^ Scooped.GetHashCode();
                hashCode = (hashCode * 397) ^ Total.GetHashCode();
                hashCode = (hashCode * 397) ^ CockpitBreach.GetHashCode();
                hashCode = (hashCode * 397) ^ LandingPad;
                hashCode = (hashCode * 397) ^ (CrimeType != null ? CrimeType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Fine.GetHashCode();
                hashCode = (hashCode * 397) ^ Bounty.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalReward.GetHashCode();
                hashCode = (hashCode * 397) ^ (Reason != null ? Reason.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Timestamp)}: {Timestamp}, {nameof(Event)}: {Event}, {nameof(TotalReward)}: {TotalReward}, {nameof(Combat)}: {Combat}, {nameof(Trade)}: {Trade}, {nameof(Explore)}: {Explore}, {nameof(Empire)}: {Empire}, {nameof(Federation)}: {Federation}, {nameof(CQC)}: {CQC}, {nameof(StarPos)}: {StarPos}, {nameof(Body)}: {Body}, {nameof(BodyType)}: {BodyType}, {nameof(SystemFaction)}: {SystemFaction}, {nameof(SystemAllegiance)}: {SystemAllegiance}, {nameof(SystemEconomy)}: {SystemEconomy}, {nameof(SystemGovernment)}: {SystemGovernment}, {nameof(SystemSecurity)}: {SystemSecurity}, {nameof(JumpDist)}: {JumpDist}, {nameof(FuelUsed)}: {FuelUsed}, {nameof(FuelLevel)}: {FuelLevel}, {nameof(BoostUsed)}: {BoostUsed}, {nameof(USSType)}: {USSType}, {nameof(USSThreat)}: {USSThreat}, {nameof(To)}: {To}, {nameof(StationName)}: {StationName}, {nameof(StationType)}: {StationType}, {nameof(StarSystem)}: {StarSystem}, {nameof(StationFaction)}: {StationFaction}, {nameof(StationAllegiance)}: {StationAllegiance}, {nameof(StationEconomy)}: {StationEconomy}, {nameof(StationGovernment)}: {StationGovernment}, {nameof(DistFromStarLS)}: {DistFromStarLS}, {nameof(JumpType)}: {JumpType}, {nameof(ShipType)}: {ShipType}, {nameof(System)}: {System}, {nameof(Distance)}: {Distance}, {nameof(TransferPrice)}: {TransferPrice}, {nameof(TransferTime)}: {TransferTime}, {nameof(ShieldsUp)}: {ShieldsUp}, {nameof(UserShipName)}: {UserShipName}, {nameof(UserShipId)}: {UserShipId}, {nameof(Cost)}: {Cost}, {nameof(Amount)}: {Amount}, {nameof(From)}: {From}, {nameof(Message)}: {Message}, {nameof(Channel)}: {Channel}, {nameof(Type)}: {Type}, {nameof(Commander)}: {Commander}, {nameof(Ship)}: {Ship}, {nameof(ShipName)}: {ShipName}, {nameof(ShipIdent)}: {ShipIdent}, {nameof(FuelCapacity)}: {FuelCapacity}, {nameof(GameMode)}: {GameMode}, {nameof(Group)}: {Group}, {nameof(Credits)}: {Credits}, {nameof(Loan)}: {Loan}, {nameof(Docked)}: {Docked}, {nameof(PlayerControlled)}: {PlayerControlled}, {nameof(BoostValue)}: {BoostValue}, {nameof(Health)}: {Health}, {nameof(PlayerPilot)}: {PlayerPilot}, {nameof(Fighter)}: {Fighter}, {nameof(Scooped)}: {Scooped}, {nameof(Total)}: {Total}, {nameof(CockpitBreach)}: {CockpitBreach}, {nameof(LandingPad)}: {LandingPad}, {nameof(CrimeType)}: {CrimeType}, {nameof(Fine)}: {Fine}, {nameof(Bounty)}: {Bounty}, {nameof(Reason)}: {Reason}";
        }
    }
}
