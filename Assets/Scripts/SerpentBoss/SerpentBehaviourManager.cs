using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerpentBehaviourManager : MonoBehaviour
{

    public enum SerpentState
    {
        Tunnel,
        Bounce,
        Wait,
        Spiral
    }

    enum TunnelState
    {
        Attack,
        Burrow,
        Search,
        Teleport,
    }

    SerpentBody serpentBody;

    Transform head;

    SerpentState currentState = SerpentState.Tunnel;
    TunnelState tunnelState = TunnelState.Search;

    [SerializeField]
    Transform targetTransform;

    [SerializeField]
    float moveSpeed = 5f;

    int currentTunnel;

    public Transform[] northTunnles;
    public Transform[] eastTunnles;
    public Transform[] southTunnles;
    public Transform[] westTunnles;

    Transform[][] Tunnels = new Transform[4][];

    // Start is called before the first frame update
    void Start()
    {
        Tunnels[0] = northTunnles;
        Tunnels[1] = eastTunnles;
        Tunnels[2] = southTunnles;
        Tunnels[3] = westTunnles;
        serpentBody = FindObjectOfType<SerpentBody>();
        head = serpentBody.gameObject.transform.parent.transform;

        tunnelState = TunnelState.Teleport;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case SerpentState.Tunnel:
                switch (tunnelState)
                {
                    case TunnelState.Attack:
                        head.position = Vector2.MoveTowards(head.position,
                            targetTransform.position, moveSpeed * Time.deltaTime);
                        if (Vector3.Distance(head.position, targetTransform.position) < 0.1f)
                        {
                            if (targetTransform.childCount > 0)
                            {
                                targetTransform = targetTransform.GetChild(0).transform;
                            }
                            else
                            {
                                tunnelState = TunnelState.Teleport;
                            }    
                        }
                        break;
                    case TunnelState.Search:
                        RandomizeTarget();
                        targetTransform = Tunnels[currentTunnel][Random.Range(0, 3)];
                        head.gameObject.GetComponent<RotateToTarget>().SetTarget(targetTransform);
                        tunnelState = TunnelState.Attack;
                        break;
                    case TunnelState.Teleport:
                        RandomizeTarget();
                        int t = Random.Range(0, 3);
                        targetTransform = Tunnels[currentTunnel][t];
                        head.position = targetTransform.GetChild(0).position;
                        serpentBody.Coil();
                        tunnelState = TunnelState.Burrow;
                        break;
                    case TunnelState.Burrow:
                        head.position = Vector2.MoveTowards(head.position,
                            targetTransform.position, moveSpeed * Time.deltaTime);
                        if (Vector3.Distance(head.position, targetTransform.position) < 0.1f)
                        {
                            tunnelState = TunnelState.Search;
                            StartCoroutine(StateWait());
                            currentState = SerpentState.Wait;
                        }
                        break;
                }
                break;
            case SerpentState.Bounce:
                break;
            case SerpentState.Wait:
                break;
        }
    }

    void RandomizeTarget()
    {
        int nextTunnel = Random.Range(0, 3);
        if (nextTunnel == currentTunnel)
            RandomizeTarget();
        else
            currentTunnel = nextTunnel;
    }

    public void SetState(SerpentState state)
    {
        currentState = state;
    }

    IEnumerator StateWait()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.5f));
        currentState = SerpentState.Tunnel;
    }
}
