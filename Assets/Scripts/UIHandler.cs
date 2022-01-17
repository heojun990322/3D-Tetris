using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    public Text scoreText;
    public Text levelText;
    public Text layersText;

    public GameObject gameOverWindow;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(int score, int level, int layers)
    {
        scoreText.text = "Score : " + score.ToString("D7");
        levelText.text = "Level : " + level.ToString("D2");
        layersText.text = "Layers : " + layers.ToString("D7");
    }

    public void ActivateSetGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
