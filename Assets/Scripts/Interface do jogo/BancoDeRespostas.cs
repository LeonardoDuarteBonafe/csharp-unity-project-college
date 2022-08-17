using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoDeRespostas : MonoBehaviour {

    string[] respostasCartas = new string[]
    {
            "Resposta carta 1",
            "Resposta carta 2",
            "Resposta carta 3",
            "Resposta carta 4",
            "Resposta carta 5",
            "Resposta carta 6",
            "Resposta carta 7",
            "Resposta carta 8",
            "Resposta carta 9",
            "Resposta carta 10",
            "Resposta carta 11",
            "Resposta carta 12",
            "Resposta carta 13",
            "Resposta carta 14",
            "Resposta carta 15",
            "Resposta carta 16",
            "Resposta carta 17",
            "Resposta carta 18",
            "Resposta carta 19",
            "Resposta carta 20"
    };

    public string pegarRespostaDoBanco(int cardIndex)
    {
        return respostasCartas[cardIndex];
    }

    public void setRespostasDoBanco(List<string> respostas)
    {
        int count = 0;
        foreach (string i in respostas)
        {
            count++;
        }
        respostasCartas = new string[]
        {
            respostas[0],
            respostas[1],
            respostas[2],
            respostas[3],
            respostas[4],
            respostas[5],
            respostas[6],
            respostas[7],
            respostas[8],
            respostas[9],
            respostas[10],
            respostas[11],
            respostas[12],
            respostas[13],
            respostas[14],
            respostas[15],
            respostas[16],
            respostas[17],
            respostas[18],
            respostas[19]
        };
    }
}
