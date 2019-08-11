using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEscaped : MonoBehaviour
{
    public bool escaped;

    private void Start()
    {
        escaped = false;
    }

    public void reachedSafeHouse() {
        escaped = true;
    }
}
