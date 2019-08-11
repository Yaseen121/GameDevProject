using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCamera : MonoBehaviour
{
    public GameObject[] players;
    public float lowBoundX = 0f;
    public float lowBoundY = 0f;
    public float upperBoundX = 19.5f;
    public float upperBoundY = 15f;
    public float minCamPoint;
    public float maxCamPoint;
    float mx;

    float cameraMoveSpeed = 10f;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

    }

    void setCameraPos() {
        Vector3 middle = transform.position;
        if (players.Length == 1)
        {
            middle = players[0].transform.position;
        }
        else if (players.Length == 2)
        {
            middle = (players[0].transform.position + players[1].transform.position) * 0.5f;
        }
        else if (players.Length == 3)
        {
            middle = (players[0].transform.position + players[1].transform.position + players[2].transform.position) * 0.33f;
        }
        else {
            middle = (players[0].transform.position + players[1].transform.position + players[2].transform.position + players[3].transform.position) * 0.4f;
        }
        if (middle.x < lowBoundX)
        {
            middle.x = lowBoundX;
        }
        else if (middle.x > upperBoundX)
        {
            middle.x = upperBoundX;
        }
        if (middle.y < lowBoundY)
        {
            middle.y = lowBoundY;
        }
        else if (middle.y > upperBoundY)
        {
            middle.y = upperBoundY;
        }
        transform.position = new Vector3(
            middle.x,
            middle.y,
           transform.position.z);
    }

    void Update()
    {
        if (!onTraps)
            players = GameObject.FindGameObjectsWithTag("Player");
       
        //setCameraPos();
        //if (players.Length != 1)
        //{
        //    SetCameraSize();
        //}
        //else {
        //    GetComponent<Camera>().orthographicSize = 5;
        //}
        findCenter();
    }

    public float minSizeY = 5f;

    void SetCameraSize()
    {
        //horizontal size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;

        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width =0f;
        float height = 0f;

        if (players.Length == 2)
        {
            width = Mathf.Abs(players[0].transform.position.x- players[1].transform.position.x) * 0.6f;
            height = Mathf.Abs(players[0].transform.position.y- players[1].transform.position.y) * 0.5f;
        }
        else if (players.Length == 3)
        {
            //middle = (players[0].transform.position + players[1].transform.position + players[2].transform.position) * 0.33f;


        }
        else
        {
            //middle = (players[0].transform.position + players[1].transform.position + players[2].transform.position + players[3].transform.position) * 0.4f;
        }

        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX);
        GetComponent<Camera>().orthographicSize = Mathf.Max(height,
            camSizeX * Screen.height / Screen.width, minSizeY);
    }







    public float[] xPositions;
    public float[] yPositions;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public Vector2 center;
    public Vector3 norm;


    void findCenter() {
        xPositions = new float[players.Length];
        yPositions = new float[players.Length];

        for (int i = 0; i < players.Length; i++) {
            xPositions[i] = players[i].transform.position.x;
            yPositions[i] = players[i].transform.position.y;


            //xPositions.Add(players[i].transform.position.x);
            //yPositions.Add(players[i].transform.position.y);
        }
        float maxX = Mathf.Max(xPositions);
        float maxY = Mathf.Max(yPositions);
        float minX = Mathf.Min(xPositions);
        float minY = Mathf.Min(yPositions);

        minPosition = new Vector2(minX-5f, minY);
        maxPosition = new Vector2(maxX+5f, maxY);
        center = (minPosition + maxPosition) * 0.5f;

        //norm = Vector3.Cross(new Vector3(center.x, center.y, 0f), new Vector3(0, 1, 0));
        if (center.x < lowBoundX)
        {
            center.x = lowBoundX;
        }
        else if (center.x > upperBoundX)
        {
            center.x = upperBoundX;
        }
        if (center.y < lowBoundY)
        {
            center.y = lowBoundY;
        }
        else if (center.y > upperBoundY)
        {
            center.y = upperBoundY;
        }
        transform.position = new Vector3(center.x, center.y, transform.position.z);
        float orthScale = (maxX - minX) * 0.5f;

        if (orthScale > 5 &&  players.Length > 1)//(norm.z > 5 &&
        {
            GetComponent<Camera>().orthographicSize = orthScale;
        }
        else {
            GetComponent<Camera>().orthographicSize = 5;
        }
    }

    private GameObject[] storedPlayers;
    private bool onTraps;

    public void setCameraToTraps (GameObject[] traps)
    {
        onTraps = true;
        storedPlayers = players;
        players = traps;
    }

    public void setCameraBackToPlayers()
    {
        onTraps = false;
        players = storedPlayers;
    }
}
