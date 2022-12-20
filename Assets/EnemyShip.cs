using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public void death() {
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }
}
