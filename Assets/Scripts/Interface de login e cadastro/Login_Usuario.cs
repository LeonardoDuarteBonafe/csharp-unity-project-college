using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_Usuario: MonoBehaviour {

    public GameObject cadastrarUsuarioObject;
    public GameObject logarUsuarioObject;
    //public bool isLogin;

	// Use this for initialization
	void Start () {
        cadastrarUsuarioObject.SetActive(false);
        logarUsuarioObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LogarUsuario()
    {
        logarUsuarioObject.SetActive(true);
        cadastrarUsuarioObject.SetActive(false);
    }

    public void CadastrarUsuario()
    {
        logarUsuarioObject.SetActive(false);
        cadastrarUsuarioObject.SetActive(true);
    }
}
