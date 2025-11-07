using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct EnterTwo_Event
    {
        public readonly GameObject GameObject;

        public EnterTwo_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}