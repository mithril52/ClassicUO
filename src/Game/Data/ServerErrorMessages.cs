﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassicUO.IO;

namespace ClassicUO.Game.Data
{
    static class ServerErrorMessages
    {
        private static readonly string[] _loginErrors =
        {
            "Incorrect password",
            "This character does not exist anymore.  You will have to recreate it.",
            "This character already exists.\nPlaying...",
            "The client could not attach to the game server. It must have been taken down, please wait a few minutes and try again.",
            "The client could not attach to the game server. It must have been taken down, please wait a few minutes and try again.",
            "Another character from this account is currently online in this world.  You must either log in as that character or wait for it to time out.",
            "An error has occurred in the synchronization between the login servers and this world.  Please close your client and try again.",
            "You have been idle for too long.  If you do not do anything in the next minute, you will be logged out.",
            "Could not attach to game server.",
            "Character transfer in progress."
        };

        private static readonly string[] _errorCode =
        {
            "That character password is invalid.",
            "That character does not exist.",
            "That character is being played right now.",
            "That character is not old enough to delete. The character must be 7 days old before it can be deleted.",
            "That character is currently queued for backup and cannot be deleted.",
            "Couldn't carry out your request.",
        };

        private static readonly string[] _pickUpErrors =
        {
            "You can not pick that up.",
            "That is too far away.",
            "That is out of sight.",
            "That item does not belong to you.  You'll have to steal it.",
            "You are already holding an item."
        };

        private static readonly string[] _generalErrors =
        {
            "Incorrect name/password.",
            "Someone is already using this account.",
            "Your account has been blocked.",
            "Your account credentials are invalid.",
            "Communication problem.",
            "The IGR concurrency limit has been met.",
            "The IGR time limit has been met.",
            "General IGR authentication failure.",
            "Couldn't connect to Ultima Online.  Please try again in a few moments."
        };

        public static string GetError(byte packetID, byte code)
        {
            switch (packetID)
            {
                case 0x53: return _loginErrors[code >= 10 ? 9 : code];
                case 0x85: return _errorCode[code >= 6 ? 5 : code];
                case 0x27: return _pickUpErrors[code >= 5 ? 4 : code];
                case 0x82: return _generalErrors[code >= 9 ? 8 : code];
            }

            return string.Empty;
        }

       
    }
}
