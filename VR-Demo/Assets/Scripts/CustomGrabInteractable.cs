using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomGrabInteractable : XRGrabInteractable
{
    private Transform defaultParent;

    private void Start()
    {
        defaultParent = GameObject.FindGameObjectWithTag("InteractableDefault").transform;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        SetParentToXRRig();
        base.OnSelectEntered(interactor);
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        SetParentToWorld();
        base.OnSelectExited(interactor);
    }

    public void SetParentToXRRig()
    {
        transform.SetParent(selectingInteractor.transform);
    }

    public void SetParentToWorld()
    {
        transform.SetParent(defaultParent);
    }
}
