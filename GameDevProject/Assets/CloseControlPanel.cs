using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseControlPanel : MonoBehaviour
{
    public GameObject controlPanel;

    public void close() {
        controlPanel.SetActive(false);
    }
}
