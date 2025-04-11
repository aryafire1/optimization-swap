using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIscripts : MonoBehaviour
{
    public PlayerInput player;
    public static UnityEvent Event_Reset;

    void Awake()
    {
        if (Event_Reset == null) {
            Event_Reset = new UnityEvent();
        }
        this.gameObject.SetActive(false);
    }

    void WakeUp() {
        this.gameObject.SetActive(true);
    }

    public void Reset() {
        Event_Reset?.Invoke();
        player.enabled = true;
        this.gameObject.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
    }
}
