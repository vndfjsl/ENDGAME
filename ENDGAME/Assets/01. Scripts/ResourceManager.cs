using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    public int[] fishAmounts; // 4°³
    public Text[] fishAmountTexts; // 4°³

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddResource(int numberOfFish, int amount)
    {
        fishAmounts[numberOfFish] += amount;
        fishAmountTexts[numberOfFish].color = Color.green;
        fishAmountTexts[numberOfFish].transform.DOScale(1.2f, 0.2f).OnComplete(() =>
        {
            
            fishAmountTexts[numberOfFish].color = Color.white;
            fishAmountTexts[numberOfFish].transform.DOScale(1f, 0.2f);
        });
        fishAmountTexts[numberOfFish].text = fishAmounts[numberOfFish].ToString();
    }

    public bool CheckResource(int numberOfFish, int cost)
    {
        if(fishAmounts[numberOfFish] < cost)
        {
            return false;
        }

        return true;
    }

    public void Texts(int numberOfFish)
    {
        StartCoroutine(TextColorChange(numberOfFish, fishAmountTexts[numberOfFish]));
    }

    private IEnumerator TextColorChange(int numberOfFish, Text c)
    {
        c.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        c.color = Color.white;
    }
}
