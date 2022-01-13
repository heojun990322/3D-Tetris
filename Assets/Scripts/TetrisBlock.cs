using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    float prevTime;
    float fallTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - prevTime > fallTime)
        {
            transform.position += Vector3.down;
            
            if (!CheckValidMove())
            {
                transform.position += Vector3.up;
                //DELETE LAYER IF POSSIBLE

                enabled = false;
                //CREATE A NEW TETRIS BLOCK
                Playfield.instance.SpawnNewBlock();
            } else
            {
                //UPDATE THE GRID
                Playfield.instance.UpdateGrid(this);
            }
            
            prevTime = Time.time;
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
            if (t != null && t.parent != transform)
                return false;
        }
        
        return true;
    }
}
