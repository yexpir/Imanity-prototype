using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {

    public GameObject half1;
    public GameObject half2;

    public GameObject pivot = null;
    public GameObject remPivot = null;

    BoxCollider2D half1Collider;
    BoxCollider2D half2Collider;

    bool half1Selecet = false;
    bool half2Selecet = false;

    public bool inOut = false;

    Vector3 mousePosition;
    public Vector3 mouseHit;
    public Vector3 dir;


    public float rayDistance;
    public LayerMask rayLayer;

    void Start ()
    {
        half1Collider = half1.GetComponent<BoxCollider2D>();
        half2Collider = half2.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mouseHit = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseHit.z = 0;
        dir = (mouseHit - pivot.transform.position).normalized * 5f;

        RaycastHit2D hit = Physics2D.Raycast(pivot.transform.position, dir, rayDistance, rayLayer);
        if (hit)
        {
            Vector3 fixedMouse = dir + pivot.transform.position;
            Vector3 target = Vector3.Lerp(fixedMouse, hit.collider.gameObject.transform.position, Time.deltaTime * Vector3.Distance(fixedMouse, hit.collider.gameObject.transform.position) * 20.0f);
            Vector3 newDir = target - pivot.transform.position;
            dir = newDir;
            print(dir);
        }
        Debug.DrawRay(pivot.transform.position, dir, Color.green);

        if(Input.GetMouseButton(0) && (half1Selecet || half2Selecet) && inOut)
        {
            transform.parent = pivot.transform;
            pivot.transform.up = dir;
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.parent = null;
            half1Selecet = false;
            half2Selecet = false;
        }
        GetPivot(Input.GetMouseButtonDown(0), mouseHit);
    }

    void GetPivot(bool click, Vector3 hit)
    {
        if (click && half1Collider.bounds.Contains(hit))
        {
            //print("1");
            pivot.transform.rotation = half1.transform.rotation;
            pivot.transform.position = half1.transform.position;
            half1Selecet = true;
            half2Selecet = false;
            remPivot = half2;
        }
        else if (click && half2Collider.bounds.Contains(hit))
        {
            //print("2");
            pivot.transform.rotation = half2.transform.rotation;
            pivot.transform.position = half2.transform.position;
            half2Selecet = true;
            half1Selecet = false;
            remPivot = half1;
        }
    }
}
