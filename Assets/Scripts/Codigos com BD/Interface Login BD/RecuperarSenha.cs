using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperarSenha : MonoBehaviour
{
    // Start is called before the first frame update
    public void RecuperarSenhaFunction()
    {
        //Application.OpenURL("http://localhost/Cool_YT_RPG/forgotPassword.php");
        //Application.OpenURL("https://gameengenhariadesoftware.000webhostapp.com/forgotPassword.php");
        Application.OpenURL(MudarCena.siteName + "forgotPassword.php");
    }
}
