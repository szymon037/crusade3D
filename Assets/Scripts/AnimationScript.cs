using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    private Animator anim = null;
    private Vector3 oldPosition = Vector3.zero;
    private Vector3 newPosition = Vector3.zero;
    private Vector3 lastMove = Vector3.zero;
    public bool isMoving = false;
    private bool gamepadConnected = false;
    private float axisX = 0f;
    private float axisY = 0f;

    private float oldPosX = 0f;
    private float newPosX = 0f;
    private bool gamepad;

    private bool everyOtherFrame = true;

    void Start () {
        anim = GetComponent<Animator>();
        oldPosition = this.transform.position;
        oldPosX = this.transform.position.x;

    }
	
	void FixedUpdate () {
        gamepad = GetComponent<PlayerBehaviour>().gamepadConnected;

        newPosition = this.transform.position;
       // Debug.Log(this.transform.position.x);

       // if(everyOtherFrame)
        {
            //if(newPosition != oldPosition)
            if ((Mathf.Abs(newPosition.x - oldPosition.x) > 0.01) || (Mathf.Abs(newPosition.z - oldPosition.z) > 0.01))
            {
                isMoving = true;
                oldPosition = newPosition;
            }
            else
            {
                isMoving = false;
                
            }
        }

        // ten if usuwa odgrywanie jednej klatki biegu w lewo po tym, jak przestanie się wciskać klawisz (bez tego flaga isMoving jest jeszcze 
        //przez chwilę true, przez co zamiast animacji idle'a nadal jest odgrywana animacja biegu. A ponieważ nie wciskamy już klawisza, to wtedy 
        //odgrywana jest pierwsza animacja biegu w blend tree, czyli bodajże biegu w lewo :v )
        if ( (Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0) )
            isMoving = false;
            
           // everyOtherFrame = !everyOtherFrame;

        if (!gamepad)
        {
            axisX = Input.GetAxisRaw("Horizontal");
            axisY = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(axisX) > 0.3f)
                lastMove = new Vector3(axisX, 0f, 0f);

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.3f)
                lastMove = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            axisX = Input.GetAxisRaw("GamepadHorizontal");
            axisY = Input.GetAxisRaw("GamepadVertical");

            if (axisX > 0.03f) axisX = 1f;
            if (axisX < -0.03f) axisX = -1f;
            if (axisY > 0.03f) axisY = 1f;
            if (axisY < -0.03f) axisY = -1f;

            if (Mathf.Abs(Input.GetAxisRaw("GamepadHorizontal")) > 0.03f)
                anim.SetFloat("LastMoveX", lastMove.x);

            if (Mathf.Abs(Input.GetAxisRaw("GamepadVertical")) > 0.03f)
                anim.SetFloat("LastMoveY", lastMove.y);

        }


        anim.SetFloat("MoveX", axisX);
        anim.SetFloat("MoveY", axisY);
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.z);
    }
}
