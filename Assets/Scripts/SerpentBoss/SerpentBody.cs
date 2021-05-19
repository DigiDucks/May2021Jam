using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentBody : MonoBehaviour
{
    [SerializeField]
    int length = 20;// how many segments

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
    float wiggleSpeed = 10f;
    [SerializeField]
    float wiggleMagnitude = 20f;
    [SerializeField]
    Transform wiggleDir;

    [SerializeField]
    Transform[] bodyParts;

    LineRenderer lineRend;


    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        for (int i = 1; i < bodyParts.Length; ++i)
        {
            if (bodyParts[i].gameObject.GetComponent<RotateToTarget>() != null)
            {
                bodyParts[i].gameObject.GetComponent<RotateToTarget>().SetTarget(bodyParts[i - 1]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for(int i = 1; i< segmentPoses.Length; ++i)
        {
            Vector3 targetPos = segmentPoses[i - 1] + 
                (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;

            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i],
                targetPos, ref segmentV[i], smoothSpeed);
        }
        for (int i = 1; i <= bodyParts.Length; ++i)
        {
            Vector3 seg = segmentPoses[(i * 2)-1];
            bodyParts[i - 1].position = seg;
        }

        lineRend.SetPositions(segmentPoses);
    }
}
