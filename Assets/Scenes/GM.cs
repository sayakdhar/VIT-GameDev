﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
	public Ball ball;
	public Paddle paddle;
    // Start is called before the first frame update
    public static Vector2 bottomLeft;
    public static Vector2 topRight;



    void Start()
    {
    	bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2 (0, 0));
    	topRight = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, Screen.height));

        Instantiate (ball);
        
        Paddle paddle1 = Instantiate (paddle) as Paddle;
        Paddle paddle2 = Instantiate (paddle) as Paddle;
        paddle1.Init (true); //r-paddle
        paddle2.Init (false);//l-paddle
    }

    // Update is called once per frame
    
}
