using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    public float scrollSpeed = 45;
    void Update() {
        float mousePosX = Input.mousePosition.x;
        int scrollDistance = 30;

        if (mousePosX < scrollDistance) {   // going left
            transform.Translate(Vector2.right * -scrollSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector2.right * -scrollSpeed * Time.deltaTime);
        }

        if (mousePosX >= Screen.width - scrollDistance) {   // going right
            transform.Translate(Vector2.right * scrollSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector2.right * scrollSpeed * Time.deltaTime);
        }
    }
}
