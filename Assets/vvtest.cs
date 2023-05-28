
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGCore;
using SGCore.Kinematics;



public class vvtest : MonoBehaviour
{



    public SG.SG_GrabScript Grab;


    private SGCore.HandProfile handProfile;
    private SGCore.HapticChannelInfo gloveInfo;

    public SG.SG_Grabable grabObject;

    private SGCore.HapticGlove gloveData;

    private SG.SG_HandPose currentPose;
    private SG.SG_FingerFeedback middleFingerFeedback;

    // Start is called before the first frame update
    void Start()
    {

        handProfile = SG.SG_HandProfiles.GetProfile(false);
        currentPose = SG.SG_HandPose.Idle(false);
    }





    // Update is called once per frame
    void Update()
    {
        



    }

    void OnGrabObject(SG.SG_GrabbedObjectEvent grabInfo)
    {
        // Access the grabbed object through the GrabbedObject property of the grabScript
       
    }

}