using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	private SpriteRenderer sr;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			sr.color = new Color(sr.color.r - 0.01f, sr.color.g - 0.01f, sr.color.b - 0.01f);
		}
	}
}
