using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField]private float baseStoreCost,baseStoreProfit,storeTimer,storeMultiplier;
    [SerializeField] private Text countText,currentBalanceText,buyButtonText;
    [SerializeField] private Slider progressSlider;

    [SerializeField] private Button buyButton;
    [SerializeField] GameManager gameManager;
    //Timer
    private float currentTimer=0f;
    bool startTimer;
    public bool ManagerUnlocked;
    private float nextStoreCost;
    [HideInInspector]public int storeCount;
    //
    void Start()
    {
        startTimer=false;
        nextStoreCost=baseStoreCost;
        buyButtonText.text="Buy "+nextStoreCost.ToString("C2");
        countText.text=storeCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer)
        {
            currentTimer+=Time.deltaTime;
            if(currentTimer>storeTimer)
            {
                if(!ManagerUnlocked)
                    startTimer=false;
                currentTimer=0;
                GameManager.instance.currentBalance+=baseStoreProfit*storeCount;
                GameManager.instance.AddToBalance(baseStoreProfit*storeCount);
            }
            
        }
        progressSlider.value=currentTimer/storeTimer;
        CheckStoreBuy();
    }
    public void StoreOnClick()
    {
        if(!startTimer)
            startTimer=true;
        
    }
    public void BuyClick()
    {
        if(!GameManager.instance.CanBuy(nextStoreCost))
            return;
        storeCount++;
        countText.text=storeCount.ToString();
        GameManager.instance.AddToBalance(-nextStoreCost);
        nextStoreCost=(baseStoreCost*Mathf.Pow(storeMultiplier,storeCount));
        buyButtonText.text="Buy "+nextStoreCost.ToString("C2");
    }
    void CheckStoreBuy()
    {
        if(GameManager.instance.CanBuy(nextStoreCost))
            buyButton.interactable=true;
        else
            buyButton.interactable=false;
    }
}
