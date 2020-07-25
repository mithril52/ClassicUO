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
using System.IO;
using System.Xml;

using ClassicUO.Configuration;
using ClassicUO.Game.Data;
using ClassicUO.Game.UI.Controls;
using ClassicUO.Input;
using ClassicUO.IO.Resources;
using ClassicUO.Renderer;
using ClassicUO.Utility;
using ClassicUO.Utility.Logging;
using Microsoft.Xna.Framework;

namespace ClassicUO.Game.UI.Gumps
{
    internal class UseSpellButtonGump : AnchorableGump
    {
        private SpellDefinition _spell;
        private GumpPic _background;
        private TextBox _cooldownText;
        private DateTime _nextCooldownUpdate = DateTime.MinValue;
        private int _cooldownRemaining = 0;
        
        public UseSpellButtonGump() : base(0, 0)
        {
            CanMove = true;
            AcceptMouseInput = true;
            CanCloseWithRightClick = true;
        }

        public UseSpellButtonGump(SpellDefinition spell) : this()
        {
            _spell = spell;
            BuildGump();
        }

        public override GUMP_TYPE GumpType => GUMP_TYPE.GT_SPELLBUTTON;

        public int SpellID => _spell?.ID ?? 0;

        public ushort Hue
        {
            set => _background.Hue = value;
        }

        private void BuildGump()
        {
            Add(_background = new GumpPic(0, 0, (ushort) _spell.GumpIconSmallID, 0) {AcceptMouseInput = false});

            // triple digit X = 39
            // double digit X = 33
            // single digit X = 27
            
            Add(_cooldownText = new TextBox(3, 32, hue: 0xFFFF, isunicode: false, style: FontStyle.BlackBorder, alig: TEXT_ALIGN_TYPE.TS_CENTER) 
                {X = 27, Y = 11, IsEditable = false, Text = ""}
            );
            
            int cliloc = GetSpellTooltip(_spell.ID);

            if (cliloc != 0)
            {
                SetTooltip(ClilocLoader.Instance.GetString(cliloc), 80);
                Log.Info($"Cliloc tooltip: {cliloc}");
            }

            WantUpdateSize = true;
            AcceptMouseInput = true;
            GroupMatrixWidth = 44;
            GroupMatrixHeight = 44;
            AnchorType = ANCHOR_TYPE.SPELL;
        }

        public void SetActive()
        {
            Hue = 0x44;
        }
        
        public void SetInactive()
        {
            Hue = 0;
        }

        public void SetCooldown(int duration)
        {
            Hue = 38;
            _cooldownRemaining = duration + 1;
            _cooldownText.Text = duration.ToString();
            _nextCooldownUpdate = DateTime.UtcNow;
        }

        public void ClearCooldown()
        {
            Hue = 0;
            _cooldownRemaining = 0;
            _cooldownText.Text = "";
            _nextCooldownUpdate = DateTime.MinValue;
        }
        
        private static int GetSpellTooltip(int id)
        {
            if (id >= 1 && id < 64) // Magery
                return 3002011 + (id - 1);

            if (id >= 101 && id <= 117) // necro
                return 1060509 + (id - 101);

            if (id >= 201 && id <= 210)
                return 1060585 + (id - 201);

            if (id >= 401 && id <= 406)
                return 1060595 + (id - 401);

            if (id >= 501 && id <= 508)
                return 1060610 + (id - 501);

            if (id >= 601 && id <= 616)
                return 1071026 + (id - 601);

            if (id >= 678 && id <= 693)
                return 1031678 + (id - 678);

            if (id >= 701 && id <= 745)
            {
                if (id <= 706)
                    return 1115612 + (id - 701);

                if (id <= 745)
                    return 1155896 + (id - 707);
            }

            if (id >= 801 && id <= 820)
            {
                return 3003000 + (id - 1);
            }
            
            if (id >= 831 && id <= 840)
            {
                return 3003000 + (id - 1);
            }

            return 0;
        }

        protected override void OnMouseUp(int x, int y, MouseButtonType button)
        {
            base.OnMouseUp(x, y, button);

            Point offset = Mouse.LDroppedOffset;

            if (ProfileManager.Current.CastSpellsByOneClick && button == MouseButtonType.Left && Math.Abs(offset.X) < 5 && Math.Abs(offset.Y) < 5)
                GameActions.CastSpell(_spell.ID);
        }

        protected override bool OnMouseDoubleClick(int x, int y, MouseButtonType button)
        {
            if (!ProfileManager.Current.CastSpellsByOneClick && button == MouseButtonType.Left)
            {
                GameActions.CastSpell(_spell.ID);

                return true;
            }

            return false;
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);
            writer.Write(0); //version - 4
            writer.Write(_spell.ID); // 4
        }

        public override void Restore(BinaryReader reader)
        {
            base.Restore(reader);
            int version = reader.ReadInt32();
            int id;

            if (version > 0)
            {
                string name = reader.ReadUTF8String(version);
                id = reader.ReadInt32();
                int gumpID = reader.ReadInt32();
                int smallGumpID = reader.ReadInt32();
                int reagsCount = reader.ReadInt32();

                Reagents[] reagents = new Reagents[reagsCount];

                for (int i = 0; i < reagsCount; i++)
                    reagents[i] = (Reagents) reader.ReadInt32();

                int manaCost = reader.ReadInt32();
                int minSkill = reader.ReadInt32();
                string powerWord = reader.ReadUTF8String(reader.ReadInt32());
                int tithingCost = reader.ReadInt32();
            }
            else
                id = reader.ReadInt32();

            _spell = SpellDefinition.FullIndexGetSpell(id);
            BuildGump();
        }


        public override void Save(XmlTextWriter writer)
        {
            base.Save(writer);
            writer.WriteAttributeString("id", _spell.ID.ToString());
        }

        public override void Restore(XmlElement xml)
        {
            base.Restore(xml);
            _spell = SpellDefinition.FullIndexGetSpell(int.Parse(xml.GetAttribute("id")));
            BuildGump();
        }

        public override void Update(double totalMS, double frameMS)
        {
            if (_nextCooldownUpdate > DateTime.MinValue && _nextCooldownUpdate <= DateTime.UtcNow)
            {
                _nextCooldownUpdate = _nextCooldownUpdate.AddSeconds(1);
                
                _cooldownText.Text = _cooldownRemaining > 0 
                    ? _cooldownRemaining.ToString() 
                    : "";

                switch (_cooldownRemaining.ToString().Length)
                {
                    case 1: _cooldownText.X = 27;
                        break;
                    case 2: _cooldownText.X = 33;
                        break;
                    case 3: _cooldownText.X = 37;
                        break;
                }
 
                _cooldownRemaining--;
            }
            
            base.Update(totalMS, frameMS);
        }
    }
}