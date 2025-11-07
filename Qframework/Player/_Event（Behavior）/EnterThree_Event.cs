using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct EnterThree_Event
    {
        public readonly GameObject GameObject;

        public EnterThree_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}