using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int health, speed;
    public Sprite[] hugeAss, bigAss, medAss, smallAss;
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    void Start() {
        Ground.Event_Death.AddListener(Die);
    }

    public void Setup() {
        health = Random.Range(1, 5);
        switch (health) {
            case 4: GetComponent<SpriteRenderer>().sprite = hugeAss[Random.Range(0, hugeAss.Length)];
                speed = 1;
                break;
            case 3: GetComponent<SpriteRenderer>().sprite = bigAss[Random.Range(0, bigAss.Length)];
                speed = 1;
                break;
            case 2: GetComponent<SpriteRenderer>().sprite = medAss[Random.Range(0, medAss.Length)];
                speed = 2;
                break;
            case 1: GetComponent<SpriteRenderer>().sprite = smallAss[Random.Range(0, smallAss.Length)];
                speed = 2;
                break;
        }
        rb.velocity = new Vector3(0, -speed, 0);
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Bullet>() != null) {
            Destroy(other.gameObject);
            health -= 1;
                if (health <= 0) {
                    Destroy(this.gameObject);
                }
                else {
                    switch (health) {
                        case 3: GetComponent<SpriteRenderer>().sprite = bigAss[Random.Range(0, bigAss.Length)];
                            speed = 1;
                            break;
                        case 2: GetComponent<SpriteRenderer>().sprite = medAss[Random.Range(0, medAss.Length)];
                            speed = 2;
                            break;
                        case 1: GetComponent<SpriteRenderer>().sprite = smallAss[Random.Range(0, smallAss.Length)];
                            speed = 2;
                            break;
                    }
                }
            rb.velocity = new Vector3(0, -speed, 0);
        }
        else if (other.GetComponent<Ground>() != null) {
            other.GetComponent<Ground>().HealthUpdate(health);
            Destroy(this.gameObject);
        }
    }

    void Die() {
        Destroy(this.gameObject);
    }
}
