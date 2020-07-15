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
                {1, new SpellDefinition("Flame Surge", 801, 0x029B, "Un Orth Fam", 2, 0, 0, TargetType.Harmful, Reagents.AmethystPowder)},
                {2, new SpellDefinition("Brimstone", 802, 0x029C, "Fam Orth Ger", 4, 50, 5, TargetType.Harmful, Reagents.RubyPowder)},
                {3, new SpellDefinition("Lightning", 803, 0x029D, "Gal Un Orth", 6, 50, 10, TargetType.Harmful, Reagents.SapphirePowder)},
                {4, new SpellDefinition("Thunderstorm", 804, 0x029E, "Ger Na-Hath Gal", 8, 70, 15, TargetType.Harmful, Reagents.SapphirePowder)},
                {5, new SpellDefinition("Flame Strike", 805, 0x029F, "Na-Hath Fam Orth", 10, 80, 20, TargetType.Harmful, Reagents.RubyPowder)},
                {6, new SpellDefinition("Conflagration", 806, 0x02A0, "Ged Fam Ur Med", 12, 50, 30, TargetType.Harmful, Reagents.RubyPowder)},
                {7, new SpellDefinition("Magic Malaise", 807, 0x02A1, "Gal Ur Ger", 14, 70, 45, TargetType.Harmful, Reagents.CitrinePowder)},
                {8, new SpellDefinition("Wither Trap", 808, 0x02A2, "Ger Don Un Orth", 16, 70, 45, TargetType.Neutral, Reagents.AmethystPowder)},
                {9, new SpellDefinition("Fire Armor", 809, 0x02A3, "Fam Tal Orth Fam", 18, 80, 60, TargetType.Neutral, Reagents.RubyPowder, Reagents.SapphirePowder)},
                {10, new SpellDefinition("Magic Reflect", 810, 0x02A4, "Tal Gal Ceph", 20, 90, 75, TargetType.Neutral, Reagents.AmethystPowder, Reagents.SapphirePowder)}
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