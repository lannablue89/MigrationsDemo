namespace MediacorpSpellingGame_Server.Migrations
{
    using MediacorpSpellingGame_Server.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. 

            // Rounds
            context.Rounds.AddOrUpdate(
                g => g.Type,
                new Round { Type = Round.GAME_TYPE_QUALIFY, Quantiy = 3 },
                new Round { Type = Round.GAME_TYPE_QUATER_FINAL, Quantiy = 2 },
                new Round { Type = Round.GAME_TYPE_SEMI_FINAL },
                new Round { Type = Round.GAME_TYPE_FINAL }
                );
        }
    }
}
