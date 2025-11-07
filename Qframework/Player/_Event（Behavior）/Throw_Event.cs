using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct Throw_Event
    {
        public readonly GameObject GameObject;

        public Throw_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}