using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    Camera cam;
    Stick stickManager; 
    Magnet magnetManager;
    public GameObject mouse;

    public GameObject[] magnets;
    CircleCollider2D[] magnetCollider;

    void Start()
    {
        cam = Camera.main;
        stickManager = GameObject.Find("stick").GetComponent<Stick>();
        magnetCollider = new CircleCollider2D[magnets.Length];
    }

    void Update()
    {
        CamFollow(stickManager.transform);
        mouse.transform.position = stickManager.dir + stickManager.pivot.transform.position;
        for (int i = 0; i < magnets.Length; i++)
        {
            magnetCollider[i] = magnets[i].GetComponent<CircleCollider2D>();
            if (magnetCollider[i].bounds.Contains(stickManager.pivot.transform.position))
            {
                print("Hola");
                stickManager.inOut = true;
                break;
            }
            else
            {
                stickManager.inOut = false;
            }
        }
    }
    void CamFollow(Transform pos)
    {
        Vector3 camFollow = new Vector3(pos.position.x, pos.position.y, -20);
        float camSpeed = 10;
        cam.transform.position = Vector3.Lerp(cam.transform.position, camFollow, camSpeed * Time.deltaTime);
    }
}
