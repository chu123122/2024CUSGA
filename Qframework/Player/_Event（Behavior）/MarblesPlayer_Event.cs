using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct MarblesPlayer_Event
    {
        public readonly GameObject GameObject;

        public MarblesPlayer_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}