using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct MarblesBounce_Event
    {
        public readonly GameObject GameObject;

        public MarblesBounce_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}