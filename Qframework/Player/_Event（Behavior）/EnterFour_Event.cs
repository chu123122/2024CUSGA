using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct EnterFour_Event
    {
        public readonly GameObject GameObject;

        public EnterFour_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}