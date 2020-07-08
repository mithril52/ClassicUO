using System.Collections.Generic;
using System.Linq;
using ClassicUO.Game.Managers;
using ClassicUO.Utility;

namespace ClassicUO.Game.Data
{
    internal static class SpellsEvocation
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

        private static string[] _spRegsChars;

        static SpellsEvocation()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                {1, new SpellDefinition("Flame Surge", 801, 0x08D1, "In Flam", 2, 0, 0, TargetType.Harmful, Reagents.AmberPowder)},
                {2, new SpellDefinition("Brimstone", 802, 0x08F6, "Flam Kal Des Ylem", 4, 50, 5, TargetType.Harmful, Reagents.RubyPowder)},
                {3, new SpellDefinition("Lightning", 803, 0x08E9, "Por Ort Grav", 6, 50, 10, TargetType.Harmful, Reagents.SapphirePowder)},
                {4, new SpellDefinition("Thunderstorm", 804, 0x08F0, "Vas Ort Grav", 8, 70, 15, TargetType.Harmful, Reagents.SapphirePowder)},
                {5, new SpellDefinition("Flame Strike", 805, 0x08F2, "Kal Vas Flam", 10, 80, 20, TargetType.Harmful, Reagents.RubyPowder)},
                {6, new SpellDefinition("Conflagration", 806, 0x08EA, "Flam Des Ylem", 12, 50, 30, TargetType.Harmful, Reagents.RubyPowder)},
                {7, new SpellDefinition("Magic Malaise", 807, 0x08F4, "Des Sanct", 14, 70, 60, TargetType.Harmful, Reagents.CitrinePowder)},
                {8, new SpellDefinition("Wither Trap", 808, 0x08F5, "In Jux Grav", 16, 70, 90, TargetType.Neutral, Reagents.CitrinePowder)},
                {9, new SpellDefinition("Fire Armor", 809, 0x08DB, "In Flam Sanct", 18, 80, 115, TargetType.Neutral, Reagents.RubyPowder, Reagents.SapphirePowder)},
                {10, new SpellDefinition("Magic Reflect", 810, 0x08E3, "In Jux Sanct", 20, 90, 130, TargetType.Neutral, Reagents.CitrinePowder, Reagents.SapphirePowder)}
            };
        }

        public static string SpellBookName { get; set; } = SpellBookType.Evocation.ToString();

        public static IReadOnlyDictionary<int, SpellDefinition> GetAllSpells => _spellsDict;
        internal static int MaxSpellCount => _spellsDict.Count;

        public static string[] SpecialReagentsChars
        {
            get
            {
                if (_spRegsChars == null)
                {
                    _spRegsChars = new string[_spellsDict.Max(o => o.Key)];

                    for (int i = _spRegsChars.Length; i > 0; --i)
                    {
                        if (_spellsDict.TryGetValue(i, out SpellDefinition sd))
                            _spRegsChars[i - 1] = StringHelper.RemoveUpperLowerChars(sd.PowerWords);
                        else
                            _spRegsChars[i - 1] = string.Empty;
                    }
                }

                return _spRegsChars;
            }
        }

        public static SpellDefinition GetSpell(int index)
        {
            return _spellsDict.TryGetValue(index, out SpellDefinition spell) ? spell : SpellDefinition.EmptySpell;
        }

        public static void SetSpell(int id, in SpellDefinition newspell)
        {
            _spRegsChars = null;
            _spellsDict[id] = newspell;
        }

        internal static void Clear()
        {
            _spellsDict.Clear();
        }
    }
}