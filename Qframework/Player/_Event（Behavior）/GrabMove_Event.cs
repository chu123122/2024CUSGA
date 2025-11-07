using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct GrabMove_Event
    {
        public readonly GameObject GameObject;

        public GrabMove_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}