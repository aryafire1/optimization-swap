using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int lifespan;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Life());
    }

    IEnumerator Life() {
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }
}
