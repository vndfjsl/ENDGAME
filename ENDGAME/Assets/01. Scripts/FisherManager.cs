using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FisherManager : MonoBehaviour
{
    public static FisherManager Instance { get; private set; }

    private float timer;
    public float timerMax;

    public int fishingAmount = 3;
    public int fishingCost = 10;
    public Text fishingCostText;

    public int redFish = 0;
    public Text redText;

    public GameObject clearPanel;

    public Action generateFishes;

    // import

    // export

    // inner

    private void Awake()
    {
        Instance = this;
        timerMax = 1f;
    }

    public void FishingRod()
    {
        ResourceManager.Instance.AddResource(0, fishingAmount);
    }

    public void UpgradeFishingRod()
    {
        if (ResourceManager.Instance.CheckResource(0, fishingCost))
        {
            ResourceManager.Instance.AddResource(0, -fishingCost);
            fishingAmount += 8;
            GameManager.Instance.fishSpawn = fishingAmount;
            fishingCost = (int)(fishingAmount * 1.5f);
            fishingCostText.text = "x " + fishingCost;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer += timerMax;
            if (redFish >= 50000000)
            {
                clearPanel.SetActive(true);
            }
            generateFishes();
            redText.text = redFish.ToString();
            return;
        }

        

    }
}
