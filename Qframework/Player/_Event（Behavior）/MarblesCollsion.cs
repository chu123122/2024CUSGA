using UnityEngine;

namespace QFramework.Player._Event_Behavior_
{
    public struct MarblesCollsion
    {
        public readonly GameObject GameObject;

        public MarblesCollsion(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }
    }
}