using ClassicUO.Game.Managers;
using ClassicUO.Utility.Logging;

namespace ClassicUO.Network
{
    public static class SanctuaryPacketHandlers
    {
        public static void HandleSpellCooldown(ushort spellId, ushort duration)
        {
            Log.Trace($"Received Spell Cooldown, Spell ID = {spellId}, Duration = {duration}");

            var spellGump = UIManager.GetUseSpellButtonGump(spellId);
            if (spellGump != null)
                spellGump.Hue = 38;
        }

        public static void HandleEndCooldown(ushort spellId)
        {
            Log.Trace($"Received End Cooldown, Spell ID = {spellId}");

            var spellGump = UIManager.GetUseSpellButtonGump(spellId);
            if (spellGump != null)
                spellGump.Hue = 0;
        }
    }
}