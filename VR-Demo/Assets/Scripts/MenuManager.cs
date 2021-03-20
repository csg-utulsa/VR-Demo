using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField roomName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JoinGame()
    {
        ChooseCharacter(0);
        NetworkManagerPhoton.instance.JoinRoom();
    }

    public void ChooseCharacter(int type)
    {
        PlayerPrefs.SetInt("PlayerType", type);
        LoadGameScene();
    }

    public void ExitGame()
    {

    }

    private void LoadGameScene()
    {

    }
}
