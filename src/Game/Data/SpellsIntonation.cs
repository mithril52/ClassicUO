using System;
using System.Collections.Generic;
using ClassicUO.Game.Managers;
using ClassicUO.Utility.Logging;

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
                    1, new SpellDefinition("Discordant Shout", 831, 0x949, 0x949, TargetType.Harmful)
                },
                {
                    2, new SpellDefinition("Song of Discord", 832, 0x94A, 0x94A, TargetType.Harmful)
                },
                {
                    3, new SpellDefinition("Shout of Peace", 833, 0x947, 0x947, TargetType.Harmful)
                },
                {
                    4, new SpellDefinition("Song of Withdrawal", 834, 0x948, 0x948, TargetType.Harmful)
                },
                {
                    5, new SpellDefinition("Battle Cry", 835, 0x945, 0x945, TargetType.Harmful)
                },
                {
                    6, new SpellDefinition("War Chant", 836, 0x946, 0x946, TargetType.Harmful)
                },
                {
                    7, new SpellDefinition("Mesmerize", 837, 0x59E7, 0x59E7, TargetType.Harmful)
                },
                {
                    8, new SpellDefinition("Campfire Melody", 838, 0x8DB, 0x8DB, TargetType.Neutral)
                }
            };
        }

        public static SpellDefinition BardingStatus = new SpellDefinition("Barding Status", 839, 1031, 1031, TargetType.Neutral);
        
        public static string SpellBookName { get; set; } = SpellBookType.Intonation.ToString();

        public static IReadOnlyDictionary<int, SpellDefinition> GetAllSpells => _spellsDict;
        internal static int MaxSpellCount => _spellsDict.Count;

        public static SpellDefinition GetSpell(int spellIndex)
        {
            Console.WriteLine($"Spell ID: {spellIndex}");
            if (_spellsDict.TryGetValue(spellIndex, out SpellDefinition spell))
                return spell;

            if (spellIndex == 739 || spellIndex == 9)
                return BardingStatus;
            
            Console.WriteLine("Failed to find spell");
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