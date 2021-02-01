using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCredits : MonoBehaviour
{
    public void SendEmail()
    {
        string email = "kmiecikjob@gmail.com";
        string subject = MyEscapeURL("Another Top-Down Space Shooter");
        Application.OpenURL("mailto:" + email + "?subject=" + subject);
    }
    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }

}
