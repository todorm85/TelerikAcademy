
namespace LabyrinthRunner.Common
{
    using System;
    using System.Collections.Generic;

    public class BonusBox : WorldObject, IRenderable, IGatherable
    {
        private const char defaultSkin = '?';

        private Random rand = new Random();

        private delegate void BonusEffectHandler(object sender, BonusEventArgs e);
        private event BonusEffectHandler BonusEffects;

        public BonusBox(Position position, List<Bonus> bonusList)
            : base(WorldObjectType.BonusBox, position, defaultSkin)
        {
            //Choice how many bonuses and then select them
            int bonusesCount = 1 + rand.Next(bonusList.Count);

            for(int i = 0; i < bonusesCount; i++)
            {
                this.BonusEffects += bonusList[rand.Next(bonusList.Count)].Effect;
            }
        }

        public void OnGather(WorldObject destinationObject)
        {
            HumanPlayer humanPlayer = destinationObject as HumanPlayer;

            if (humanPlayer != null && this.BonusEffects != null)
            {
                this.BonusEffects(this, new BonusEventArgs(humanPlayer));
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(this.Position.Col, this.Position.Row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(this.Skin);
        }
    }
}
