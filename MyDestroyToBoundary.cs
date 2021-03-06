﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestroyToBoundary : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("Boundary detroyed: " + other.name);
    }
}
