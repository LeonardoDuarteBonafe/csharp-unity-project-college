using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class campoResposta : MonoBehaviour {

    public InputField campoRespostaInput;
    public Button confirmarRespostaBotao;

    public bool confirmouResposta = false;

    public GameObject campoRespostaObjeto;

    private void Awake()
    {
        campoRespostaObjeto.SetActive(false);
    }

    public void mostrarCampoResposta(bool mostrar)
    {
        campoRespostaInput.text = "";
        confirmouResposta = false;
        campoRespostaObjeto.SetActive(mostrar);
    }

    public string pegarResposta()
    {
        return campoRespostaInput.text;
    }

    public void respostaConfirmadaClique()
    {
        confirmouResposta = true;
    }

        public bool respostaConfirmada()
    {
        return confirmouResposta;
    }
}
