using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    public float scrollSpeed = 45;
    void Update() {
        var mPosX = Input.mousePosition.x;
        var mPosY = Input.mousePosition.y;

        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        int scrollDistance = 30;
        if (mousePosX < scrollDistance) {
            transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
        }

        if (mousePosX >= Screen.width - scrollDistance) {
            transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        }
    }
}
