using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brawler_Move : MonoBehaviour {
    public float moveSpeed = 10;

    void Update() {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
