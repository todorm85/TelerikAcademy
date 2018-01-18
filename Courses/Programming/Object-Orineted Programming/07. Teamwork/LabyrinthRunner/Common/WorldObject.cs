using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabyrinthRunner.Common
{
    public abstract class WorldObject
    {
        private char skin;
        private Position position;
        private WorldObjectType type;

        public WorldObject(WorldObjectType type, Position position, char skin)
        {
            this.Skin = skin;
            this.Position = position;
            this.Type = type;
        }

        public WorldObjectType Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }

        public Position Position 
        { 
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public char Skin
        {
            get 
            { 
                return this.skin;
            }

            private set 
            { 
                this.skin = value;
            }
        }
    }

    public enum WorldObjectType
    {
        None,
        Structure,
        BonusBox,
        CpuPlayer,
        HumanPlayer
    }
}
