using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoginModule : MonoBehaviour
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
    private InputField usernameLoginField;//Field
    [SerializeField]
    private InputField passwordLoginField;//Field
    public Text warningLoginText;

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

    public void LoginButton()
    {
        StartCoroutine(Login(usernameLoginField.text, passwordLoginField.text));
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
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
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }
        else if (LoginTask.IsCompleted)
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            Debug.Log("Logged In"); //confirmLoginText.text = "Logged In";
            //StartCoroutine(LoadUserData());

            //usernameField.text = User.DisplayName;
            // UIManager.instance.UserDataScreen(); // Change to user data UI
            //confirmLoginText.text = "";
            SceneManager.LoadSceneAsync("Town_Scene");
            Debug.Log("Change Scene");
        }

    }
}
