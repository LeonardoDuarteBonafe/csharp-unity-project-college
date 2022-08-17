using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class CheckEmail : MonoBehaviour {

	public bool checkForEmail(string email)
    {
        bool isValid = false;
        Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        if (r.IsMatch(email))
        {
            isValid = true;
        }
        return isValid;
    }
}
