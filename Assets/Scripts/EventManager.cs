using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private void OnEnable()
    {
        // when player does hit the cubes
        Player.cubeHit += CubeIsHit;
    }

    private void OnDisable()
    {
        // when player does not hit the cubes
        Player.cubeHit -= CubeIsHit;
    }

    private void CubeIsHit(GameObject cube)
    {
        // if the cube is hit then its destroyed.
        if (cube != null)
        {
            Destroy(cube);
        }
    }
}
