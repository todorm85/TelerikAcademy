
namespace LabyrinthRunner.Common
{
    using System;

    public abstract class Bonus
    {
        public abstract void Effect(object sender, BonusEventArgs e);
    }

    public class BonusEventArgs : EventArgs
    {
        public BonusEventArgs(WorldObject target)
            : base()
        {
            this.Target = target;
        }

        public WorldObject Target { get; private set; }
    }
}
