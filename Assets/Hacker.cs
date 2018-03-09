using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    const string MenuHint = "You can use menu when ever you want."; 
    // Use this for initialization
    enum Screen { mainMenu, password, win };
    int level;
    string[] firstLvlPassowrds = { "book", "list", "dictionary", "textbook" };
    string[] secondLvlPassowrds = { "pistol", "officer", "prisoner", "vitneces" };
    string[] thirdLvlPassowrds = { "rocket", "mask", "atmosphere", "space" };

     string password;

    private Screen currentScreen;
    void Start()
    {
        print("Hello Console");
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.mainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What u would like to hack into?" + "\n" +
            "\n" + "Press 1 for the local library" +
            "\n" + "Press 2 for the police station" +
            "\n" + "Press 3 for the NASA" + "\n" +
            "\n" + "Enter your selection: ");
    }
    // TODO handle  
    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.mainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.password)
        {
            CheckForPassword(input);
        }
        else if (currentScreen == Screen.win)
        {
            ShowMainMenu();
        }
    }

    private void CheckForPassword(string input)
    {
        if (input==password)
        {
            ShowWinScreen();
        }
        else
        {
            AskForPassword();
        }
        
    }

    private void ShowWinScreen()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine("");
                Terminal.WriteLine(MenuHint);
                break;
            case 2:
                Terminal.WriteLine("Get a key...");
                Terminal.WriteLine("");
                Terminal.WriteLine(MenuHint);
                break;
            case 3:
                Terminal.WriteLine("Welcome to NASA...");
                Terminal.WriteLine("");
                Terminal.WriteLine(MenuHint);
                break;
        }
        currentScreen = Screen.win;
        Terminal.WriteLine("Congratulations!!!");

    }

    void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":level = 1;
                AskForPassword();
                break;
            case "2":
                level = 2;
                AskForPassword();
                break;
            case "3":
                level = 3;
                AskForPassword();
                break;
            case "007":
                Terminal.WriteLine("Invalid opration Mr. Bond.");
                break;
            default:
                Terminal.WriteLine("Invalid opration.");
                break;
        }

    }

    void AskForPassword()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.password;
        SetRandomPassword();
        Terminal.WriteLine("You have chosed level " + level);
        Terminal.WriteLine("Please enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(MenuHint); 
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                
                password = firstLvlPassowrds[UnityEngine.Random.Range(0, firstLvlPassowrds.Length)];
                break;
            case 2:
                
                password = secondLvlPassowrds[UnityEngine.Random.Range(0, secondLvlPassowrds.Length)];
                break;
            case 3:
                
                password = thirdLvlPassowrds[UnityEngine.Random.Range(0, thirdLvlPassowrds.Length)];
                break;
            default:
                Debug.Log("Invalid level number.");
                break;
        }
    }
}
