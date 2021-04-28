using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));    
    }
}
