using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;

    void Start()
    {
        height = transform.localScale.y;
        
    }

    public void Init(bool isRightPaddle) {

    	isRight = isRightPaddle;

    	Vector2 pos = Vector2.zero;

    	if (isRightPaddle){
    		pos = new Vector2(GM.topRight.x, 0);
    		pos -= Vector2.right * transform.localScale.x;

    		input = "PaddleRight";

    		}else {
    			pos = new Vector2(GM.bottomLeft.x, 0);
    			pos += Vector2.right * transform.localScale.x;

    			input = "PaddleLeft";

    		}
    		transform.position = pos;
    		transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GM.bottomLeft.y + height / 2 && move < 0){
        	move = 0;
        }
        if (transform.position.y > GM.topRight.y - height / 2 && move > 0){
        	move = 0;
        }

        transform.Translate (move * Vector2.up);
    }
}
