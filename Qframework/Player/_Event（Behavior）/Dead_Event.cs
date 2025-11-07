using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct Dead_Event
    {
        public readonly GameObject GameObject;

        public Dead_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}