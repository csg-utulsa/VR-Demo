using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public GameObject[] localOnlyObjects;
    public Behaviour[] localOnlyComponents;

    // Start is called before the first frame update
    void Awake()
    {
        bool active = photonView.IsMine;
        foreach(GameObject obj in localOnlyObjects)
        {
            obj.SetActive(active);
        }

        foreach(Behaviour comp in localOnlyComponents)
        {
            comp.enabled = active;
        }
    }
}
