using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeGrabbable : MonoBehaviour
{
    private OVRGrabbable _oVRGrabbable;

    void Start()
    {
        _oVRGrabbable = GetComponent<OVRGrabbable>();
    }

    public void DisactiveGrabbable()
    {
        _oVRGrabbable.enabled = false;

        var myGrabber = _oVRGrabbable.m_grabbedBy;

        myGrabber.ForceRelease(_oVRGrabbable);
    }
}
