using UnityEngine;

public struct PLayerDead_Event
{
    public readonly Vector3 RestartPosition;
    public PLayerDead_Event(Vector3 restartPosition)
    {
        RestartPosition = restartPosition;
    }

}