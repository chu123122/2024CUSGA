using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct MablessGet_Event
    {
        public readonly GameObject GameObject;

        public MablessGet_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}