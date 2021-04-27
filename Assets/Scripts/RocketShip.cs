using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    private Rigidbody _rb;
    private AudioSource _audio;
    [SerializeField] private float thrust;
    [SerializeField] private float rotationThrust;
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _audio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        MoveRocket();
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }

    private void MoveRocket()
    {
        Thrusting();
        Rotating();
    }

    private void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddRelativeForce(Vector3.up * (thrust * Time.deltaTime));
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
        }
        else
        {
            _audio.Stop();
        }
    }

    private void Rotating()
    {
        _rb.freezeRotation = true;
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * (rotationThrust * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * (rotationThrust * Time.deltaTime));
        }
        
        _rb.freezeRotation = false;
    }
}