using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public Rigidbody rb;
    public float speed = 1000f;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GetAxis Inputs.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z).normalized;
        Vector3 force = dir * speed * Time.deltaTime; 
        rb.AddForce(force);

    }

    void OnTriggerEnter(Collider other) // Function to add +1 to the score and destroy the coin upon touching it.
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
    }

}
