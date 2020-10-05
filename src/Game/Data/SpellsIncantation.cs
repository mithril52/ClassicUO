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

using System;
using System.Collections.Generic;

using ClassicUO.Game.Managers;

namespace ClassicUO.Game.Data
{
    internal static class SpellsIncantation
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

      
        static SpellsIncantation()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                {
                    1, new SpellDefinition("Night Sight", 301, 0x8C5, "In Lor", 4, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    2, new SpellDefinition("Magic Trap", 302, 0x8CC, "In Jux", 6, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    3, new SpellDefinition("Magic Lock", 303, 0x8D2, "An Por", 8, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    4, new SpellDefinition("Telekinesis", 304, 0x8D4, "Ort Por Ylem", 10, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    5, new SpellDefinition("Recall", 305, 0x8DF, "Kal Ort Por", 10, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    6, new SpellDefinition("Mark", 306, 0x8EC, "Kal Por Ylem", 10, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    7, new SpellDefinition("Remove Trap", 307, 0x8CD, "An Jux", 14, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    8, new SpellDefinition("Reveal", 308, 0x8EF, "Wis Quas", 14, 0, TargetType.Beneficial, Reagents.None)
                },
                {
                    9, new SpellDefinition("Unlock", 309, 0x8D6, "Ex Por", 16, 0, TargetType.Beneficial, Reagents.None)
                },       
                {
                    10, new SpellDefinition("Teleport", 310, 0x8D5, "Rel Por", 18, 0, TargetType.Beneficial, Reagents.None)
                },     
                {
                    11, new SpellDefinition("Incognito", 311, 0x8E2, "Kal In Ex", 22, 0, TargetType.Beneficial, Reagents.None)
                },     
                {
                    12, new SpellDefinition("Gate Travel", 312, 0x8F3, "Vas Rel Por", 26, 0, TargetType.Beneficial, Reagents.None)
                },     
                {
                    13, new SpellDefinition("Dispel", 313, 0x8E8, "An Ort", 28, 0, TargetType.Harmful, Reagents.None)
                }
            };
        }

        public static readonly string SpellBookName = SpellBookType.Incantation.ToString();
        public static IReadOnlyDictionary<int, SpellDefinition> GetAllSpells => _spellsDict;
        internal static int MaxSpellCount => _spellsDict.Count;
        
        public static SpellDefinition GetSpell(int spellIndex)
        {
            Console.WriteLine($"Spell ID: {spellIndex}");

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