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
                {1, new SpellDefinition("Firebolt", 701, 0x08D1, "In Flam", 0, 0, TargetType.Harmful)},
                {2, new SpellDefinition("Fireball", 702, 0x08F6, "In Vas Flam", 12, 10, TargetType.Harmful)},
                {3, new SpellDefinition("Firebolt", 703, 0x08D1, "In Flam", 10, 20, TargetType.Harmful)},
                {4, new SpellDefinition("Firebolt", 704, 0x08D1, "In Flam", 20, 40, TargetType.Harmful)},
                {5, new SpellDefinition("Firebolt", 705, 0x08D1, "In Flam", 20, 50, TargetType.Harmful)},
                {6, new SpellDefinition("Firebolt", 706, 0x08D1, "In Flam", 25, 60, TargetType.Harmful)},
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