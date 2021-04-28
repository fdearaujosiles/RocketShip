using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RocketShip : MonoBehaviour
{
    private Rigidbody _rb;
    private static AudioSource _audio;
    private GameController _gc;
    
    [SerializeField] private float thrust;
    [SerializeField] private float rotationThrust;
    [SerializeField] private AudioClip engine, wallHit, success;
    [SerializeField] private ParticleSystem engineParticles, explosionParticles;

    private bool isAlive = true;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _gc = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if(isAlive) {MoveRocket();}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isAlive || !_gc.collisions) {return;}
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Fuel");
                Destroy(other.gameObject);
                break;
            case "Ring":
                other.gameObject.GetComponent<Ring>().PassedThrough();
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isAlive || !_gc.collisions) {return;}
        switch (other.gameObject.tag)
        {
            case "Respawn":
                StopRocket(wallHit);
                explosionParticles.Play();
                _gc.ResetGame();
                break;
            case "Finish":
                StopRocket(success);
                _gc.NextLevel();
                break;
        }
    }

    private void StopRocket(AudioClip audioClip)
    {
        isAlive = false;
        _audio.Stop();
        engineParticles.Stop();
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.gameObject.transform.position);
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
            engineParticles.Play();
            _rb.AddRelativeForce(Vector3.up * (thrust * Time.deltaTime));
            if (!_audio.isPlaying)
            {
                _audio.PlayOneShot(engine);
            }
        }
        else
        {
            engineParticles.Stop();
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
