using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ground : MonoBehaviour
{
    public GameObject endUI;
    public float health;
    float maxHealth;
    public Slider healthUI;
    public static UnityEvent Event_Death;

    void Awake() {
        if (Event_Death == null) {
            Event_Death = new UnityEvent();
        }
        maxHealth = health;
    }

    void Start() {
        UIscripts.Event_Reset.AddListener(Reset);
    }

    public void HealthUpdate(float h) {
        health -= h;
        healthUI.value = health / maxHealth;
        if (health <= 0) {
            Event_Death?.Invoke();
            endUI.SetActive(true);
        }
    }

    void Reset() {
        health = maxHealth;
        healthUI.value = 1;
    }
}
