using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleVisual : MonoBehaviour {

    public GameObject menuCriarDicas;
    public GameObject menuServer;
    public GameObject menuGerenciarCartas;
    public GameObject menuNomeServer;
    public GameObject logarEditarServer;
    public GameObject gerenciarServer;
    public GameObject terminarEditarServer;
    public GameObject menuEditarCartas;
    public GameObject erroCriarServidorObject;

    public GameObject excluirServerTextObject;
    public Text excluirServerText;

    public InputField inputNomeServerCriar;
    public InputField inputNomeServerExcluir;
    public Text nomeServerTitulo;

    public MudarCena getUser;

    public CountServerExcluir serverExcluir;

    string user = "";
    //string CheckServerURL = "http://localhost/cool_YT_RPG/CheckServerExiste.php";
    //string DeletarServerURL = "http://localhost/cool_YT_RPG/DeletarServer.php";
    //string CheckServerURL = "https://gameengenhariadesoftware.000webhostapp.com/CheckServerExiste.php";
    //string DeletarServerURL = "https://gameengenhariadesoftware.000webhostapp.com/DeletarServer.php";
    string CheckServerURL = MudarCena.siteName+"CheckServerExiste.php";
    string DeletarServerURL = MudarCena.siteName + "DeletarServer.php";

    public CardCount cardCount;

    // Use this for initialization
    void Start () {

        menuCriarDicas.SetActive(false);
        menuNomeServer.SetActive(false);
        gerenciarServer.SetActive(false);
        terminarEditarServer.SetActive(false);
        menuEditarCartas.SetActive(false);
        excluirServerTextObject.SetActive(false);
        erroCriarServidorObject.SetActive(false);
        excluirServerText.text = "";
        MudarCena.pontuacaoGanha = "";
        MudarCena.pontuacaoPerdida = "";
        MudarCena.cartasRestantes = "";
        MudarCena.cartasRetiradas = "";
        for(int i = 0; i < 20; i++)
        {
            MudarCena.cartas[i] = 0;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CriarServerNome()
    {
        menuServer.SetActive(false);
        menuGerenciarCartas.SetActive(false);
        menuCriarDicas.SetActive(false);
        menuNomeServer.SetActive(true);
    }

    public void VoltarMenu() 
    {
        menuCriarDicas.SetActive(false);
        menuGerenciarCartas.SetActive(true);
        menuNomeServer.SetActive(false);
        menuServer.SetActive(true);
    }

    public void EditarServidor()
    {
        logarEditarServer.SetActive(false);
        gerenciarServer.SetActive(true);

    }

    public void CriarDicas()
    {
        if(inputNomeServerCriar.text != "")
        {
            StartCoroutine(CheckServerExiste(inputNomeServerCriar.text));
        }
    }

    IEnumerator CheckServerExiste(string serverName)
    {
        WWWForm form = new WWWForm();
        form.AddField("servernamePost", serverName);
        form.AddField("usernamePost", MudarCena.userName);
        WWW www = new WWW(CheckServerURL, form);
        yield return www;
        if (www.text.Contains("sucesso"))
        {
            MudarCena.serverName = serverName;
            nomeServerTitulo.text = serverName;
            CriandoDicas();
        }
        else
        {
            erroCriarServidorObject.SetActive(true);
        }
    }

    public void CriandoDicas()
    {
        excluirServerText.text = "";
        gerenciarServer.SetActive(false);
        menuServer.SetActive(false);
        menuGerenciarCartas.SetActive(false);
        menuNomeServer.SetActive(false);
        menuCriarDicas.SetActive(true);
    }

    public void ExcluirServidor()
    {
            StartCoroutine(DeletarServer());
    }

    IEnumerator DeletarServer()
    {
        WWWForm form = new WWWForm();
        form.AddField("servernamePost", MudarCena.serverName);
        form.AddField("usernamePost", MudarCena.userName);
        WWW www = new WWW(DeletarServerURL, form);
        yield return www;
        if (www.text.Contains("sucesso"))
        {
            excluirServerText.text = "Servidor excluído!";
            Color32 verdeAprovacao = new Color32(0x0D, 0x95, 0x13, 0xFF);
            excluirServerText.color = verdeAprovacao;
            excluirServerTextObject.SetActive(true);
        }
        else
        {
            excluirServerText.text = "Algo deu errado!";
            excluirServerText.color = Color.red;
            excluirServerTextObject.SetActive(true);
        }
    }
    
    public void AtualizarServer()
    {
        nomeServerTitulo.text = MudarCena.serverName;
        terminarEditarServer.SetActive(false);
        CriandoDicas();
    }
    
    public void EditarServer()
    {
        terminarEditarServer.SetActive(false);
        menuEditarCartas.SetActive(true);
    }
}
