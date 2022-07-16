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
            Vector3 newPos = ray.GetPoint(distance)+offset.position;
            if(Vector3.Distance(newPos,startPosition)<MAX_ARMLENGTH)
                rigid.MovePosition(new Vector3(newPos.x, transform.position.y, newPos.z));
        }
    }
}
