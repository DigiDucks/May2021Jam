using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentBody : MonoBehaviour
{
    [SerializeField]
    int length = 6;// how many segments

    [SerializeField]
    Vector3[] segmentPoses;//positions of segments
    [SerializeField]
    Vector3[] segmentV;//velocity of segments

    [SerializeField]
    Transform targetDir; //where the wiggly bit wiggles towards
    [SerializeField]
    float targetDist = 0.2f; //lengtch of segments
    [SerializeField]
    float smoothSpeed = 0.001f;// how fast they wiggle
    [SerializeField]
    float trailSpeed = 350f;// how fast they reach their target

    LineRenderer lineRend;

    
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        segmentPoses[0] = targetDir.position;

        for(int i = 1; i< segmentPoses.Length; ++i)
        {
            segmentPoses[i] =
                Vector3.SmoothDamp(segmentPoses[i],
                segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i/trailSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }
}
