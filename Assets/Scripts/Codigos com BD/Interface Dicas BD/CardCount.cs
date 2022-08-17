using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCount : MonoBehaviour {
    
    //string CardCountUrl = "http://localhost/cool_YT_RPG/CardCount.php";
    //string ReturnCardCountUrl = "http://localhost/cool_YT_RPG/ReturnCardCount.php";
    //string CardCountUrl = "https://gameengenhariadesoftware.000webhostapp.com/CardCount.php";
    //string ReturnCardCountUrl = "https://gameengenhariadesoftware.000webhostapp.com/ReturnCardCount.php";
    string CardCountUrl = MudarCena.siteName+"CardCount.php";
    string ReturnCardCountUrl = MudarCena.siteName + "ReturnCardCount.php";

    private void Update()
    {
    }

    int userCardCounted = 0;

    public void CardCountFunction(string serverName)
    {
        WWWForm form = new WWWForm();
        form.AddField("server", serverName);
        WWW www = new WWW(CardCountUrl, form);
    }
    
    public void ReturnCardCount(string serverName)
    {
        StartCoroutine(CardCountEnumerator(serverName));
    }

    IEnumerator CardCountEnumerator(string serverName)
    {
        WWWForm form = new WWWForm();
        form.AddField("server", serverName);
        WWW www = new WWW(ReturnCardCountUrl, form);

        yield return www;
        string cardCountString = www.text;
        Debug.Log("Texto: " +www.text);
        if (cardCountString.Contains("Count:"))
        {
            userCardCounted = int.Parse((cardCountString.Substring(cardCountString.IndexOf(":") + 1)));
        }
    }

    public int ReturnCardCounted()
    {
        return userCardCounted;
    }
}
