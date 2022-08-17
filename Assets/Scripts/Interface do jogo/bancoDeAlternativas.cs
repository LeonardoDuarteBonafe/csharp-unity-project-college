using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bancoDeAlternativas : MonoBehaviour {

    public string[] alternativasCartasRetorno;
    string[][] alternativasCartas = new string[][]
    {
        new string[] {
            "Essa e a 1 carta, alternativa: 1",
            "Essa e a 1 carta, alternativa: 2",
            "Essa e a 1 carta, alternativa: 3",
            "Essa e a 1 carta, alternativa: 4"},
        new string[] {
            "Essa e a 2 carta, alternativa: 1",
            "Essa e a 2 carta, alternativa: 2",
            "Essa e a 2 carta, alternativa: 3",
            "Essa e a 2 carta, alternativa: 4"},
        new string[] {
            "Essa e a 3 carta, alternativa: 1",
            "Essa e a 3 carta, alternativa: 2",
            "Essa e a 3 carta, alternativa: 3",
            "Essa e a 3 carta, alternativa: 4"},
        new string[] {
            "Essa e a 4 carta, alternativa: 1",
            "Essa e a 4 carta, alternativa: 2",
            "Essa e a 4 carta, alternativa: 3",
            "Essa e a 4 carta, alternativa: 4"},
        new string[] {
            "Essa e a 5 carta, alternativa: 1",
            "Essa e a 5 carta, alternativa: 2",
            "Essa e a 5 carta, alternativa: 3",
            "Essa e a 5 carta, alternativa: 4" },
        new string[] {
            "Essa e a 6 carta, alternativa: 1",
            "Essa e a 6 carta, alternativa: 2",
            "Essa e a 6 carta, alternativa: 3",
            "Essa e a 6 carta, alternativa: 4" },
        new string[] {
            "Essa e a 7 carta, alternativa: 1",
            "Essa e a 7 carta, alternativa: 2" ,
            "Essa e a 7 carta, alternativa: 3" ,
            "Essa e a 7 carta, alternativa: 4" },
        new string[]{
            "Essa e a 8 carta, alternativa: 1" ,
            "Essa e a 8 carta, alternativa: 2" ,
            "Essa e a 8 carta, alternativa: 3" ,
            "Essa e a 8 carta, alternativa: 4" },
        new string[]{
            "Essa e a 9 carta, alternativa: 1" ,
            "Essa e a 9 carta, alternativa: 2" ,
            "Essa e a 9 carta, alternativa: 3" ,
            "Essa e a 9 carta, alternativa: 4" },
        new string[]{
            "Essa e a 10 carta, alternativa: 1" ,
            "Essa e a 10 carta, alternativa: 2" ,
            "Essa e a 10 carta, alternativa: 3" ,
            "Essa e a 10 carta, alternativa: 4" },
        new string[]{
            "Essa e a 11 carta, alternativa: 1" ,
            "Essa e a 11 carta, alternativa: 2" ,
            "Essa e a 11 carta, alternativa: 3" ,
            "Essa e a 11 carta, alternativa: 4" },
        new string[]{
            "Essa e a 12 carta, alternativa: 1" ,
            "Essa e a 12 carta, alternativa: 2" ,
            "Essa e a 12 carta, alternativa: 3" ,
            "Essa e a 12 carta, alternativa: 4" },
        new string[]{
            "Essa e a 13 carta, alternativa: 1" ,
            "Essa e a 13 carta, alternativa: 2" ,
            "Essa e a 13 carta, alternativa: 3" ,
            "Essa e a 13 carta, alternativa: 4" },
        new string[]{
            "Essa e a 14 carta, alternativa: 1" ,
            "Essa e a 14 carta, alternativa: 2" ,
            "Essa e a 14 carta, alternativa: 3" ,
            "Essa e a 14 carta, alternativa: 4" },
        new string[]{
            "Essa e a 15 carta, alternativa: 1" ,
            "Essa e a 15 carta, alternativa: 2" ,
            "Essa e a 15 carta, alternativa: 3" ,
            "Essa e a 15 carta, alternativa: 4" },
        new string[]{
            "Essa e a 16 carta, alternativa: 1" ,
            "Essa e a 16 carta, alternativa: 2" ,
            "Essa e a 16 carta, alternativa: 3" ,
            "Essa e a 16 carta, alternativa: 4" },
        new string[]{
            "Essa e a 17 carta, alternativa: 1" ,
            "Essa e a 17 carta, alternativa: 2" ,
            "Essa e a 17 carta, alternativa: 3" ,
            "Essa e a 17 carta, alternativa: 4" },
        new string[]{
            "Essa e a 18 carta, alternativa: 1" ,
            "Essa e a 18 carta, alternativa: 2" ,
            "Essa e a 18 carta, alternativa: 3" ,
            "Essa e a 18 carta, alternativa: 4" },
        new string[]{
            "Essa e a 19 carta, alternativa: 1" ,
            "Essa e a 19 carta, alternativa: 2" ,
            "Essa e a 19 carta, alternativa: 3" ,
            "Essa e a 19 carta, alternativa: 4" },
        new string[]{
            "Essa e a 20 carta, alternativa: 1" ,
            "Essa e a 20 carta, alternativa: 2" ,
            "Essa e a 20 carta, alternativa: 3" ,
            "Essa e a 20 carta, alternativa: 4" }
    };

    public string[] pegarAlternativasDoBanco(int cardIndex)
    {
        alternativasCartasRetorno = new string[]
        {
            alternativasCartas[cardIndex][0],
            alternativasCartas[cardIndex][1],
            alternativasCartas[cardIndex][2],
            alternativasCartas[cardIndex][3]
        };
        return alternativasCartasRetorno;
    }
}
