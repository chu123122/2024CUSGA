using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct GrabHit_Event
    {
        public readonly GameObject GameObject;

        public GrabHit_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}