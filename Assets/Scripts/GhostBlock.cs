using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    GameObject parent;
    TetrisBlock parentTetris;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepositionBlock());
    }

    public void SetParent(GameObject parent)
    {
        this.parent = parent;
        this.parentTetris = this.parent.GetComponent<TetrisBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PositionGhost()
    {
        transform.position = parentTetris.transform.position;
        transform.rotation = parentTetris.transform.rotation;
    }

    IEnumerator RepositionBlock()
    {
        while (parentTetris.enabled)
        {
            PositionGhost();

            // MOVE DOWNWARDS
            MoveDownwards();
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
        yield return null;
    }

    void MoveDownwards()
    {
        while(CheckValidMove())
        {
            transform.position += Vector3.down;
        }
        if(!CheckValidMove())
        {
            transform.position += Vector3.up;
        }
    }

    bool CheckValidMove()
    {
        foreach (Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            if (!Playfield.instance.CheckInsideGrid(pos))
                return false;
        }

        foreach (Transform child in transform)
        {
            Vector3 pos = Playfield.instance.Round(child.position);
            Transform t = Playfield.instance.GetTransformOnGridPos(pos);

            if (t != null && t.parent == parent.transform)
            {
                return true;
            } else if (t != null)
            {
                return false;
            }
        }

        return true;
    }
}
