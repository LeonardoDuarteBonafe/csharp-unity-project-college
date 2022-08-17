using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bancoDeDicas : MonoBehaviour {

    public string[] dicasCartasRetorno;
    string[][] dicasCartas = new string[][]
    {
        new string[] {
            "Essa e a 1 carta, dica: 1",
            "Essa e a 1 carta, dica: 2",
            "Essa e a 1 carta, dica: 3",
            "Essa e a 1 carta, dica: 4",
            "Essa e a 1 carta, dica: 5"},
        new string[] {
            "Essa e a 2 carta, dica: 1",
            "Essa e a 2 carta, dica: 2",
            "Essa e a 2 carta, dica: 3",
            "Essa e a 2 carta, dica: 4",
            "Essa e a 2 carta, dica: 5"},
        new string[] {
            "Essa e a 3 carta, dica: 1",
            "Essa e a 3 carta, dica: 2",
            "Essa e a 3 carta, dica: 3",
            "Essa e a 3 carta, dica: 4",
            "Essa e a 3 carta, dica: 5"},
        new string[] {
            "Essa e a 4 carta, dica: 1",
            "Essa e a 4 carta, dica: 2",
            "Essa e a 4 carta, dica: 3",
            "Essa e a 4 carta, dica: 4",
            "Essa e a 4 carta, dica: 5"},
        new string[] {
            "Essa e a 5 carta, dica: 1",
            "Essa e a 5 carta, dica: 2",
            "Essa e a 5 carta, dica: 3",
            "Essa e a 5 carta, dica: 4",
            "Essa e a 5 carta, dica: 5" },
        new string[] {
            "Essa e a 6 carta, dica: 1",
            "Essa e a 6 carta, dica: 2",
            "Essa e a 6 carta, dica: 3",
            "Essa e a 6 carta, dica: 4",
            "Essa e a 6 carta, dica: 5" },
        new string[] {
            "Essa e a 7 carta, dica: 1",
            "Essa e a 7 carta, dica: 2" ,
            "Essa e a 7 carta, dica: 3" ,
            "Essa e a 7 carta, dica: 4" ,
            "Essa e a 7 carta, dica: 5" },
        new string[]{
            "Essa e a 8 carta, dica: 1" ,
            "Essa e a 8 carta, dica: 2" ,
            "Essa e a 8 carta, dica: 3" ,
            "Essa e a 8 carta, dica: 4" ,
            "Essa e a 8 carta, dica: 5" },
        new string[]{
            "Essa e a 9 carta, dica: 1" ,
            "Essa e a 9 carta, dica: 2" ,
            "Essa e a 9 carta, dica: 3" ,
            "Essa e a 9 carta, dica: 4" ,
            "Essa e a 9 carta, dica: 5" },
        new string[]{
            "Essa e a 10 carta, dica: 1" ,
            "Essa e a 10 carta, dica: 2" ,
            "Essa e a 10 carta, dica: 3" ,
            "Essa e a 10 carta, dica: 4" ,
            "Essa e a 10 carta, dica: 5" },
        new string[]{
            "Essa e a 11 carta, dica: 1" ,
            "Essa e a 11 carta, dica: 2" ,
            "Essa e a 11 carta, dica: 3" ,
            "Essa e a 11 carta, dica: 4" ,
            "Essa e a 11 carta, dica: 5" },
        new string[]{
            "Essa e a 12 carta, dica: 1" ,
            "Essa e a 12 carta, dica: 2" ,
            "Essa e a 12 carta, dica: 3" ,
            "Essa e a 12 carta, dica: 4" ,
            "Essa e a 12 carta, dica: 5" },
        new string[]{
            "Essa e a 13 carta, dica: 1" ,
            "Essa e a 13 carta, dica: 2" ,
            "Essa e a 13 carta, dica: 3" ,
            "Essa e a 13 carta, dica: 4" ,
            "Essa e a 13 carta, dica: 5" },
        new string[]{
            "Essa e a 14 carta, dica: 1" ,
            "Essa e a 14 carta, dica: 2" ,
            "Essa e a 14 carta, dica: 3" ,
            "Essa e a 14 carta, dica: 4" ,
            "Essa e a 14 carta, dica: 5" },
        new string[]{
            "Essa e a 15 carta, dica: 1" ,
            "Essa e a 15 carta, dica: 2" ,
            "Essa e a 15 carta, dica: 3" ,
            "Essa e a 15 carta, dica: 4" ,
            "Essa e a 15 carta, dica: 5" },
        new string[]{
            "Essa e a 16 carta, dica: 1" ,
            "Essa e a 16 carta, dica: 2" ,
            "Essa e a 16 carta, dica: 3" ,
            "Essa e a 16 carta, dica: 4" ,
            "Essa e a 16 carta, dica: 5" },
        new string[]{
            "Essa e a 17 carta, dica: 1" ,
            "Essa e a 17 carta, dica: 2" ,
            "Essa e a 17 carta, dica: 3" ,
            "Essa e a 17 carta, dica: 4" ,
            "Essa e a 17 carta, dica: 5" },
        new string[]{
            "Essa e a 18 carta, dica: 1" ,
            "Essa e a 18 carta, dica: 2" ,
            "Essa e a 18 carta, dica: 3" ,
            "Essa e a 18 carta, dica: 4" ,
            "Essa e a 18 carta, dica: 5" },
        new string[]{
            "Essa e a 19 carta, dica: 1" ,
            "Essa e a 19 carta, dica: 2" ,
            "Essa e a 19 carta, dica: 3" ,
            "Essa e a 19 carta, dica: 4" ,
            "Essa e a 19 carta, dica: 5" },
        new string[]{
            "Essa e a 20 carta, dica: 1" ,
            "Essa e a 20 carta, dica: 2" ,
            "Essa e a 20 carta, dica: 3" ,
            "Essa e a 20 carta, dica: 4" ,
            "Essa e a 20 carta, dica: 5" }


    };

    public string[] pegarDicasDoBanco(int cardIndex)
    {
        dicasCartasRetorno = new string[]
        {
            dicasCartas[cardIndex][0],
            dicasCartas[cardIndex][1],
            dicasCartas[cardIndex][2],
            dicasCartas[cardIndex][3],
            dicasCartas[cardIndex][4]
        };
        return dicasCartasRetorno;
    }

    public void setDicasDoBanco(List<string> dicas)
    {
        int count = 0;
        foreach(string i in dicas)
        {
            count++;
        }
        dicasCartas = new string[][]
        {
            new string[] 
            {
                dicas[0], dicas[1], dicas[2], dicas[3], dicas[4]
            },
            new string[]
            {
                dicas[5], dicas[6], dicas[7], dicas[8], dicas[9]
            },
            new string[]
            {
                dicas[10], dicas[11], dicas[12], dicas[13], dicas[14]
            },
            new string[]
            {
                dicas[15], dicas[16], dicas[17], dicas[18], dicas[19]
            },
            new string[]
            {
                dicas[20], dicas[21], dicas[22], dicas[23], dicas[24]
            },
            new string[]
            {
                dicas[25], dicas[26], dicas[27], dicas[28], dicas[29]
            },
            new string[]
            {
                dicas[30], dicas[31], dicas[32], dicas[33], dicas[34]
            },
            new string[]
            {
                dicas[35], dicas[36], dicas[37], dicas[38], dicas[39]
            },
            new string[]
            {
                dicas[40], dicas[41], dicas[42], dicas[43], dicas[44]
            },
            new string[]
            {
                dicas[45], dicas[46], dicas[47], dicas[48], dicas[49]
            },
            new string[]
            {
                dicas[50], dicas[51], dicas[52], dicas[53], dicas[54]
            },
            new string[]
            {
                dicas[55], dicas[56], dicas[57], dicas[58], dicas[59]
            },
            new string[]
            {
                dicas[60], dicas[61], dicas[62], dicas[63], dicas[64]
            },
            new string[]
            {
                dicas[65], dicas[66], dicas[67], dicas[68], dicas[69]
            },
            new string[]
            {
                dicas[70], dicas[71], dicas[72], dicas[73], dicas[74]
            },
            new string[]
            {
                dicas[75], dicas[76], dicas[77], dicas[78], dicas[79]
            },
            new string[]
            {
                dicas[80], dicas[81], dicas[82], dicas[83], dicas[84]
            },
            new string[]
            {
                dicas[85], dicas[86], dicas[87], dicas[88], dicas[89]
            },
            new string[]
            {
                dicas[90], dicas[91], dicas[92], dicas[93], dicas[94]
            },
            new string[]
            {
                dicas[95], dicas[96], dicas[97], dicas[98], dicas[99]
            }
        };
    }
}
