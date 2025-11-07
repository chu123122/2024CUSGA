using UnityEngine;
public struct HaveForceDirection_Event
{
    public readonly Vector3 playerDirection;
    public readonly Vector3 circleDirection;
    public HaveForceDirection_Event(Vector3 _playerDirection, Vector3 _circleDirection)
    {
        playerDirection = _playerDirection;
        circleDirection = _circleDirection;
    }
}
