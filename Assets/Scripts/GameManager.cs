using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score;
    int level;
    int layerCleared;

    bool gameIsOver;

    float fallSpeed;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetScore(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int amount)
    {
        score += amount;
        CalculateLevel();
        // UPDATE UI
        UIHandler.instance.UpdateUI(score, level, layerCleared);
    }

    public float ReadFallSpeed()
    { 
        return fallSpeed;
    }

    public void LayerCleared(int amount)
    {
        int clearScore = 400;
        layerCleared += amount;

        switch (amount)
        {
            case 1:
                SetScore(clearScore);
                break;
            case 2:
                SetScore(clearScore * 2 * 2);
                break;
            case 3:
                SetScore(clearScore * 3 * 2);
                break;
            case 4:
                SetScore(clearScore * 4 * 2);
                break;

        }
    }

    void CalculateLevel()
    {
        if (score >= 0 && score <= 10000)
        {
            fallSpeed = 3f;
            level = 1;
        }
        else
        {
            for (int i = 1; i < 10; i++)
            {
                if (score > i * 10000 && score <= i * 10000 + 10000)
                {
                    level = i + 1;
                    fallSpeed -= 0.25f;
                }
            }
        }
    }
    
    public bool ReadGameIsOver()
    {
        return gameIsOver;
    }

    public void SetGameIsOver()
    {
        gameIsOver = true;
        UIHandler.instance.ActivateSetGameOverWindow();
    }
}
