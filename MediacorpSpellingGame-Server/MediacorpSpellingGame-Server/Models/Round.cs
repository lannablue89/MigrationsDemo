using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MediacorpSpellingGame_Server.Models
{
    public class Round
    {
        public const int GAME_TYPE_QUALIFY = 0;
        public const int GAME_TYPE_QUATER_FINAL = 1;
        public const int GAME_TYPE_SEMI_FINAL = 2;
        public const int GAME_TYPE_FINAL = 3;

        public int Id { get; set; }
        public int Type { get; set; }

        [DefaultValue(1)]
        public int Quantiy { get; set; }

        public override string ToString()
        {
            return "d=" + Id
                + "Type=" + Type
                ;
        }
    }
}