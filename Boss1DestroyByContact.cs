using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1DestroyByContact : MonoBehaviour {

    public int hitsToDestroy;
    private int hitCount;
    public GameObject explosion;
    private MyGameController gameController;
    public int scoreValue;
    public int destroyScoreValue;

    // We can't set this in the inspector
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

        gameController.AddScore(scoreValue);
        hitCount++;
        if (hitCount == hitsToDestroy)
        {
            // Destroy the object itself
            Destroy(gameObject);
            gameController.GameOver();
            //Debug.Log("destroyed by" + other.name);
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if (tag == "Player" || other.tag == "Player")
        {
            gameController.GameOver();
        }

    }
}
