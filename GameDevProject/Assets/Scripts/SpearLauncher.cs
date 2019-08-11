using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearLauncher : MonoBehaviour
{
    public GameObject spear;
    public const float Timer = 3f;
    public float time;

    private void Start()
    {
        time = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GameObject g = Instantiate(spear);
            GetComponent<AudioSource>().Play();
            g.transform.position = transform.position;
            g.transform.rotation = transform.rotation;
            time = Timer;
        }
    }
}
