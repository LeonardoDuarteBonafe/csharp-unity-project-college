using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;
using System.Globalization;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DebugChangeCard : MonoBehaviour
{
    static DebugChangeCard instance;

    //string SalvarJogoURL = "http://localhost/cool_YT_RPG/SalvarJogo.php";
    //string SalvarJogoURL = "https://gameengenhariadesoftware.000webhostapp.com/SalvarJogo.php";
    string SalvarJogoURL = MudarCena.siteName+"SalvarJogo.php";

    CardFlipper flipper;
    CardModel cardModel;
    int cardIndex = 0;

    public CardStack player;
    public CardStack cartasRemovidas;
    public CardStack baralhoEsquerda;
    public CardStack baralhoDireita;

    public Embaralhar varEmbaralhar;

    public int pontuacaoGanha = 0;
    public int pontuacaoPerdida = 0;

    public Text textoCartasRetiradas;
    private string stringCartasRetiradas;
    public Text textoCartasRestantes;
    private string stringCartasRestantes;
    public Text textoPontuacaoAtual;
    private string stringPontuacaoAtual;
    public Text textoPontuacaoGanha;
    private string stringPontuacaoGanha;
    public Text textoPontuacaoPerdida;
    private string stringPontuacaoPerdida;

    public Button retirarCartasBotao;
    public Button retirarCartasComCartaBotao;
    public Button embaralharCartasBotao;
    public Text embaralharCartasTexto;
    private int embaralharRestantes = 0;
    public Button novoJogoBotao;
    public Button salvarJogoBotao;
    public GameObject novoJogoObject;
    public GameObject salvarJogoObject;
    
    int pontuacaoAtualGanha;

    public GameObject card;

    private int controleLado = 1;
    private int salvarIndexUltimaCarta;
    private bool ultimaCarta = false;
    private int ultimaCartaInt = 0;

    private bool InicioPrograma = false;
    private bool InicioProgramaAtrasar = false;

    public bool efeitoEmbaralharTerminado = false;

    public GameStatus gameStatus;

    public DebugTabuleiro debugTabuleiro;
    public GameObject jogadorTabuleiro;

    public GameObject totalCartasUtilizadasObject;

    int[] cartas = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] cardsForSave = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int contadorForSave = 0;

    void Awake()
    {
        cardModel = card.GetComponent<CardModel>();
        flipper = card.GetComponent<CardFlipper>();
        stringCartasRetiradas = textoCartasRetiradas.text;
        stringCartasRestantes = textoCartasRestantes.text;
        stringPontuacaoGanha = textoPontuacaoGanha.text;
        stringPontuacaoPerdida = textoPontuacaoPerdida.text;
        stringPontuacaoAtual = textoPontuacaoAtual.text;
    }

    private void Start()
    {
        totalCartasUtilizadasObject.SetActive(false);
        CarregandoJogo();
        ComecandoPrincipal();
    }

    private void ComecandoPrincipal()
    {
        embaralharRestantes = 3;
        ultimaCarta = false;
        ultimaCartaInt = 0;

        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        pontuacaoGanha = int.Parse(MudarCena.pontuacaoGanha);
        pontuacaoPerdida = int.Parse(MudarCena.pontuacaoPerdida);
        textoPontuacaoGanha.text = stringPontuacaoGanha + " " + pontuacaoGanha;
        textoPontuacaoPerdida.text = stringPontuacaoPerdida + " " + pontuacaoPerdida;
        int contadorCartas = 0;
        foreach(int i in cartas)
        {
            if(i == 1)
            {
                player.cards.Remove(contadorCartas);
                cartasRemovidas.cards.Add(contadorCartas);
            }
            contadorCartas++;
        }
        textoCartasRetiradas.text = stringCartasRetiradas + " " + MudarCena.cartasRetiradas;
        textoCartasRestantes.text = stringCartasRestantes + " " + MudarCena.cartasRestantes;

        for (int i = 0; i < 20; i++)
        {
            cardsForSave[i] = 0;
        }
        contadorForSave = 0;
        
        embaralharCartasTexto.text = "Embaralhar (" + embaralharRestantes + ")";
        if (!player.HasCards)
        {
            salvarJogoObject.SetActive(true);
            novoJogoObject.SetActive(true);
            totalCartasUtilizadasObject.SetActive(true);
        }
        InicioPrograma = true;
        InicioProgramaAtrasar = true;
        embaralharCartasBotao.interactable = false;
        retirarCartasBotao.interactable = false;
        retirarCartasComCartaBotao.interactable = false;
        novoJogoBotao.interactable = false;
        salvarJogoBotao.interactable = false;
        List<int> TNC = player.GetListaCartas();
       
        Invoke("FuncaoEmbaralhar", 0.7f);
    }

    public void retirarCartas()
    {
        salvarJogoObject.SetActive(false);
        novoJogoObject.SetActive(false);
        retirarCartasBotao.interactable = false;
        retirarCartasComCartaBotao.interactable = false;
        embaralharCartasBotao.interactable = false;
        novoJogoBotao.interactable = false;
        cardIndex = player.Pop();
        
        cartas[cardIndex] = 1;
        textoCartasRestantes.text = stringCartasRestantes + " " + player.CardCount;
        textoCartasRetiradas.text = stringCartasRetiradas + " " + cartasRemovidas.CardCount;
        textoPontuacaoGanha.text = stringPontuacaoGanha + " " + pontuacaoGanha;
        textoPontuacaoPerdida.text = stringPontuacaoPerdida + " " + pontuacaoPerdida;
        textoPontuacaoAtual.text = stringPontuacaoAtual + " 5";
       
        flipper.FlipCard(cardModel.cardBack, cardModel.faces[cardIndex], cardIndex);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("cartasJogador", player.CardCount);
        PlayerPrefs.SetInt("cartasRemovidas", cartasRemovidas.CardCount);
        PlayerPrefs.Save();
    }

    public void AddCartasRemovidas(int cardIndex)
    {
        cartasRemovidas.Push(cardIndex);
        textoCartasRetiradas.text = stringCartasRetiradas + " " + cartasRemovidas.CardCount;
        Invoke("AparecerTabuleiro", 1);
        gameStatus.cartasRemovidas = cartasRemovidas.CardCount;
        gameStatus.cartasJogador = player.CardCount;
        gameStatus.printarGameStatus();
    }

    private void AparecerTabuleiro()
    {
        if(player.CardCount > 0)
        {
            if(!jogadorTabuleiro.GetComponent<FollowThePath>().acabouJogo)
            {
                debugTabuleiro.TransicaoTabuleiro(true);
            }
            else
            {
                debugTabuleiro.TransicaoTabuleiro(false);
            }
            retirarCartasBotao.interactable = true;
            retirarCartasComCartaBotao.interactable = true;
            novoJogoBotao.interactable = true;
            salvarJogoBotao.interactable = true;
            if (embaralharRestantes > 0)
            {
                embaralharCartasBotao.interactable = true;
            }
        }
        else
        {
            novoJogoBotao.interactable= true;
            salvarJogoObject.SetActive(true);
            novoJogoObject.SetActive(true);
            totalCartasUtilizadasObject.SetActive(true);
        }
    }

    public void Delay()
    {
        DateTime end = DateTime.Now.AddSeconds(3);

        while (DateTime.Now <= end)
        {
            
        }
    }

    public void FuncaoEmbaralhar()
    {
        cardsForSave = player.cardsForSaveFunction();
        contadorForSave = 0;
        for(int i =0;i<player.CardCount;i++)
        {
        }
        retirarCartasBotao.interactable = false;
        retirarCartasComCartaBotao.interactable = false;
        embaralharCartasBotao.interactable = false;
        novoJogoBotao.interactable = false;
        salvarJogoBotao.interactable = false;
        if(player.HasCards)
        {
            if(player.CardCount == 1)
            {
                salvarIndexUltimaCarta = player.Pop();
                ultimaCarta = true;
            }
            if (controleLado % 2 == 1)
            {
                varEmbaralhar.MovimentoEmbaralhar(true);
            }
            else
            {
                varEmbaralhar.MovimentoEmbaralhar(false);
            }
            controleLado++;
        }
        else
        {
            varEmbaralhar.SoAcabar();
            controleLado = 0;
            StartCoroutine(Embaralhando(false));
        }
    }

    IEnumerator Embaralhando(bool embaralhar)
    {
        yield return new WaitForSeconds(0.05f);
        if (embaralhar)
        {
            FuncaoEmbaralhar();
        }
        else
        {
            FuncaoDesembaralhar();
        }
    }

    public void BaralhoEsquerdaDireitaEmbaralhar(bool ladoDireito)
    {
        int cardIndex = 0;
        if (ultimaCarta)
        {
            cardIndex = salvarIndexUltimaCarta;
            ultimaCarta = false;
        }
        else
        {
            cardIndex = player.Pop();
        }
        if (ladoDireito)
        {
            baralhoDireita.Push(cardIndex);
        }
        else
        {
            baralhoEsquerda.Push(cardIndex);
        }
        StartCoroutine(Embaralhando(true));
    }

    public void FuncaoDesembaralhar()
    {
        if (baralhoDireita.HasCards || baralhoEsquerda.HasCards)
        {
            ultimaCartaInt = baralhoDireita.CardCount + baralhoEsquerda.CardCount;
            if (baralhoDireita.CardCount+baralhoEsquerda.CardCount == 1)
            {
                if ((baralhoEsquerda.CardCount == 1))// && (controleLado % 2 == 1))
                {
                    salvarIndexUltimaCarta = baralhoEsquerda.Pop();
                }
                if ((baralhoDireita.CardCount == 1))// && (controleLado % 2 == 0))
                {
                    salvarIndexUltimaCarta = baralhoDireita.Pop();
                }
                ultimaCarta = true;
            }
            if (controleLado % 2 == 0)
            {
                varEmbaralhar.MovimentoDesembaralhar(false);
            }
            else
            {
                varEmbaralhar.MovimentoDesembaralhar(true);
            }
            controleLado++;
        }
        else
        {
            varEmbaralhar.SoAcabar();
            controleLado = 0;
            retirarCartasComCartaBotao.interactable = true;
            retirarCartasBotao.interactable = true;
            novoJogoBotao.interactable = true;
            salvarJogoBotao.interactable = true;
            if (InicioPrograma)
            {
                InicioPrograma = false;
            }
            else
            {
                embaralharRestantes--;
            }
            if (embaralharRestantes > 0)
            {
                embaralharCartasTexto.text = "Embaralhar (" + embaralharRestantes + ")";
                embaralharCartasBotao.interactable = true;
            }
            else
            {
                embaralharCartasTexto.text = "ACABOU!";
            }
        }
    }

    public void BaralhoEsquerdaDireitaDesembaralhar(bool ladoDireito)
    {
        int cardIndex = 0;
        if (ultimaCarta)
        {
            cardIndex = salvarIndexUltimaCarta;
            ultimaCarta = false;
        }
        else
        {
            if (ladoDireito)
            {
                cardIndex = baralhoDireita.Pop();
            }
            else
            {
                cardIndex = baralhoEsquerda.Pop();
            }
        }
        player.Push(cardIndex);
        StartCoroutine(Embaralhando(false));
    }

    public void textoPontuacaoAtualAtualizar(int pontuacao)
    {
        textoPontuacaoAtual.text = stringPontuacaoAtual + " " + (pontuacao - 5) * -1;
        pontuacaoAtualGanha = (pontuacao - 5) * -1;
    }

    public void textoPontuacaoGanhaAtualizar(int pontuacao)
    {
        pontuacaoGanha += (pontuacao-5)*-1;
        textoPontuacaoGanha.text = stringPontuacaoGanha + " " + pontuacaoGanha;
        gameStatus.pontuacaoGanhaTotal = pontuacaoGanha;
    }
    public void textoPontuacaoPerdidaAtualizar(int pontuacao)
    {
        pontuacaoPerdida += pontuacao;
        textoPontuacaoPerdida.text = stringPontuacaoPerdida + " " + pontuacaoPerdida;
    }

    public void NovoJogo()
    {
        for(int i = 0; i < cartas.Length; i++)
        {
            cartas[i] = 0;
        }
        MudarCena.pontuacaoGanha = "0";
        MudarCena.pontuacaoPerdida = "0";
        MudarCena.cartasRestantes = "20";
        MudarCena.cartasRetiradas = "0";
        MudarCena.cartas = cartas;
        SceneManager.LoadScene("InterfaceJogo");
        gameStatus.novoJogo = true;
    }

    public void SalvarJogoFunction()
    {
        StartCoroutine(SalvarJogoCoroutine());
    }

    IEnumerator SalvarJogoCoroutine()
    {
        string user = MudarCena.userName;
        string server = MudarCena.serverName;
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("server", server);
        form.AddField("cartasRestantes", player.CardCount);
        form.AddField("cartasRetiradas", cartasRemovidas.CardCount);
        form.AddField("pontuacaoGanha", pontuacaoGanha);
        form.AddField("pontuacaoPerdida", pontuacaoPerdida);
        form.AddField("carta1", cartas[0]);
        form.AddField("carta2", cartas[1]);
        form.AddField("carta3", cartas[2]);
        form.AddField("carta4", cartas[3]);
        form.AddField("carta5", cartas[4]);
        form.AddField("carta6", cartas[5]);
        form.AddField("carta7", cartas[6]);
        form.AddField("carta8", cartas[7]);
        form.AddField("carta9", cartas[8]);
        form.AddField("carta10", cartas[9]);
        form.AddField("carta11", cartas[10]);
        form.AddField("carta12", cartas[11]);
        form.AddField("carta13", cartas[12]);
        form.AddField("carta14", cartas[13]);
        form.AddField("carta15", cartas[14]);
        form.AddField("carta16", cartas[15]);
        form.AddField("carta17", cartas[16]);
        form.AddField("carta18", cartas[17]);
        form.AddField("carta19", cartas[18]);
        form.AddField("carta20", cartas[19]);

        WWW www = new WWW(SalvarJogoURL, form);
        yield return www;
    }

    public void CarregandoJogo()
    {
        if(MudarCena.cartasRestantes == "" || MudarCena.cartasRestantes == null)
        {
            MudarCena.cartasRestantes = "20";
        }
        if (MudarCena.cartasRetiradas == "" || MudarCena.cartasRetiradas == null)
        {
            MudarCena.cartasRetiradas = "0";
        }
        if (MudarCena.pontuacaoGanha == "" || MudarCena.pontuacaoGanha == null)
        {
            MudarCena.pontuacaoGanha = "0";
        }
        if (MudarCena.pontuacaoPerdida == "" || MudarCena.pontuacaoPerdida == null)
        {
            MudarCena.pontuacaoPerdida = "0";
        }
        cartas = MudarCena.cartas;
    }
}
