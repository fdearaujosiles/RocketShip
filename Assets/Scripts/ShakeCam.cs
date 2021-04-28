using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCam : MonoBehaviour
{
    [SerializeField] private float intensity = 5f;
    private CinemachineVirtualCamera _virtualCamera;
    void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin noise =
            _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        noise.m_AmplitudeGain = intensity;

    }
}
