using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class Authentication : MonoBehaviour
{
    [Header("Firebase")]
    protected DependencyStatus dependencyStatus;
    protected FirebaseAuth auth;
    protected FirebaseUser User;
    protected DatabaseReference DBreference;
    protected Dictionary<string, Firebase.Auth.FirebaseUser> userByAuth = new Dictionary<string, Firebase.Auth.FirebaseUser>();
    public Text warningInternet;


    [Header("Login")]
    [SerializeField]
    private InputField EmailRegisterField;//Field
    [SerializeField]
    private InputField passwordRegisterField;//Field
    public Text warningRegisterText;
    [SerializeField]
    private InputField Name;//Field
    [SerializeField]
    private InputField Surname;//Field

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        Debug.Log(FirebaseAuth.DefaultInstance);
        if (auth == null)
        {
            auth = FirebaseAuth.DefaultInstance;
        }
    }

    public void RegisterButton()
    {
        StartCoroutine(Register(EmailRegisterField.text, passwordRegisterField.text));
    }

    private IEnumerator Register(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

        if (RegisterTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
            FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WeakPassword:
                    message = "Weak Password";
                    break;
                case AuthError.EmailAlreadyInUse:
                    message = "Email Already In Use";
                    break;
            }
            warningRegisterText.text = message;
        }
        else if (RegisterTask.IsCompleted)
        {
                //Username is now set
                //Create New User on Database               
                User = RegisterTask.Result;
                StartCoroutine(CreateNewUserDatabase(User.UserId, Name.text, Surname.text, EmailRegisterField.text));
                //warningRegisterText.text = "";               
                SceneManager.LoadSceneAsync("Town_Scene");
                Debug.Log("Change Scene");
        }
    }

    private IEnumerator CreateNewUserDatabase(string uid, string name, string surname, string email)
    {
        UserInfo user = new UserInfo(uid, name, surname, email);
        string json = JsonConvert.SerializeObject(user);
        Debug.Log(json);
        //Set the currently logged in user username in the database
        var DBTask = DBreference.Child("Users").Child(uid).SetRawJsonValueAsync(json);
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.Log("CreateNewUser is done");
        }
    }

}
