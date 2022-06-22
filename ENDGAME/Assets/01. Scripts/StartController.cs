using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public Button boat;
    public CanvasGroup mainPanel;

    void Start()
    {
        mainPanel.interactable = false;
        mainPanel.blocksRaycasts = false;
        mainPanel.alpha = 0;
    }

    void Update()
    {
        
    }

    public void GameStart()
    {
        boat.transform.DOMoveY(750f, 1f);
        mainPanel.interactable = true;
        mainPanel.blocksRaycasts = true;
        mainPanel.DOFade(1f, 1f);
    }
}
