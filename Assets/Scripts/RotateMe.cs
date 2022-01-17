using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 sumVector = new Vector3(0, 0, 0);

        foreach (Transform child in transform)
        {
            sumVector += child.position;
        }

        Vector3 centerVector = sumVector / transform.childCount;

        transform.RotateAround(centerVector, Vector3.up, speed * Time.deltaTime);
    }
}
