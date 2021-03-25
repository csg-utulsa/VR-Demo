using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField roomName;
    public Canvas can;
    public Canvas maincan;

  // Start is called before the first frame update
  void Start()
    {
        can = GameObject.FindGameObjectWithTag("Credits").GetComponent<Canvas>();
        maincan = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Canvas>();
        can.enabled = false;
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

    public void CreditsOn()
    {
        can.enabled = true;
    maincan.enabled = false;
    }

    public void CreditsOff()
    {
        can.enabled = false;
    maincan.enabled = true;

  }

  public void ExitGame()
    {

    }

    private void LoadGameScene()
    {

    }
}
