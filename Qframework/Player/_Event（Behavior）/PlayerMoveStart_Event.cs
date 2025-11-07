using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct PlayerMoveStart_Event
    {
        public readonly GameObject GameObject;

        public PlayerMoveStart_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}