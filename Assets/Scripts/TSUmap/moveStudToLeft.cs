using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStudToLeft : MonoBehaviour
{
    private Vector2 direction;
    public float speed;

    private void Update()
    {
        direction = Vector2.zero;
        direction -= Vector2.right;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
