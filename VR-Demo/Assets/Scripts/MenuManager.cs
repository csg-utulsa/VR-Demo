using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject RoomMenu;
    public GameObject CharacterMenu;
    // Start is called before the first frame update
    void Start()
    {
        RoomMenu.SetActive(true);
        CharacterMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HostGame()
    {
        ToggleMenus();
    }

    public void JoinGame()
    {
        ToggleMenus();
    }

    public void ChooseCharacter(int type)
    {
        PlayerPrefs.SetInt("PlayerType", type);
        LoadGameScene();
    }

    public void ExitGame()
    {

    }

    private void ToggleMenus()
    {
        RoomMenu.SetActive(!RoomMenu.activeSelf);
        CharacterMenu.SetActive(!CharacterMenu.activeSelf);
    }

    private void LoadGameScene()
    {

    }
}
