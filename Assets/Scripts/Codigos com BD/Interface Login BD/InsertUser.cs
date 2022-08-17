using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertUser : MonoBehaviour {

    public InputField cadastrarUsuario;
    public GameObject cadastrarSenha;
    public InputField cadastrarEmail;

    private string inputUserName;
    private string inputPassword;
    private string inputEmail;

    public GameObject loginUsuiaroObject;
    public GameObject erroCadastrarObject;
    public Text erroCadastrarText;

    //string CreateUserURL = "http://localhost/Engenharia_de_software/InsertUser.php";
    //string CreateUserURL = "https://gameengenhariadesoftware.000webhostapp.com/InsertUser.php";
    string CreateUserURL = MudarCena.siteName + "InsertUser.php";

    // Use this for initialization
    void Start () {
        erroCadastrarObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        inputUserName = cadastrarUsuario.text;
        inputPassword = cadastrarSenha.GetComponent<InputField>().text;
        inputEmail = cadastrarEmail.text;
        if (inputUserName.Length>40 && inputUserName != null)
        {
        }
    }

    public void ConfirmarCadastro()
    {
        {
            bool testeEmail = GameObject.Find("MenuLogin").GetComponent<CheckEmail>().checkForEmail(inputEmail);
            if (testeEmail)
            {
                if (inputUserName != "" && inputPassword != "" && inputEmail != "")
                {
                    StartCoroutine(CreateUser(inputUserName, inputPassword, inputEmail));
                }
                else
                {
                    if(inputEmail != "")
                    {
                        erroCadastrarText.text = "Email válido!";
                        Color32 verdeAprovacao = new Color32(0x0D, 0x95, 0x13, 0xFF);
                        erroCadastrarText.color = verdeAprovacao;
                        erroCadastrarObject.SetActive(true);
                    }
                }
            }
            else
            {
                erroCadastrarText.text = "Email inválido!";
                erroCadastrarText.color = Color.red;
                erroCadastrarObject.SetActive(true);
            }
        }
    }
    
    IEnumerator CreateUser(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("emailPost", email);

        WWW www = new WWW(CreateUserURL, form);
        yield return www;
        if (www.text.Contains("Fail"))
        {
            erroCadastrarText.text = "Nome de usuário existente, tente outro!";
            erroCadastrarText.color = Color.red;
            erroCadastrarObject.SetActive(true);
        }
        else
        {
            erroCadastrarText.text = "Usuário criado com sucesso!";
            Color32 verdeAprovacao = new Color32(0x0D, 0x95, 0x13, 0xFF);
            erroCadastrarText.color = verdeAprovacao;
            erroCadastrarObject.SetActive(true);
        }

    }
}
