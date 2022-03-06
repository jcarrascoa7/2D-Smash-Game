using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input (A , D , <- , ->).
        float h = Input.GetAxis("Horizontal");

        // Get the vertical input (W , S , UpArrow , DownArrow).
        float v = Input.GetAxis("Vertical");

        // Vector2 is a DataType that holds 2 floats.
        Vector2 pos = transform.position;

        // Move the player (Solo se esta cambiando el vector pos, no el componente transform).
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        // Set the position of the player.
        transform.position = pos;
    }
}
