using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct Load_Event
    {
        public readonly GameObject GameObject;

        public Load_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}