using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class NetworkManagerPhoton : MonoBehaviourPunCallbacks
{
    [Serializable]
    private enum GameplayScene
    {
        NetworkTestSpawning,
        VRDemoScene
    }


    public static NetworkManagerPhoton instance;
    /// <summary>
    /// reference to the number of player types available
    /// </summary>
    public static int numSceneNames = Enum.GetNames(typeof(GameplayScene)).Length;

    [Tooltip("Names of scenes that can be loaded into. To add to this list, open script and add to the Gameplay Scene enum")]
    [EnumNamedArray(typeof(GameplayScene))]
    public string[] SceneNames;

    [Tooltip("This determines which scene the network manager will spawn you into")]
    [SerializeField]
    private GameplayScene gameplayScene;

    private string GameplaySceneName;
    private string roomName;
    private bool joining = false;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            GameplaySceneName = SceneNames[(int)gameplayScene];
        }
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void OnApplicationQuit()
    {
        Disconnect();
    }

    public void CreateRoom()
    {
        if(roomName == null || roomName == "")
        {
            PhotonNetwork.CreateRoom($"Room {PhotonNetwork.CountOfRooms}");
        }
        else
        {
            PhotonNetwork.CreateRoom(roomName);
        }
    }

    public void JoinRoom(string Rn)
    {
        if(joining == true)
        {
            return;
        }

        roomName = Rn;
        joining = true;
        if(roomName == null || roomName == "")
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
        }
    }

    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    public static GameObject Instantiate(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        return PhotonNetwork.Instantiate($"Networking/Prefabs/{prefab.name}", pos, rot);
    }

    /// <summary>
    /// Ensures the agentPrefabs array is the correct size
    /// </summary>
    void OnValidate()
    {
        if (SceneNames.Length != numSceneNames)
        {
            Array.Resize(ref SceneNames, numSceneNames);
        }
    }

    #region Photon Callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
    }
    public override void OnCreatedRoom()
    {
        Debug.Log($"Created Room: {PhotonNetwork.CurrentRoom.Name}");
    }
    public override void OnJoinedRoom()
    {
        joining = false;
        Debug.Log($"Joined Room: {PhotonNetwork.CurrentRoom.Name}");
        ChangeScene(GameplaySceneName);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Join Room Failed");
        CreateRoom();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Disconnected: {cause}");
    }
    #endregion
}
