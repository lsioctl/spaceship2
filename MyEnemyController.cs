using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyController : MonoBehaviour {

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
    private Rigidbody playerRb;
    private Rigidbody rb;
    public float range;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb != null && Time.time > nextFire)
        {
            if (playerRb.position.z < rb.position.z)
            {
                if ((playerRb.position.x > rb.position.x - 10*range) && (playerRb.position.x < rb.position.x + 10*range))
                {
                    nextFire = Time.time + fireRate;
                    // we do not need a reference to this, it will handle himself
                    //GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            }
        };


    }


    // Call before each physics steps if monobehaviour is set
    private void FixedUpdate()
    {
        float moveX;

        if (playerRb == null)
        {
            // player has been destroyed
            moveX = 0.0f;
        }
        else
        {
         

            // we use range to avoid flickering as the enemy seems to never
            // reach the exact player position.x
            // see: https://stackoverflow.com/questions/36675201/unity3d-how-to-stop-the-flickering-that-occurs-when-the-character-stops-moving

            if (playerRb.position.x > rb.position.x + range)
            {
                moveX = 1.0f;
            }
            else if (playerRb.position.x < rb.position.x - range)
            {
                moveX = -1.0f;
            }
            else
            {
                moveX = 0.0f;
            }
        }

        Vector3 movement = new Vector3(moveX, 0.0f, -1);

        rb.velocity = movement * speed;


        // we constraint the ship to the game space
        // as the code is called before each frame, reset is position to the border
        // if border hit is ok

        /* find a way to reuse player controller boundary
         * or better: boundary game object
         * 
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );*/

        //rigidbody.rotation = Quaternion.Euler(0.0f, rigidbody.rotation.y, rigidbody.velocity.x * -tilt);
        //fix: how keeping original y rotation
        // done as this gameobject as now a null rotation
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}
