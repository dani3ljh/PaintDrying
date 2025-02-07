using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Handles PlayerControls
/// </summary>
public class PlayerControls : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float speed = 10f;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        anim = GetComponent<Animator>();  
        rb = GetComponent<Rigidbody2D>();  
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horiz, vert).normalized;

        anim.SetBool("isWalking", horiz != 0 || vert != 0);

        bool buttonUp = Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical");

        if (vert < 0 && (Input.GetButtonDown("Vertical") || buttonUp)) {
            anim.SetTrigger("walkDown");
            // print("down");
        } else if (vert > 0 && (Input.GetButtonDown("Vertical") || buttonUp)) {
            anim.SetTrigger("walkUp");
            // print("up");
        } else if (horiz > 0 && (Input.GetButtonDown("Horizontal") || buttonUp)) {
            anim.SetTrigger("walkRight");
            // print("right");
        } else if (horiz < 0 && (Input.GetButtonDown("Horizontal") || buttonUp)) {
            anim.SetTrigger("walkLeft");
            // print("left");
        }
    }

    /// <summary>
    /// Fixed Update is called at a constant 50 fps, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate() {
        rb.velocity = speed * movement;
    }
}
