using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Move : MonoBehaviour {
    public float moveSpeed = 1;

    void Update() {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}