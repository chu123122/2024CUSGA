using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct Rebirth_Event
    {
        public readonly GameObject GameObject;

        public Rebirth_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}