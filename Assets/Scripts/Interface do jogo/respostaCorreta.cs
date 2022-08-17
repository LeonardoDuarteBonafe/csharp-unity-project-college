using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class respostaCorreta : MonoBehaviour {
    public Text textoRespostaCorreta;
	// Use this for initialization
	void Start () {
        textoRespostaCorreta.text = "";
	}
	
	// Update is called once per frame
	public void checarRespostaCorreta(bool status) { 
        if (status)
        {
            textoRespostaCorreta.text = "Resposta Correta";
            textoRespostaCorreta.color = new Color(0f, 1f, 0f);
        }
        else
        {
            textoRespostaCorreta.text = "Resposta Errada";
            textoRespostaCorreta.color = Color.red;
        }
	}
    public void limparTextoChecarResposta()
    {
        textoRespostaCorreta.text = "";
    }
}
