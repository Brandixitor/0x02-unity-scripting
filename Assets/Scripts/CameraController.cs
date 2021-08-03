using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject player;
    private Vector3 offset; 
    public GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = camera.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = player.transform.position + offset;
    }
}
