using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ButtonInputs : MonoBehaviour
{
    public static ButtonInputs instance;

    public GameObject[] rotateCanvases;
    public GameObject moveCanvas;

    GameObject activeBlock;
    TetrisBlock activeTetris;
    Button clickButton;

    bool moveIsOn = true;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetInputs();
    }

    void RepositionToActiveBlock()
    {
        Vector3 sumVector = new Vector3(0, 0, 0);

        if (activeBlock != null)
        {
            foreach (Transform child in activeBlock.transform)
            {
                sumVector += child.position;
            }

            Vector3 centerVector = sumVector / activeBlock.transform.childCount;

            transform.position = centerVector;
        }
    }

    public void SetActiveBlock(GameObject block, TetrisBlock tetris)
    {
        activeBlock = block;
        activeTetris = tetris;
    }

    // Update is called once per frame
    void Update()
    {
        RepositionToActiveBlock();

        KeySwitchInputs();
        if (moveIsOn)
        {
            KeyMoveBlock();
        }
        else
        {
            KeyRotateBlock();
        }
        KeySetHighSpeed();
    }

    public void MoveBlock(string direction)
    {
        if (activeBlock != null)
        {
            if (direction == "left")
            {
                activeTetris.SetInput(Vector3.left);
            }
            if (direction == "right")
            {
                activeTetris.SetInput(Vector3.right);
            }
            if (direction == "forward")
            {
                activeTetris.SetInput(Vector3.forward);
            }
            if (direction == "back")
            {
                activeTetris.SetInput(Vector3.back);
            }
        }
    }

    public void RotateBlock(string rotation)
    {
        if (activeBlock != null)
        {
            // X axis
            if (rotation == "posX")
            {
                activeTetris.SetRotationInput(new Vector3(90, 0, 0));
            }
            if (rotation == "negX") 
            {
                activeTetris.SetRotationInput(new Vector3(-90, 0, 0));
            }

            // Y axis
            if (rotation == "posY")
            {
                activeTetris.SetRotationInput(new Vector3(0, 90, 0));
            }
            if (rotation == "negY") 
            {
                activeTetris.SetRotationInput(new Vector3(0, -90, 0));
            }

            // Z axis
            if (rotation == "posZ")
            {
                activeTetris.SetRotationInput(new Vector3(0, 0, 90));
            }
            if (rotation == "negZ") 
            {
                activeTetris.SetRotationInput(new Vector3(0, 0, -90));
            }
        }
    }

    public void SwitchInputs()
    {
        moveIsOn = !moveIsOn;
        SetInputs();
    }

    void SetInputs() {
        moveCanvas.SetActive(moveIsOn);
        foreach (GameObject c in rotateCanvases)
        {
            c.SetActive(!moveIsOn);
        }
    }

    public void SetHighSpeed()
    {
        activeTetris.SetSpeed();
    }

    void KeyMoveBlock()
    {
        if (Input.GetKeyDown(KeyCode.A)) // LEFT
        {
            clickButton = moveCanvas.transform.GetChild(1).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D)) // RIGHT
        {
            clickButton = moveCanvas.transform.GetChild(0).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W)) // FORWARD
        {
            clickButton = moveCanvas.transform.GetChild(2).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S)) // BACK
        {
            clickButton = moveCanvas.transform.GetChild(3).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
    }

    void KeyRotateBlock()
    {
        // Y AXIS
        if (Input.GetKeyDown(KeyCode.S)) // posY
        {
            clickButton = rotateCanvases[1].transform.GetChild(1).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D)) // negY
        {
            clickButton = rotateCanvases[1].transform.GetChild(0).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }

        // X AXIS
        if (Input.GetKeyDown(KeyCode.Q)) // posX
        {
            clickButton = rotateCanvases[0].transform.GetChild(0).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.A)) // negX
        {
            clickButton = rotateCanvases[0].transform.GetChild(1).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }

        // Z AXIS
        if (Input.GetKeyDown(KeyCode.W)) // posZ
        {
            clickButton = rotateCanvases[2].transform.GetChild(1).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E)) // negZ
        {
            clickButton = rotateCanvases[2].transform.GetChild(0).gameObject.GetComponent<Button>();
            clickButton.onClick.Invoke();
        }
    }

    void KeySwitchInputs()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SwitchInputs();
        }
    }
    
    void KeySetHighSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetHighSpeed();
        }
    }
}
