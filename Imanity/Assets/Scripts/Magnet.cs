using UnityEngine;

public class Magnet : MonoBehaviour {

    Stick stickManager;

    //public bool triggerEnter = false;
    CircleCollider2D coll;

    void Start()
    {
        stickManager = GameObject.Find("stick").GetComponent<Stick>();
    }

    void Update()
    {
        coll = GetComponent<CircleCollider2D>();
        if (coll.bounds.Contains(stickManager.pivot.transform.position))
        {
            gameObject.layer = 0;
        }
        else
        {
            gameObject.layer = 9;
        }
        //print(gameObject.layer);
    }
}
