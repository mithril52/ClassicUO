using System.Collections.Generic;

namespace ClassicUO.Game.Data
{
    internal static class SpellsTaming
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

        static SpellsTaming()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                // Spell List
                {
                    1, new SpellDefinition("Call Home", 901, 0x5420, 2, 0, StatType.Mana, 2)
                },
                {
                    2, new SpellDefinition("Level 1", 902, 0x5421, 2, 20, StatType.Stamina, 2)
                },
                {
                    3, new SpellDefinition("Level 2", 903, 0x5422, 3, 20, StatType.Mana, 2)
                },
                {
                    4, new SpellDefinition("Level 3", 904, 0x5423, 4, 20, StatType.Stamina, 2)
                },
                {
                    5, new SpellDefinition("Level 4", 905, 0x5424, 5, 20, StatType.Mana, 2)
                },
                {
                    6, new SpellDefinition("Level 5", 905, 0x5425, 6, 20, StatType.Stamina, 2)
                }
           };
        }

        public static string SpellBookName { get; set; } = SpellBookType.Taming.ToString();

        public static IReadOnlyDictionary<int, SpellDefinition> GetAllSpells => _spellsDict;
        internal static int MaxSpellCount => _spellsDict.Count;

        public static SpellDefinition GetSpell(int spellIndex)
        {
            if (_spellsDict.TryGetValue(spellIndex, out SpellDefinition spell))
                return spell;

            return SpellDefinition.EmptySpell;
        }

        public static void SetSpell(int id, in SpellDefinition newspell)
        {
            _spellsDict[id] = newspell;
        }

        internal static void Clear()
        {
            _spellsDict.Clear();
        }
    }
}