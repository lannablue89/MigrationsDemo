using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediacorpSpellingGame_Server.Models;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class DbInitUT
    {
        [TestMethod]
        public void CanInitializeDatabase()
        {
            using (var context = new GameContext())
            {
                var rounds = context.Rounds.ToList();
                foreach (var round in rounds)
                {
                    Console.WriteLine(round.ToString());
                }
            }
            Assert.Inconclusive("If we're here, it did not crash");
        }
    }
}
