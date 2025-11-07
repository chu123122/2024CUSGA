using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    void Start()
    {
        if (virtualCamera != null)
            noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float amplitude, float frequency, float duration)
    {
        if (noise != null)
        {
            noise.m_AmplitudeGain = amplitude;
            noise.m_FrequencyGain = frequency;
            StartCoroutine(StopShake(duration));
        }
    }

    private IEnumerator StopShake(float duration)
    {
        yield return new WaitForSeconds(duration);
        noise.m_AmplitudeGain = 0f;
    }
}
