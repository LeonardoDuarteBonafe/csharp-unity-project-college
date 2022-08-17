using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfeitoTransicaoFundo : MonoBehaviour
{
    // Start is called before the first frame update
    public Image imagemFundo;
    private int efeito = 1;
    private bool sumir = true;
    private float velocidade = 0.005f;
    // Update is called once per frame
    private void Start()
    {
        sumir = true;
        efeito = 1;  
    }
    void Update()
    {
        if (sumir)
        {
            imagemFundo.fillAmount = imagemFundo.fillAmount - velocidade;
            if(imagemFundo.fillAmount <= 0.02f)
            {
                sumir = false;
            }
        }
        else
        {
            imagemFundo.fillAmount = imagemFundo.fillAmount + velocidade;
            if (imagemFundo.fillAmount >= 0.98f)
            {
                sumir = true;
            }
        }
    }
}
