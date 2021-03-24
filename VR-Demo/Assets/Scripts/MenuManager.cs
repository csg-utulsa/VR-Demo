using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField roomName;
    public Canvas can; // Assign in inspector
    can = GameObject.FindGameObjectWithTag("Credits").GetComponent<Canvas>();

  // Start is called before the first frame update
  void Start()
    {
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
        can.enabled = !can.enabled;
    }

    public void ExitGame()
    {

    }

    private void LoadGameScene()
    {

    }
}
