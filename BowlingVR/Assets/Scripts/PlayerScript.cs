using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem
{
    public class PlayerScript : MonoBehaviour
    {
        public string a;

        public GameObject LeftHand;
        public GameObject RightHand;

        public SteamVR_Action_Vector2 action;
        public SteamVR_Action_Boolean lazer;

        private bool leftTrue = true;
        private bool rightTrue = true;
        private void Update()
        {
            Vector3 vector = Player.instance.hmdTransform.TransformDirection(new Vector3(action.axis.x, 0, action.axis.y));
            transform.position += Vector3.ProjectOnPlane(vector * Time.deltaTime * 2f, Vector3.up);

            if (lazer.GetStateDown(SteamVR_Input_Sources.LeftHand))
            {
                if (leftTrue)
                {
                    LeftHand.AddComponent<SteamVR_LaserPointer>();
                    var lazerPointer = LeftHand.GetComponent<SteamVR_LaserPointer>();
                    lazerPointer.color = Color.black;
                    lazerPointer.clickColor = Color.red;

                    //LeftHand.AddComponent<LaserObject>();
                    //var laserObject = LeftHand.GetComponent<LaserObject>();
                    //laserObject.action_Boolean = SteamVR_Actions.default_LaserObj;
                    leftTrue = false;
                }
                else if(leftTrue == false)
                {
                    GameObject spawn = LeftHand.GetComponent<SteamVR_LaserPointer>().holder;
                    Destroy(LeftHand.GetComponent<SteamVR_LaserPointer>());
                    //Destroy(LeftHand.GetComponent<LaserObject>());
                    Destroy(spawn);
                    leftTrue = true;
                }
            }

            if (lazer.GetStateDown(SteamVR_Input_Sources.RightHand))
            {
                if (rightTrue)
                {
                    RightHand.AddComponent<SteamVR_LaserPointer>();
                    var lazerPointer = RightHand.GetComponent<SteamVR_LaserPointer>();
                    lazerPointer.color = Color.black;
                    lazerPointer.clickColor = Color.red;

                    //RightHand.AddComponent<LaserObject>();
                    //var laserObject = RightHand.GetComponent<LaserObject>();
                    //laserObject.action_Boolean = SteamVR_Actions.default_LaserObj;
                    rightTrue = false;
                }
                else if (rightTrue == false)
                {
                    GameObject spawn = RightHand.GetComponent<SteamVR_LaserPointer>().holder;
                    Destroy(RightHand.GetComponent<SteamVR_LaserPointer>());
                    //Destroy(RightHand.GetComponent<LaserObject>());
                    Destroy(spawn);
                    rightTrue = true;
                }
            }
        }
    }
}
