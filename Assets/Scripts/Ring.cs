using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private bool passed = false;

    public void PassedThrough()
    {
        passed = true;
        GetComponent<MeshRenderer>().material.color = Color.green;
        Debug.Log("Ring-a-ding-ding!");
    }
}
