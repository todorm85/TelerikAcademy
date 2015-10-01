
namespace LabyrinthRunner.Common
{
    using System;
    using System.Linq;

    public static class Collision
    {
        
        public static bool ManageCollision(WorldObject movingObj, Position position)
        {
            if (!GameEngine.CurrentLabyrinth.LabyrinthArr[position.Row, position.Col].IsPenetrable)
            {
                return false;
            }

            //Check if there is collision with some other object on the field
            WorldObject collObj = null;

            foreach(var obj in GameEngine.GameObjects)
            {
                collObj = obj as WorldObject;

                if(collObj != null)
                {
                    if(collObj.Position.Row == position.Row && collObj.Position.Col == position.Col)
                    {
                        break;
                    }
                }

                collObj = null;
            }
            
            if(collObj != null)
            {
                //Collision object has been found

                if(movingObj.Type == WorldObjectType.CpuPlayer && collObj.Type == WorldObjectType.CpuPlayer)
                {
                    //Enemey and enemy

                    return false;
                }
                else if(movingObj.Type == WorldObjectType.HumanPlayer && collObj.Type == WorldObjectType.CpuPlayer ||
                    movingObj.Type == WorldObjectType.CpuPlayer && collObj.Type == WorldObjectType.HumanPlayer)
                {
                    //Player and enemy
                    GameEngine.PlayerHitByEnemy();

                    return true;
                }
                else if(movingObj.Type == WorldObjectType.CpuPlayer && collObj.Type == WorldObjectType.BonusBox)
                {
                    //Enemy and bonus box

                    return false;
                }
                else if(movingObj.Type == WorldObjectType.HumanPlayer && collObj.Type == WorldObjectType.BonusBox)
                {
                    //Bonus box and player

                    BonusBox bonusBox = collObj as BonusBox;

                    if(bonusBox != null)
                    {
                        bonusBox.OnGather(movingObj);

                        GameEngine.ObjectsToRemove.Add(bonusBox);
                    }

                    return true;
                }
            }

            return true;
        }
    }
}
