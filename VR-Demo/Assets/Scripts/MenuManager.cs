using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

  // Start is called before the first frame update
  void Start()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JoinGamePlayer()
    {
        ChooseCharacter(0);
        NetworkManagerPhoton.instance.JoinRoom();
    }

    public void JoinGameRover()
    {
        ChooseCharacter(1);
        NetworkManagerPhoton.instance.JoinRoom();
    }

    public void ChooseCharacter(int type)
    {
        PlayerPrefs.SetInt("PlayerType", type);
        LoadGameScene();
    }

    public void toggleCredits()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        creditsMenu.SetActive(!creditsMenu.activeSelf);
    }

  public void ExitGame()
    {

    }

    private void LoadGameScene()
    {

    }
}
