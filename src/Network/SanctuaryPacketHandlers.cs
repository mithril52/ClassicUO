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
            spellGump?.SetCooldown(duration);
        }

        public static void HandleEndCooldown(ushort spellId)
        {
            Log.Trace($"Received End Cooldown, Spell ID = {spellId}");

            var spellGump = UIManager.GetUseSpellButtonGump(spellId);
            spellGump?.ClearCooldown();
        }

        public static void HandleActivateAutoAttackSpell(ushort spellId)
        {
            Log.Trace($"Received Activate Auto Attack, Spell ID = {spellId}");

            var spellGump = UIManager.GetUseSpellButtonGump(spellId);
            spellGump?.SetActive();
        }

        public static void HandleDeactivateAutoAttackSpell(ushort spellId)
        {
            Log.Trace($"Received Deactivate Auto Attack, Spell ID = {spellId}");

            var spellGump = UIManager.GetUseSpellButtonGump(spellId);
            spellGump?.SetInactive();
        }

        public static void HandleSetBardingPoolValue(byte value)
        {
            Log.Trace($"Received Set Barding Pool Value, Value = {value}");

            var spellGump = UIManager.GetUseSpellButtonGump(839);
            spellGump?.SetBardPoolIndication(value);
        }
    }
}