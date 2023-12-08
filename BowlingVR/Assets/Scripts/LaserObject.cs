using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserObject : MonoBehaviour
{
    public SteamVR_Action_Boolean action_Boolean;

    public GameObject objRay;
    void FixedUpdate()
    {
        if (action_Boolean.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            RaycastHit hit;
            Ray raycast = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(raycast, out hit))
            {
                if (hit.collider != null && (hit.collider.gameObject.CompareTag("Visual") || hit.collider.gameObject.CompareTag("Ball")))
                {
                    objRay = hit.collider.gameObject;
                    if(objRay != null)
                    {
                        Destroy(objRay.GetComponent<Throwable>());
                        Destroy(objRay.GetComponent<Rigidbody>());
                        objRay.transform.parent = transform;
                    }
                }
            }
        }

        if (objRay != null)
        {
            if (action_Boolean.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                objRay.AddComponent<Throwable>();
                objRay.transform.parent = null;
                objRay = null;
            }
        }
    }
}
