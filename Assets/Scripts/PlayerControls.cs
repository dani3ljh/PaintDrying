using System.Collections;
using System.Collections.Generic;
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

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        anim = GetComponent<Animator>();  
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        anim.SetBool("isWalking", horiz != 0 || vert != 0);

        if (vert < 0 && Input.GetButtonDown("Vertical")) {
            anim.SetTrigger("walkDown");
            print("down");
        } else if (vert > 0 && Input.GetButtonDown("Vertical")) {
            anim.SetTrigger("walkUp");
            print("up");
        } else if (horiz > 0 && Input.GetButtonDown("Horizontal")) {
            anim.SetTrigger("walkRight");
            print("right");
        } else if (horiz < 0 && Input.GetButtonDown("Horizontal")) {
            anim.SetTrigger("walkLeft");
            print("left");
        }

        transform.position += speed * Time.deltaTime * new Vector3(horiz, vert, 0).normalized;
    }
}
