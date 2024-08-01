using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brawler_Spawn : MonoBehaviour {

    public GameObject brawlerPrefab;

    public void Spawn() {
        Instantiate(brawlerPrefab);
    }
}
