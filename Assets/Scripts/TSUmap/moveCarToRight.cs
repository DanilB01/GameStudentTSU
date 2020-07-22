using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCarToRight : MonoBehaviour
{

    private Vector2 direction;
    public float speed;
    private void Update()
    {
        direction = Vector2.zero;
        direction -= Vector2.left;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
