using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct Jump_Event
    {
        public readonly GameObject GameObject;

        public Jump_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}