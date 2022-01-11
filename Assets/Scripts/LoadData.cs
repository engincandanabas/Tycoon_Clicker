using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class LoadData : MonoBehaviour
{
    public TextAsset GameData;
    void Start()
    {
        Invoke("LoadGameData",.5f);
    }
    public void LoadGameData()
    {
        XmlDocument xmlDocument=new XmlDocument();
        xmlDocument.LoadXml(GameData.text);
        XmlNodeList storelist=xmlDocument.GetElementsByTagName("store");
        foreach(XmlNode storeInfo in storelist)
        {
            XmlNodeList storedNodes=storeInfo.ChildNodes;
            foreach(XmlNode storeNode in storedNodes)
            {
                Debug.Log(storeNode.Name+" "+storeNode.InnerText);
            }
        }
    }
}
