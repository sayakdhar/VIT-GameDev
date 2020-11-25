using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (direction * speed * Time.deltaTime);

        if (transform.position.y < GM.bottomLeft.y + radius && direction.y < 0) {
        	direction.y = -direction.y;
        }
        if (transform.position.y > GM.topRight.y - radius && direction.y > 0) {
        	direction.y = -direction.y;
        }

        if (transform.position.x < GM.bottomLeft.x + radius && direction.x < 0) {
        	Debug.Log ("Right player Wins!!");
        	Time.timeScale = 0;
        	enabled = false;
        }
        if (transform.position.x > GM.topRight.x - radius && direction.x > 0) {
        	Debug.Log ("Left player Wins!!");
        	Time.timeScale = 0;
        	enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
    	if(other.tag == "Paddle") {
    		bool isRight = other.GetComponent<Paddle> ().isRight;

    		if (isRight == true && direction.x > 0) {
    			direction.x = -direction.x;
    		}
    		if (isRight == false && direction.x < 0) {
    			direction.x = -direction.x;
    		}
    	}
    }
}
