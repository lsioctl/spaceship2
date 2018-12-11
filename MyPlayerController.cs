using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyPlayerController : MonoBehaviour {

    public float speed;
    //public MyBoundary boundary;
    public float tilt;
    public GameObject shot;
    // with this we would have to write shotSpawn.tranform.rotation ...
    // public GameObject shotSpawn;
    // we will still use a reference to a game object in editor, but Unity will find and use the transform component
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public StickToVisualBoundary visualBoundary;

    // Use this for initialization
    void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // we do not need a reference to this, it will handle himself
            //GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        };


    }

    // Call before each physics steps if monobehaviour is set
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.velocity = movement * speed;

        // we constraint the ship to the game space
        // as the code is called before each frame, reset is position to the border
        // if border hit is ok

        rigidbody.position = visualBoundary.ClampPosition(rigidbody.position);

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
        

    }
}
