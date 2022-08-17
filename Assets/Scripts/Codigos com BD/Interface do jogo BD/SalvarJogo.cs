using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvarJogo : MonoBehaviour
{
    //string SalvarJogoURL = "http://localhost/cool_YT_RPG/SalvarJogo.php";
    //string SalvarJogoURL = "https://gameengenhariadesoftware.000webhostapp.com/SalvarJogo.php";
    string SalvarJogoURL = MudarCena.siteName+"SalvarJogo.php";

    string user;
    string cartas_restantes;
    string cartas_retiradas;
    string pontuacao_ganha;
    string pontuacao_perdida;

    public void SalvarJogoFunction()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("cartasRestantes", cartas_restantes);
        form.AddField("cartasRetiradas", cartas_retiradas);
        form.AddField("pontuacaoGanha", pontuacao_ganha);
        form.AddField("pontuacaoPerdida", pontuacao_perdida);

        WWW www = new WWW(SalvarJogoURL, form);
    }
    
}
