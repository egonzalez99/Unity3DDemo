using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask hitRegister; // layer that the raycast will interact

    public delegate void CubeHitEvent(GameObject cube);
    public static event CubeHitEvent cubeHit; // event for when a cube is hit

    
    void Update()
    {
        // check for mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // create a ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // create a raycast and store the info
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, hitRegister))
            {
                // if the raycast hit a cube with the tag cube
                if (hitInfo.collider.CompareTag("Cube"))
                {
                    //when the cube is collided it is store to event script
                    GameObject hitCube = hitInfo.collider.gameObject;

                    // calls the event when cube is hit
                    cubeHit.Invoke(hitCube);
                }
            }
        }
    }
}
