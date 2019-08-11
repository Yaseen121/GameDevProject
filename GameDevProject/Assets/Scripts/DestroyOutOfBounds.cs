﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Trap"))
        {
            //out of bounds so delete 
            Destroy(collision.gameObject);
        }
    }
}
