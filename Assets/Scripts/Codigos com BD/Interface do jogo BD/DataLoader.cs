using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {

    public string[] dicas;
    private List<string> dicas_info = new List<string>();
    private List<string> resposta_info = new List<string>();
    public bancoDeDicas bancoDeDicas;
    public BancoDeRespostas bancoDeRespostas;

    public MudarCena mudarCena;

    string user = MudarCena.serverName;

    //string ConnectURL = "http://localhost/cool_YT_RPG/DicasLoader.php";
    //string ConnectURL = "https://gameengenhariadesoftware.000webhostapp.com/DicasLoader.php";
    string ConnectURL = MudarCena.siteName + "DicasLoader.php";

    private void Update()
    {
        string user = MudarCena.serverName;
    }

    // Use this for initialization
    IEnumerator Start()
    {
        
        WWWForm form = new WWWForm();
        form.AddField("user", user);

        WWW www = new WWW(ConnectURL, form);
        yield return www;
        string dicasDataString = www.text;
        if (dicasDataString != "")
        {
            dicas = dicasDataString.Split(';');
            foreach (string i in dicas)
            {
                string[] aux = i.Split('|');
                foreach (string j in aux)
                {
                    if (!j.Contains("index"))
                    {
                        if (j.Contains("Resposta"))
                        {
                            resposta_info.Add(j.Substring(j.IndexOf(":") + 1));
                        }
                        else
                        {
                            if (j.Contains(":"))
                            {
                                dicas_info.Add(j.Substring(j.IndexOf(":") + 1));
                            }
                        }
                    }
                }
            }
            int countK = 1;
            foreach (string k in resposta_info)
            {
                countK++;
            }
            bancoDeDicas.setDicasDoBanco(dicas_info);
            bancoDeRespostas.setRespostasDoBanco(resposta_info);
        }
        
}
    string[] GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        string[] aux = value.Split('|');
        for(int i = 0; i<data.Length; i++)
        {
            if (value.Contains("|"))
            {
                //value = value.Remove(value.IndexOf("|"));
            }
        }
        return aux;
    }
    
}