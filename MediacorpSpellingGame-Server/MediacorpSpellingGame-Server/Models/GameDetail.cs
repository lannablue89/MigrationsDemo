using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediacorpSpellingGame_Server.Models
{
    public class GameDetail
    {
        public int Id { get; set; }

        public string[] Answers { get; set; }
        public int Score { get; set; }
        public int ElapsedTime { get; set; }

        // Foreign Key
        public int SchoolId { get; set; }
        public int RoundId { get; set; }
        public int GameId { get; set; }

        // Navigation property
        public School School { get; set; } 
        public Round Round { get; set; }
        public Game Game { get; set; }
    }
}