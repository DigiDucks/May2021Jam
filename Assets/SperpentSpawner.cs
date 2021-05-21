using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SperpentSpawner : MonoBehaviour
{
    [SerializeField]
    SerpentBehaviourManager[] sperpents;

    [SerializeField]
    int phase;

    int numSperp;
    // Start is called before the first frame update
    void Start()
    {
        phase = 0;
        numSperp = sperpents.Length;
    }

    // Update is called once per frame
    void Update()
    {
        switch(phase)
        {
            case 1:
                StartCoroutine(Phase1());
                phase = 0;
                break;
            case 2:
                StartCoroutine(Phase2());
                phase = 0;
                break;
            case 3:
                StartCoroutine(Phase3());
                phase = 0;
                break;
        }
    }

    public void KillSperp()
    {
        --numSperp;
        if (numSperp == 9)
            phase = 1;
        if (numSperp == 7)
            phase = 2;
        if (numSperp == 4)
            phase = 3;
        if (numSperp <= 0)
            GameManager.instance.OpenWin();
    }

    IEnumerator Phase1()
    {
        sperpents[1].gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        sperpents[2].gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        sperpents[3].gameObject.SetActive(true);
    }

    IEnumerator Phase2()
    {
        sperpents[4].gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        sperpents[5].gameObject.SetActive(true);
    }

    IEnumerator Phase3()
    {
        sperpents[6].gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        sperpents[7].gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        sperpents[8].gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        sperpents[9].gameObject.SetActive(true);
    }
}
