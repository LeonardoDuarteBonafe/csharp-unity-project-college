using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogarServer : MonoBehaviour {

    private string inputServername;
    public string userName;
    public InputField inputServer;

    public string[] dadosSalvos;
    private string restantes;
    private string retiradas;
    private string ganha;
    private string perdida;
    private int[] carta = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
    public GameObject servidorInvalidoObject;

    //string ConnectURL = "http://localhost/cool_YT_RPG/ConnectServer.php";
    //string CarregarOuCriarURL = "http://localhost/cool_YT_RPG/CarregarJogoOuCriarJogoNovo.php";
    //string ConnectURL = "https://gameengenhariadesoftware.000webhostapp.com/ConnectServer.php";
    //string CarregarOuCriarURL = "https://gameengenhariadesoftware.000webhostapp.com/CarregarJogoOuCriarJogoNovo.php";
    string ConnectURL = MudarCena.siteName+"ConnectServer.php";
    string CarregarOuCriarURL = MudarCena.siteName + "CarregarJogoOuCriarJogoNovo.php";

    private void Start()
    {
        servidorInvalidoObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        inputServername = inputServer.text;
    }

    public void ConfirmarConnectServer()
    {
        if (inputServername != "")
            {
                StartCoroutine(ConnectingToServer(inputServername));
            }
    }

    IEnumerator ConnectingToServer(string servername)
    {
        WWWForm form = new WWWForm();
        form.AddField("servernamePost", servername);

        WWW www = new WWW(ConnectURL, form);
        yield return www;
        if (www.text.Contains("Success"))
        {
            MudarCena.serverName = servername;
            StartCoroutine(CarregarJogoOuCriarNovo(userName));
        }
        else
        {
            servidorInvalidoObject.SetActive(true);
        }
    }

    IEnumerator CarregarJogoOuCriarNovo(string userName)
    {
        WWWForm form = new WWWForm();
        userName = MudarCena.userName;
        form.AddField("usernamePost", userName);
        form.AddField("servernamePost", MudarCena.serverName);
        WWW www = new WWW(CarregarOuCriarURL, form);
        yield return www;
        if (www.text.Contains("Existente"))
        {

            string dadosSalvosString = www.text.Substring(www.text.IndexOf("-")+1);

            if (dadosSalvosString != "")
            {
                int count = 0;
                dadosSalvos = dadosSalvosString.Split('|');
                foreach(string i in dadosSalvos)
                {
                    if (i.Contains("restantes"))
                    {
                        restantes = i.Substring(i.IndexOf(":") + 1);
                    }
                    else
                    {
                        if (i.Contains("retiradas"))
                        {
                            retiradas = i.Substring(i.IndexOf(":") + 1);
                        }
                        else
                        {
                            if (i.Contains("ganha"))
                            {
                                ganha = i.Substring(i.IndexOf(":") + 1);
                            }
                            else
                            {
                                if (i.Contains("perdida"))
                                {
                                    perdida = i.Substring(i.IndexOf(":") + 1);
                                }
                                else
                                {
                                    if (i.Contains("carta"))
                                    {
                                        string aux;
                                        if (i.Contains(";"))
                                        {
                                            aux = i.Remove(i.IndexOf(";"));
                                        }
                                        else
                                        {
                                            aux = i;
                                        }
                                        carta[count++] = int.Parse(aux.Substring(aux.IndexOf(":") + 1));
                                    }
                                }
                            }
                        }
                    }
                }
                MudarCena.cartasRestantes = restantes;
                MudarCena.cartasRetiradas = retiradas;
                MudarCena.pontuacaoGanha = ganha;
                MudarCena.pontuacaoPerdida = perdida;
                MudarCena.cartas = carta;

                SceneManager.LoadSceneAsync(3);
            }

        }
        else
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
