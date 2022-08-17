using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTabuleiro : MonoBehaviour {

    public GameObject tabuleiroObjeto;
    public GameObject jogadorObjeto;
    public Camera cameraPrincipal;
    public GameObject canvasInterfacePrincipal;
    public GameObject novoJogoObject;
    public GameObject salvarJogoObject;
    
    private void Start()
    {
        tabuleiroObjeto.SetActive(false);
        jogadorObjeto.SetActive(false);
    }

    public void TransicaoTabuleiro(bool estadoTabuleiroEJogador)
    {
        if (estadoTabuleiroEJogador)
        {
            cameraPrincipal.backgroundColor = Color.white;
        }
        else
        {
            Color32 backgroundColor = new Color32(77, 130, 232, 207);
            cameraPrincipal.backgroundColor = backgroundColor;
        }
        tabuleiroObjeto.SetActive(estadoTabuleiroEJogador);
        jogadorObjeto.SetActive(estadoTabuleiroEJogador);
        novoJogoObject.SetActive(!estadoTabuleiroEJogador);
        salvarJogoObject.SetActive(!estadoTabuleiroEJogador);

    }
}
