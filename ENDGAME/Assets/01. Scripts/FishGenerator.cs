using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FishKinds
{
    purple = 0,
    orange,
    yellow,
    red
}

public class FishGenerator : MonoBehaviour
{
    public FishKinds fishGenerateKind;
    public FishKinds fishCostKind;

    public int fishGenerateAmount;
    public int fishCostAmount;

    public Text fishGenerateText;
    public Text fishCostText;

    public void GenerateFish()
    {
        ResourceManager.Instance.AddResource((int)fishGenerateKind, fishGenerateAmount);
        
    }

    public void UpgradeTool()
    {
        if (!ResourceManager.Instance.CheckResource((int)fishCostKind, fishCostAmount)) return;

        ResourceManager.Instance.AddResource((int)fishCostKind, -fishCostAmount);

        if (fishGenerateAmount == 0)
        {
            fishGenerateAmount = 1;
        }
        else
        {
            fishGenerateAmount *= 3;
            fishCostAmount = fishGenerateAmount * 6;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (fishGenerateAmount < 1000)
        {
            fishGenerateText.text = fishGenerateAmount.ToString();
        }
        else if (fishGenerateAmount < 1000000)
        {
            fishGenerateText.text = (fishGenerateAmount / 1000).ToString() + "K";
        }
        else
        {
            fishGenerateText.text = (fishGenerateAmount / 1000000).ToString() + "M";
        }

        if (fishCostAmount < 1000)
        {
            fishCostText.text = "x " + fishCostAmount.ToString();
        }
        else if (fishCostAmount < 1000000)
        {
            fishCostText.text = "x " + (fishCostAmount / 1000).ToString() + "K";
        }
        else
        {
            fishCostText.text = "x " + (fishCostAmount / 1000000).ToString() + "M";
        }
    }

    // import

    // export

     // inner

    void Start()
    {
        FisherManager.Instance.generateFishes += GenerateFish;
    }

    void Update()
    {
        
    }
}
