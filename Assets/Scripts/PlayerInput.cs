using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class PlayerInput : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    float direction;
    SpriteRenderer renderer;
    Animator anim;

    //input system
    public Mario inputActions;
    InputAction move, fire;

    void Awake() {
        inputActions = new Mario();
        renderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start() {
        Ground.Event_Death.AddListener(Die);
    }

    void OnEnable() {
        anim.SetBool("isDead", false);

        move = inputActions.Player.Move;
        move.Enable();

        fire = inputActions.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    void OnDisable() {
        move.Disable();
        fire.Disable();
    }

    void Update() {
        direction = move.ReadValue<float>();

        if (direction != 0) {
            Move();
        }
        else {
            anim.SetBool("isRunning", false);
        }
    }

    void Move() {
            if (direction > 0) {
                renderer.flipX = true;
            }
            if (direction < 0) {
                renderer.flipX = false;
            }
            anim.SetBool("isRunning", true);
            transform.Translate(direction * speed * Vector3.right * Time.deltaTime);
    }

    void Fire(InputAction.CallbackContext context) {
        var newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity).GetComponent<Bullet>();
        newBullet.rb.velocity = new Vector3(0, 10, 0);
    }

    void Die() {
        this.enabled = false;
        anim.SetBool("isDead", true);
    }
}
