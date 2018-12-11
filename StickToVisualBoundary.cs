using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToVisualBoundary : MonoBehaviour {

    private float xMax, xMin, zMax, zMin;

	// Use this for initialization
	void Start () {
        xMax = transform.position.x + transform.localScale.x / 2;
        xMin = transform.position.x - transform.localScale.x / 2;
        zMax = transform.position.z + transform.localScale.z / 2;
        zMin = transform.position.z - transform.localScale.z / 2;
    }


    public Vector3 ClampPosition(Vector3 position)
    {
        // we constraint the position to the game space
        // as the code is called before each frame, reset is position to the border
        // if border hit is ok

       
        Vector3 newPosition = new Vector3
        (
            Mathf.Clamp(position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(position.z, zMin, zMax)
        );

        return newPosition;

    }
    
}
