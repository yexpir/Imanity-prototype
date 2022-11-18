using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick2 : MonoBehaviour {

    Vector3 mousePosition;
    Vector3 mouseHit;
    Vector3 dir;

    void Update()
    {
        mousePosition = Input.mousePosition;
        mouseHit = Camera.main.ScreenToWorldPoint(mousePosition);
        dir = mouseHit - transform.position;
        dir.z = 0;
        transform.up = dir;
    }
}
