using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo 
{
    public string uid;
    public string name;
    public string surname;
    public string email;  

    public UserInfo(string uid, string name, string surname, string email)
    {
        this.uid = uid;
        this.name = name;
        this.surname = surname;
        this.email = email;
    }
}
