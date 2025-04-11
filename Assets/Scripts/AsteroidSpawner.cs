using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject ass;
    Asteroid newAss;

    public float leftBounds, rightBounds;
    
    void Start()
    {
        Ground.Event_Death.AddListener(Stop);
        UIscripts.Event_Reset.AddListener(Reset);
        StartCoroutine(evil(5));
    }

    void Summon() {
        newAss = Instantiate(ass, new Vector3(Random.Range(leftBounds, rightBounds + 1), 7, 0), Quaternion.identity).GetComponent<Asteroid>();
        newAss.Setup();
    }

    IEnumerator evil(int seconds) {
        InvokeRepeating("Summon", 0.5f, Random.Range(1, 5));
        yield return new WaitForSeconds(seconds);
        StartCoroutine(evil(seconds * 2));
    }

    void Stop() {
        StopAllCoroutines();
        CancelInvoke();
    }
    
    void Reset() {
        StartCoroutine(evil(5));
    }
}
