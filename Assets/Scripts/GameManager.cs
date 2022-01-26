using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //properties
    public int isFastFood
    {
        set
        {
            PlayerPrefs.SetInt("isFastFood",value);
        }
        get
        {
            return PlayerPrefs.GetInt("isFastFood",0);
        }
    }
    public int isShop
    {
        set
        {
            PlayerPrefs.SetInt("isShop",value);
        }
        get
        {
            return PlayerPrefs.GetInt("isShop",0);
        }
    }
    public int isBank
    {
        set
        {
            PlayerPrefs.SetInt("isBank",value);
        }
        get
        {
            return PlayerPrefs.GetInt("isBank",0);
        }
    }
    public int isHotel
    {
        set
        {
            PlayerPrefs.SetInt("isHotel",value);
        }
        get
        {
            return PlayerPrefs.GetInt("isHotel",0);
        }
    }
    public int isCoffee
    {
        set
        {
            PlayerPrefs.SetInt("isCoffee",value);
        }
        get
        {
            return PlayerPrefs.GetInt("isCoffee",0);
        }
    }

    [HideInInspector] public float currentBalance;
    [SerializeField] private Text currentBalanceText;
    [SerializeField] private GameObject[] stores,storeBuyArea;
    [SerializeField] private int[] storesPrices;
    public static GameManager instance;
    void Awake()
    {
        if(instance==null)
            instance=this;
        StoresControl(true,false);
        currentBalance=PlayerPrefs.GetFloat("balance",0);
        currentBalanceText.text=currentBalance.ToString("C2");

    }
    public void AddToBalance(float amt)
    {
        currentBalance+=amt;
        currentBalanceText.text=currentBalance.ToString("C2");

    }
    public bool CanBuy(float AmtToSpend)
    {
        if(AmtToSpend>currentBalance)
            return false;
        else
            return true;
    }
    public void BuyStore(GameObject gameObject)
    {
        switch(gameObject.tag)
        {
            case "FastFood":
                if(storesPrices[0]<=currentBalance)
                {
                    currentBalance-=storesPrices[0];
                    isFastFood=1;
                    stores[0].SetActive(true);
                }
                break;
            case "Shop":
                if(storesPrices[1]<=currentBalance)
                {
                    currentBalance-=storesPrices[1];
                    isShop=1;
                    stores[1].SetActive(true);
                }
                break;
            case "Bank":
                if(storesPrices[2]<=currentBalance)
                {
                    currentBalance-=storesPrices[2];
                    isBank=1;
                    stores[2].SetActive(true);
                }
                break;
            case "Hotel":
                if(storesPrices[3]<=currentBalance)
                {
                    currentBalance-=storesPrices[3];
                    isHotel=1;
                    stores[3].SetActive(true);
                }
                break;
            case "Coffee":
                if(storesPrices[4]<=currentBalance)
                {
                    currentBalance-=storesPrices[4];
                    isCoffee=1;
                    stores[4].SetActive(true);
                }
                break;
        }
        StoresControl(true,false);
    }
    void StoresControl(bool isStart,bool isFinish)
    {
        if(isFastFood==1)
        {
            stores[0].SetActive(true);
            storeBuyArea[0].GetComponent<Button>().enabled=false;
            storeBuyArea[0].GetComponentInChildren<Text>().text="Purchased";
            if(isStart)
                stores[0].GetComponent<StoreManager>().storeCount=PlayerPrefs.GetInt("fastfoodStoreCount",1);
            if(isFinish)
                PlayerPrefs.SetInt("fastfoodStoreCount",stores[0].GetComponent<StoreManager>().storeCount);
        }
        if(isShop==1)
        {
            stores[1].SetActive(true);
            storeBuyArea[1].GetComponent<Button>().enabled=false;
            storeBuyArea[1].GetComponentInChildren<Text>().text="Purchased";
            if(isStart)
                stores[1].GetComponent<StoreManager>().storeCount=PlayerPrefs.GetInt("shopStoreCount",1);
            if(isFinish)
                PlayerPrefs.SetInt("shopStoreCount",stores[1].GetComponent<StoreManager>().storeCount);
        }
        if(isBank==1)
        {
            stores[2].SetActive(true);
            storeBuyArea[2].GetComponent<Button>().enabled=false;
            storeBuyArea[2].GetComponentInChildren<Text>().text="Purchased";
            if(isStart)
                stores[2].GetComponent<StoreManager>().storeCount=PlayerPrefs.GetInt("bankStoreCount",1);
            if(isFinish)
                PlayerPrefs.SetInt("bankStoreCount",stores[2].GetComponent<StoreManager>().storeCount);
        }
        if(isHotel==1)
        {
            stores[3].SetActive(true);
            storeBuyArea[3].GetComponent<Button>().enabled=false;
            storeBuyArea[3].GetComponentInChildren<Text>().text="Purchased";
            if(isStart)
                stores[3].GetComponent<StoreManager>().storeCount=PlayerPrefs.GetInt("hotelStoreCount",1);
            if(isFinish)
                PlayerPrefs.SetInt("hotelStoreCount",stores[3].GetComponent<StoreManager>().storeCount);
        }
        if(isCoffee==1)
        {
            stores[4].SetActive(true);
            storeBuyArea[4].GetComponent<Button>().enabled=false;
            storeBuyArea[4].GetComponentInChildren<Text>().text="Purchased";
            if(isStart)
                stores[4].GetComponent<StoreManager>().storeCount=PlayerPrefs.GetInt("coffeeStoreCount",1);
            if(isFinish)
                PlayerPrefs.SetInt("coffeeStoreCount",stores[4].GetComponent<StoreManager>().storeCount);
        }
        if(isStart)
            stores[5].GetComponent<StoreManager>().storeCount=PlayerPrefs.GetInt("bookStoreCount",1);
        if(isFinish)
            PlayerPrefs.SetInt("bookStoreCount",stores[5].GetComponent<StoreManager>().storeCount);
    }
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        PlayerPrefs.SetFloat("balance",currentBalance);
        Debug.Log("Balance Saved: "+currentBalance.ToString());
        StoresControl(false,true);
    }
}
