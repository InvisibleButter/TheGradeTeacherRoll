using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyHandMovement : MonoBehaviour
{
    Plane plane = new Plane(Vector3.up, 0);
    Rigidbody rigid;
    public Transform offset;
    Vector3 startPosition;
    float MAX_ARMLENGTH = 100;
    public float y=400;
    public float chainLength;
    public Transform anker;

    private void Awake()
    {
        rigid = this.GetComponentInChildren<Rigidbody>();
        startPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            Vector3 newPos = ray.GetPoint(distance);
            offset.position = new Vector3(newPos.x,y , newPos.z);
            rigid.transform.LookAt(new Vector3(newPos.x,y, newPos.z));
            rigid.transform.Rotate(new Vector3(90,0,0));
            //if(Vector3.Distance(offset.position, anker.position)>chainLength)
                rigid.MovePosition(offset.position);
        }
    }
}
