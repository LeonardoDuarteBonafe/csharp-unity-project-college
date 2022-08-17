using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMenu : MonoBehaviour {

    public GameObject botao1;
    public GameObject botao2;
    public GameObject botao3;
    public GameObject botao4;
    public GameObject botao5;
    private string texto;
    public Text[] textos;
    public Button[] botoes;
    public int clicados;

    private List<int> numerosAleatoriosLista = new List<int>();
    private int[] numerosAleatoriosVetor = new int[5];

    public bancoDeDicas dicasCartas;
    private string[] dicasCartasString;

    // Use this for initialization
    void Start () {
        botao1.SetActive(false);
        botao2.SetActive(false);
        botao3.SetActive(false);
        botao4.SetActive(false);
        botao5.SetActive(false);
        for(int i=0; i < botoes.Length; i++)
        {
            botoes[i].interactable = true;
        }
    }

    public void pegarDicasDoBanco(int cardIndex)
    {
        bool numeroExiste;
        numerosAleatoriosLista.Clear();
        for (int i = 0; i < 5; i++)
        {
            numeroExiste = false;
            int number = Random.Range(0, 5);
            foreach(int inteiro in numerosAleatoriosLista)
            {
                if(inteiro == number)
                {
                    numeroExiste = true;
                    break;
                }
            }
            if (numeroExiste)
            {
                i--;
            }
            else
            {
                numerosAleatoriosLista.Add(number);
                numerosAleatoriosVetor[i] = number;
            }
        }
        dicasCartasString = dicasCartas.pegarDicasDoBanco(cardIndex);
    }

    public void displayBotoes()
    {
        StartCoroutine(displayingBotoes());
    }

    IEnumerator displayingBotoes()
    {
        texto = "";
        clicados = 0;
        yield return new WaitForSeconds(0.15f);
        textos[0].text = "Engenharia de Software";
        yield return new WaitForSeconds(0.15f);
        botao1.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        botao2.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        botao3.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        botao4.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        botao5.SetActive(true);
        yield return new WaitForSeconds(0.25f);
    }

    public void desligarBotoes()
    {
        botao1.SetActive(false);
        botao2.SetActive(false);
        botao3.SetActive(false);
        botao4.SetActive(false);
        botao5.SetActive(false);
        for(int i = 0; i< textos.Length; i++)
        {
            textos[i].text = "";
        }
    }

    public void botao1ShowText()
    {
        textos[1].text = dicasCartasString[numerosAleatoriosVetor[0]];
        botoes[0].interactable = false;
        clicados++;
    }
    public void botao2ShowText()
    {
        textos[2].text = dicasCartasString[numerosAleatoriosVetor[1]];
        botoes[1].interactable = false;
        clicados++;
    }
    public void botao3ShowText()
    {
        textos[3].text = dicasCartasString[numerosAleatoriosVetor[2]];
        botoes[2].interactable = false;
        clicados++;
    }
    public void botao4ShowText()
    {
        textos[4].text = dicasCartasString[numerosAleatoriosVetor[3]];
        botoes[3].interactable = false;
        clicados++;
    }
    public void botao5ShowText()
    {
        textos[5].text = dicasCartasString[numerosAleatoriosVetor[4]];
        botoes[4].interactable = false;
        clicados++;
    }

    public int numeroCliquesBotoes()
    {
        return clicados;
    }
}
