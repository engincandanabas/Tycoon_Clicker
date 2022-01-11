using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float currentBalance=0;
    [SerializeField] private Text currentBalanceText;
    [SerializeField] public GameObject[] stores;
    public static GameManager instance;
    void Awake()
    {
        if(instance==null)
            instance=this;
    }
    void Start()
    {
        currentBalanceText.text=currentBalance.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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
                stores[1].SetActive(true);
                break;
            case "Shop":
                stores[2].SetActive(true);
                break;
            case "Bank":
                stores[3].SetActive(true);
                break;
            case "Hotel":
                stores[4].SetActive(true);
                break;
            case "Coffee":
                stores[5].SetActive(true);
                break;
        }
    }
}
