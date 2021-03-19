using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string startMenuName;

    [Header("Player Prefabs")]
    public GameObject[] playerPrefabs;

    [Header("Spawn Locations")]
    /// <summary>
    /// Where in the level player's spawn from
    /// </summary>
    public Transform[] spawnLocations;

    //reference to the current Photon room
    private Photon.Realtime.Room currentRoom;
    private GameObject localAgent;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // in case we started this demo with the wrong scene being active, simply load the menu scene
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene(startMenuName);

            return;
        }

        //store the photon room we are in
        currentRoom = PhotonNetwork.CurrentRoom;

        //create the local agent
        localAgent = NetworkManagerPhoton.Instantiate(playerPrefabs[PlayerPrefs.GetInt("PlayerType")], spawnLocations[(currentRoom.PlayerCount - 1) % spawnLocations.Length].position, Quaternion.Euler(0, 180, 0));
    }

    /// <summary>
    /// returns the number of players in the room
    /// </summary>
    /// <returns></returns>
    public int GetNumPlayers()
    {
        return currentRoom.PlayerCount;
    }
}
