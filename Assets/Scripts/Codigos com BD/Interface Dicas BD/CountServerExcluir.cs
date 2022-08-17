using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountServerExcluir : MonoBehaviour
{
    //string CountServerExcluirURL = "http://localhost/cool_YT_RPG/CountServerExcluir.php";
    //string CountServerExcluirURL = "https://gameengenhariadesoftware.000webhostapp.com/CountServerExcluir.php";
    string CountServerExcluirURL = MudarCena.siteName+"CountServerExcluir.php";

    public Dropdown dropdown;
    List<string> names = new List<string>();
    string[] listaServer;
    private int indexExcluirServer = 0;

    public ControleVisual controleVisual;

    private void Start()
    {
        names.Clear();
        indexExcluirServer = 0;
    }

    public void CountServerExcluirFunction()
    {
        StartCoroutine(CountServerExcluirEnumerator());
    }

    IEnumerator CountServerExcluirEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", MudarCena.userName);
        WWW www = new WWW(CountServerExcluirURL, form);
        yield return www;
        if (www.text.Contains("sucesso"))
        {
            string serverExcluirString = www.text.Substring(www.text.IndexOf("-") + 1);
            listaServer = serverExcluirString.Split(';');
            foreach (string i in listaServer)
            {
                names.Add(i);
            }
            names.Remove("");
            names.Insert(0, "");
            DropwdownListFunction();
        }
    }

    public void DropwdownListFunction()
    {
        dropdown.AddOptions(names);
    }

    public void Dropdown_IndexChanged(int index)
    {
        indexExcluirServer = index;
    }

    public void ExcluirServidor()
    {
        if (indexExcluirServer != 0)
        {
            MudarCena.serverName = names[indexExcluirServer];

            controleVisual.ExcluirServidor();
        }
    }
}
