using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    private string inputUserName;
    private string inputPassword;
    public string userName;
    public InputField loginUsuario;
    public InputField loginSenha;
    public GameObject usuarioSenhaIncorreto;

    public GameObject loginUsuarioObject;

    //string LoginURL = "http://localhost/cool_YT_RPG/Login.php";
    //string LoginURL = "https://gameengenhariadesoftware.000webhostapp.com/Login.php";
    string LoginURL = MudarCena.siteName+"Login.php";

    // Use this for initialization
    void Start () {
        usuarioSenhaIncorreto.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        inputUserName = loginUsuario.text;
        inputPassword = loginSenha.text;
    }

    public void ConfirmarLogin()
    {
        {
            if (inputUserName != "" && inputPassword != "")
            {
                StartCoroutine(LoginToDB(inputUserName, inputPassword));
            }
        }
    }

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(LoginURL, form);
        yield return www;
        if (www.text.Contains("Success"))
        {
            userName = username;
            MudarCena.userName = username;
            SceneManager.LoadSceneAsync(2);
        }
        else
        {
            usuarioSenhaIncorreto.SetActive(true);
        }
    }
}
