using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    public Rigidbody rb; // Rigidbody variable.
    public float speed = 1000f; // Player speed.
    private int score; // Score of the player
    public int health = 5; // Health of the player.


    // Update is called once per frame
    void Update()
    {
        // GetAxis Inputs.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z).normalized;
        Vector3 force = dir * speed * Time.deltaTime; 
        rb.AddForce(force);



        // Condition to reset the score upon health reaches 0.
        if (health == 0)
        {
            Debug.Log("Game Over!");
            health = 5;
            score = 0;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            
        }

    }

    void OnTriggerEnter(Collider other) 
    {
        // Condition to add +1 to the score and destroy the coin upon touching it.
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }

        // Condition to manage the health of the player.
        if (other.tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }


        // Condition to let the player know that they've won upon touching the finish line.
        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }

    }
}
