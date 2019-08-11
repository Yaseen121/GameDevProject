using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebalSpawner : MonoBehaviour
{
    public GameObject fireball;
    public const float Timer = 5f;
    public float time;

    private void Start()
    {
        time = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0) {
            GameObject g = Instantiate(fireball);
            GetComponent<AudioSource>().Play();
            g.transform.position = transform.position;
            g.transform.rotation = transform.rotation;
            time = 5f;
        }
    }
}
