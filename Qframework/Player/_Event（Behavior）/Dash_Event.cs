using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct Dash_Event
    {
        public readonly GameObject GameObject;

        public Dash_Event(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}