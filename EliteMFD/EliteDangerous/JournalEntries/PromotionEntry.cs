using System;

namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IPromotionEntry : IRankEntry
    {
    }

    partial class JournalEntry : IPromotionEntry
    {
    }
}
