using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Previewer : MonoBehaviour
{
    public static Previewer instance;

    public GameObject[] previewBlocks;

    GameObject currentActive;

    private void Awake()
    {
        instance = this;
    }

    public void ShowPreview(int index)
    {
        Destroy(currentActive);

        currentActive = Instantiate(previewBlocks[index], transform.position, Quaternion.identity) as GameObject;

        Vector3 sumVector = new Vector3(0, 0, 0);

        foreach (Transform child in currentActive.transform)
        {
            sumVector += child.position;
        }
        
        Vector3 centerVector = sumVector / currentActive.transform.childCount;
        Vector3 distance = transform.position - centerVector;

        currentActive.transform.position += distance;
    }
}
