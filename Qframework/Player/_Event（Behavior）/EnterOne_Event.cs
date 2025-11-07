using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct EnterOne_Event
    {
        public readonly GameObject GameObject;

        public EnterOne_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}