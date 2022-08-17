using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    //public static string siteName = "http://localhost/Engenharia_de_software/";
    public static string siteName = "https://gameengenhariadesoftware.000webhostapp.com/";

    public static string userName;
    public static string serverName;
    public static string cartasRestantes;
    public static string cartasRetiradas;
    public static string pontuacaoGanha;
    public static string pontuacaoPerdida;
    public static string carta1;
    public static string carta2;
    public static string carta3;
    public static string carta4;
    public static string carta5;
    public static string carta6;
    public static string carta7;
    public static string carta8;
    public static string carta9;
    public static string carta10;
    public static string carta11;
    public static string carta12;
    public static string carta13;
    public static string carta14;
    public static string carta15;
    public static string carta16;
    public static string carta17;
    public static string carta18;
    public static string carta19;
    public static string carta20;
    public static int[] cartas = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public void changeToScene(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
    }

    public string ReturnUser()
    {
        return userName;
    }

    public string ReturnServer()
    {
        return serverName;
    }

    public string ReturnCartasRestantes()
    {
        return cartasRestantes;
    }

    public string ReturnCartasRetiradas()
    {
        return cartasRetiradas;
    }

    public string ReturnPontuacaoGanha()
    {
        return pontuacaoGanha;
    }

    public string ReturnPontuacaoPerdida()
    {
        return pontuacaoPerdida;
    }

    public int[] ReturnCartas()
    {
        return cartas;
    }
}
