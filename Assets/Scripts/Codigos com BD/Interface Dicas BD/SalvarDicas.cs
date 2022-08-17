using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalvarDicas : MonoBehaviour
{
    public Button confirmarDicas;
    public Text titulo;
    public InputField[] textos;
    public int i = 1;

    public string[] dicas;
    private List<string> dicas_info = new List<string>();

    //string SaveCardURL = "http://localhost/cool_YT_RPG/Connect_DB_Dicas.php";
    //string SaveCardURL = "https://gameengenhariadesoftware.000webhostapp.com/Connect_DB_Dicas.php";
    string SaveCardURL = MudarCena.siteName+"Connect_DB_Dicas.php";

    public bool isEmpty = false;

    public CardCount cardCount;

    public MudarCena getUser;

    private string user;
    private string serverName;

    public GameObject voltarMenu;

    private void Start()
    {
        voltarMenu.SetActive(false);
    }

    private void Update()
    {
        user = MudarCena.userName;
        serverName = MudarCena.serverName;
        cardCount.CardCountFunction(serverName);
        cardCount.ReturnCardCount(serverName);
        i = cardCount.ReturnCardCounted() + 1;
        if (i <= 20)
        {
            titulo.text = (i).ToString();
        }
        else
        {
            titulo.text = "20";
            voltarMenu.SetActive(true);
        }
    }

    public void SalvarCarta()
    {
        isEmpty = false;
        if (i <= 20)
        {
            for (int j = 0; j < textos.Length; j++)
            {
                if (textos[j].text == "")
                {
                    isEmpty = true;
                }
            }
            if (isEmpty)
            {
            }
            else
            {
                CreateCard(user, serverName, i, textos[0].text, textos[1].text, textos[2].text, textos[3].text, textos[4].text, textos[5].text);
                i++;
                
                if (i <= 20)
                {
                    titulo.text = (i).ToString();
                }
                else
                {
                    voltarMenu.SetActive(true);
                }
            }
        }
        else
        {
            voltarMenu.SetActive(true);
        }
        
    }

    public void CreateCard(string user, string serverName, int carta_id, string dica1, string dica2, string dica3, string dica4, string dica5, string resposta)
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("servername", serverName);
        form.AddField("carta_id", carta_id);
        form.AddField("dica1", dica1);
        form.AddField("dica2", dica2);
        form.AddField("dica3", dica3);
        form.AddField("dica4", dica4);
        form.AddField("dica5", dica5);
        form.AddField("resposta", resposta);

        WWW www = new WWW(SaveCardURL, form);
    }
}