using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountServerEditar : MonoBehaviour
{
    //string CountServerEditarURL = "http://localhost/cool_YT_RPG/CountServerEditar.php";
    //string CartaDataLoaderURL = "http://localhost/cool_YT_RPG/CartaDataLoader.php";
    //string AtualizarCartaInformacoesURL = "http://localhost/cool_YT_RPG/AtualizarCartaInformacoes.php";
    //string CountServerEditarURL = "https://gameengenhariadesoftware.000webhostapp.com/CountServerEditar.php";
    //string CartaDataLoaderURL = "https://gameengenhariadesoftware.000webhostapp.com/CartaDataLoader.php";
    //string AtualizarCartaInformacoesURL = "https://gameengenhariadesoftware.000webhostapp.com/AtualizarCartaInformacoes.php";
    string CountServerEditarURL = MudarCena.siteName + "CountServerEditar.php";
    string CartaDataLoaderURL = MudarCena.siteName + "CartaDataLoader.php";
    string AtualizarCartaInformacoesURL = MudarCena.siteName + "AtualizarCartaInformacoes.php";

    public Dropdown dropdown;
    public Dropdown dropdownIndiceEditar;
    List<string> names = new List<string>();
    string[] listaServer;
    public GameObject gerenciarServerMenuObject;
    public GameObject terminarEditarServerObject;
    private int indexEditarServer = 0;
    private List<string> indiceCartaList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
    private int indiceCartaInt;
    private List<string> cartaDataLoaderList = new List<string>();

    public InputField dica1;
    public InputField dica2;
    public InputField dica3;
    public InputField dica4;
    public InputField dica5;
    public InputField resposta;

    public ControleVisual controleVisual;

    public GameObject cartaAtualizadaObject;

    public Text tituloCarta;

    private void Start()
    {
        dropdownIndiceEditar.AddOptions(indiceCartaList);
        indiceCartaInt = 1;
        tituloCarta.text = "Editando servidor:";
        cartaDataLoaderList.Clear();
        names.Clear();
        indexEditarServer = 0;
        cartaAtualizadaObject.SetActive(false);
    }

    public void CountServerEditarFunction()
    {
        StartCoroutine(CountServerEditarEnumerator());
    }

    IEnumerator CountServerEditarEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", MudarCena.userName);
        WWW www = new WWW(CountServerEditarURL, form);
        yield return www;
        if (www.text.Contains("sucesso"))
        {
            string serverEditarString = www.text.Substring(www.text.IndexOf("-") + 1);
            listaServer = serverEditarString.Split(';');
            foreach (string i in listaServer)
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
        indexEditarServer = index;
    }

    public void EditarServidor()
    {
        if (indexEditarServer != 0)
        {
            MudarCena.serverName = names[indexEditarServer];
            CarregarCarta(indiceCartaInt);
            controleVisual.EditarServer();
        }
    }
    
    public void Dropdown_Indice(int indice)
    {
        indiceCartaInt = indice+1;
        cartaDataLoaderList.Clear();
        CarregarCarta(indiceCartaInt);
    }

    public void CarregarCarta(int indice)
    {
        StartCoroutine(CarregarCartaEnumerator(indice));
    }

    IEnumerator CarregarCartaEnumerator(int indice)
    {
        tituloCarta.text = "Editando servidor: " + MudarCena.serverName;
        cartaAtualizadaObject.SetActive(false);
        WWWForm form = new WWWForm();
        form.AddField("user", MudarCena.userName);
        form.AddField("servernamePost", MudarCena.serverName);
        form.AddField("cartaid", indice);
        WWW www = new WWW(CartaDataLoaderURL, form);
        yield return www;
        string[] CartaDataLoaderString = www.text.Split('|');
        foreach(string i in CartaDataLoaderString)
        {
           
            if (i.Contains(";"))
            {
                string aux = (i.Remove(i.IndexOf(";")));
                cartaDataLoaderList.Add(aux.Substring(aux.IndexOf(":") + 1));
            }
            else
            {
                cartaDataLoaderList.Add(i.Substring(i.IndexOf(":") + 1));
            }
        }
        dica1.text = cartaDataLoaderList[0];
        dica2.text = cartaDataLoaderList[1];
        dica3.text = cartaDataLoaderList[2];
        dica4.text = cartaDataLoaderList[3];
        dica5.text = cartaDataLoaderList[4];
        resposta.text = cartaDataLoaderList[5];
    }

    public void ConfirmarEdicoes()
    {
        StartCoroutine(ConfirmarEdicoesCoroutine());
    }

    IEnumerator ConfirmarEdicoesCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("servernamePost", MudarCena.serverName);
        form.AddField("cartaid", indiceCartaInt);
        form.AddField("dica1", dica1.text);
        form.AddField("dica2", dica2.text);
        form.AddField("dica3", dica3.text);
        form.AddField("dica4", dica4.text);
        form.AddField("dica5", dica5.text);
        form.AddField("resposta", resposta.text);
        WWW www = new WWW(AtualizarCartaInformacoesURL, form);
        yield return www;
        if (www.text.Contains("sucesso"))
        {
            cartaAtualizadaObject.SetActive(true);
        }
        else
        {
            cartaAtualizadaObject.SetActive(false);
        }
    }
}
