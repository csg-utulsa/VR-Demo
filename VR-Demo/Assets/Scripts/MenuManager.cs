using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField roomName;
    public GameObject can;

  // Start is called before the first frame update
  void Start()
    {
        can = GameObject.FindGameObjectWithTag("Credits").GetComponent<GameObject>();
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
        can.SetActive(true);
    }

  public void CreditsOff()
  {
    can.SetActive(false);
  }

  public void ExitGame()
    {

    }

    private void LoadGameScene()
    {

    }
}
