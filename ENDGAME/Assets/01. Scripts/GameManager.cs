using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region |Singleton|
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance != null)
                return instance;
            else return null;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject fadePanel;

    public GameObject fishPrefab;
    public Transform fishSpawnTrm;

    public int fishCount = 0;
    public Text fishText;
    public GameObject fishPanel;

    public int fishSpawn = 1;
    public GameObject fishShopPanel;
    public GameObject G;







    public GameObject shopPanel;
    public GameObject fisherPanel;
    public GameObject endingPanel;
    public GameObject settingPanel;

    public int fishingGenerateAmount = 1;

    void Start()
    {
        PoolManager.CreatePool<Fish>(fishPrefab, fishSpawnTrm, 100);
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        
        fadePanel.GetComponent<CanvasGroup>().DOFade(0f, 1f).OnComplete( () =>
        {
            fadePanel.SetActive(false);
        });
    }

    public void ScreenTouch()
    {
        Debug.Log($"화면을 클릭했습니다 ({Input.mousePosition.x}, {Input.mousePosition.y})");
        // 물고기 낚이게해줘
        StartCoroutine(Fishing());
    }

    IEnumerator Fishing()
    {
        FisherManager.Instance.FishingRod();

        int count = (fishSpawn <= 50) ? fishSpawn : 50;

        for (int i = 0; i < count; i++)
        {
            PoolManager.GetItem<Fish>().Rotate();
            
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    public void OpenShop()
    {
        shopPanel.SetActive(true);
        fisherPanel.SetActive(false);
        endingPanel.SetActive(false);
    }

    public void OpenFisher()
    {
        shopPanel.SetActive(false);
        fisherPanel.SetActive(true);
        endingPanel.SetActive(false);
    }

    public void OpenEnding()
    {
        shopPanel.SetActive(false);
        fisherPanel.SetActive(false);
        endingPanel.SetActive(true);
    }

    public void SettingActive(bool active)
    {
        settingPanel.SetActive(active);
    }
}
