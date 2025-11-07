using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct PlayerMoveEnd_Event
    {
        public readonly GameObject GameObject;

        public PlayerMoveEnd_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }      
    }
}