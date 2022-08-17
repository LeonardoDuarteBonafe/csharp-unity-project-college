using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountServerAtualizar : MonoBehaviour
{
    //string CountServerAtualizarURL = "http://localhost/cool_YT_RPG/CountServerAtualizar.php";
    //string CountServerAtualizarURL = "https://gameengenhariadesoftware.000webhostapp.com/CountServerAtualizar.php";
    string CountServerAtualizarURL = MudarCena.siteName + "CountServerAtualizar.php";

    public Dropdown dropdown;
    List<string> names = new List<string>();
    string[] listaServer;
    public GameObject gerenciarServerMenuObject;
    public GameObject terminarEditarServerObject;
    private int indexAtualizarServer = 0;

    public ControleVisual controleVisual;

    public SalvarDicas salvarDicasObject;

    private void Start()
    {
        names.Clear();
        indexAtualizarServer = 0;
    }

    public void CountServerAtualizarFunction()
    {
        StartCoroutine(CountServerAtualizarEnumerator());
    }

    IEnumerator CountServerAtualizarEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", MudarCena.userName);
        WWW www = new WWW(CountServerAtualizarURL, form);
        yield return www;
        if (www.text.Contains("sucesso"))
        {
            string serverAtualizarString = www.text.Substring(www.text.IndexOf("-") + 1);
            listaServer = serverAtualizarString.Split(';');
            foreach(string i in listaServer)
            {
                names.Add(i);
            }
            names.Remove("");
            names.Insert(0, "");
            DropwdownListFunction();
            gerenciarServerMenuObject.SetActive(false);
            terminarEditarServerObject.SetActive(true);
        }
    }

    public void DropwdownListFunction()
    {
        dropdown.AddOptions(names);
    }

    public void Dropdown_IndexChanged(int index)
    {
        indexAtualizarServer = index;
    }

    public void FinalizarServidor()
    {
        if(indexAtualizarServer != 0)
        {
            MudarCena.serverName = names[indexAtualizarServer];
            controleVisual.AtualizarServer();
        }
    }
}
