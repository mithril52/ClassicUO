using System.Collections.Generic;
using ClassicUO.Game.Managers;

namespace ClassicUO.Game.Data
{
    internal static class SpellsIntonation
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

        static SpellsIntonation()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                // Spell List
                {
                    1, new SpellDefinition("Discordant Shout", 831, 0x949, TargetType.Harmful)
                },
                {
                    2, new SpellDefinition("Song of Discord", 832, 0x94A, TargetType.Harmful)
                },
                {
                    3, new SpellDefinition("Animal Form", 833, 0x5322, TargetType.Beneficial)
                },
                {
                    4, new SpellDefinition("Ki Attack", 834, 0x5323, TargetType.Harmful)
                },
                {
                    5, new SpellDefinition("Surprise Attack", 835, 0x5324, TargetType.Harmful)
                },
                {
                    6, new SpellDefinition("Backstab", 836, 0x5325, TargetType.Harmful)
                },
                {
                    7, new SpellDefinition("Shadowjump", 837, 0x5326, TargetType.Neutral)
                },
                {
                    8, new SpellDefinition("Mirror Image", 838, 0x5327, TargetType.Neutral)
                }
            };
        }

        public static string SpellBookName { get; set; } = SpellBookType.Intonation.ToString();

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