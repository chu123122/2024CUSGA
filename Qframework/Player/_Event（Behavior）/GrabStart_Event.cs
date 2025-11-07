using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct GrabStart_Event
    {
        public readonly GameObject GameObject;

        public GrabStart_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}