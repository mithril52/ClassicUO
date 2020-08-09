#region license
// Copyright (C) 2020 ClassicUO Development Community on Github
// 
// This project is an alternative client for the game Ultima Online.
// The goal of this is to develop a lightweight client considering
// new technologies.
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
#endregion

using System.Collections.Generic;

using ClassicUO.Game.Managers;

namespace ClassicUO.Game.Data
{
    internal static class SpellsSpellweaving
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

        static SpellsSpellweaving()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                // Spell List
                {
                    1, new SpellDefinition("Embracing Earth", 601, 0x2A5, "Myrshalee", 2, 0, 0, TargetType.Beneficial, Reagents.Woundwort)
                },
                {
                    2, new SpellDefinition("Restore Spirit", 602, 0x2A6, "Olorisstra", 4, 50, 5, TargetType.Beneficial, Reagents.BeesLace)
                },
                {
                    3, new SpellDefinition("Wild Remedy", 603, 0x2A7, "Thalshara", 6, 50, 10, TargetType.Beneficial, Reagents.BlackthornBerries)
                },
                {
                    4, new SpellDefinition("Soothing Vale", 604, 0x2A8, "Haeldril", 8, 70, 15, TargetType.Beneficial, Reagents.Mugwort)
                },
                {
                    5, new SpellDefinition("Life Bloom", 605, 0x2A9, "Erelonia", 10, 80, 20, TargetType.Beneficial, Reagents.Mandragona, Reagents.Woundwort)
                },
                {
                    6, new SpellDefinition("Glade's Grace", 606, 0x2AA, "Rauvvrae", 12, 50, 30, TargetType.Beneficial, Reagents.Bloodmoss)
                },
                {
                    7, new SpellDefinition("Holy Shield", 607, 0x2AB, "Alalithra", 14, 70, 45, TargetType.Beneficial, Reagents.Mugwort, Reagents.Bloodmoss)
                },
                {
                    8, new SpellDefinition("Leyline Resonance", 608, 0x2AC, "Nylisstra", 16, 70, 45, TargetType.Beneficial, Reagents.Belladonna, Reagents.Mandragona)
                },
                {
                    9, new SpellDefinition("Sacred Grove", 609, 0x2AD, "Tarisstree", 18, 80, 60, TargetType.Neutral, Reagents.BeesLace, Reagents.Belladonna)
                },
                {
                    10, new SpellDefinition("Final Retreat", 610, 0x2AE, "Haelyn", 20, 90, 75, TargetType.Beneficial, Reagents.BatNut, Reagents.BlackthornBerries)
                }
            };
        }

        public static string SpellBookName { get; set; } = SpellBookType.Spellweaving.ToString();

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