using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestroyByContact : MonoBehaviour {

    public GameObject explosion;
    private MyGameController gameController;
    public int scoreValue;

    // We can't set this in the inspector
    // It works when the prefab is in the scene but not under prefab
    // TO DIG, or rewatch the video tutorial

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<MyGameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // we have to code this because of the Trigger Collider
    // a Trigger Collider does not use physics

    private void OnTriggerEnter(Collider other)
    {



        // Note: destroy mark the object to be destroyed
        // it is effectevly when the frame is processed
        // so the order is not important

        // Avoid to destroy bug as we are in Boundary
        if (other.tag == "BoundaryTag")
        {
            return;
        }
        if (tag == "Player" || )
        {
            // Avoid friendly or self fire (the last appends when position reset at boundary)
            if (other.tag == "Bolt")
            {
                return;
            }
        }

        
        // Destroy the object itself
        Destroy(gameObject);
        Debug.Log("Destroyed by: " + other.name);

        gameController.AddScore(scoreValue);

        Instantiate(explosion, transform.position, transform.rotation);
        if (tag == "Player" || other.tag == "Player")
        {
            gameController.GameOver();
        }

    }
}
