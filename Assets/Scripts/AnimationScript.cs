using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    private Animator anim = null;
    private Vector3 oldPosition = Vector3.zero;
    private Vector3 newPosition = Vector3.zero;
    public Vector3 lastMove = Vector3.zero;
    public float isMoving = 0f;			//isMoving to float bo blendtree animacji przyjmuje tylko float
    private bool gamepadConnected = false;
    private float axisX = 0f;
    private float axisY = 0f;
    private float AttackX = 0f;
	private float AttackY = 0f;
    private float lastAxisX = 0f;
    private float lastAxisY = 0f;
    //private float oldPosX = 0f;
    //private float newPosX = 0f;
    private bool gamepad;

    private bool everyOtherFrame = true;
    public PlayerBehaviour playerBehaviour = null;
    private Vector3 normalizedAttackDirectionOnClick = Vector3.zero;

    void Start () {
        anim = GetComponent<Animator>();
        oldPosition = this.transform.position;
        //oldPosX = this.transform.position.x;
        playerBehaviour = gameObject.GetComponent<PlayerBehaviour>();
    }
	
	void FixedUpdate () {
        gamepad = GetComponent<PlayerBehaviour>().gamepadConnected;
        normalizedAttackDirectionOnClick = playerBehaviour.attackDirectionOnClick.normalized;
        //Debug.Log("Wektor ataku: " + AttackX + " "+   AttackY);
        newPosition = this.transform.position;

       // Debug.Log(this.transform.position.x);

/*
        if(playerBehaviour.attackDirection.x > 0f)
        	AttackX = 1f;
        else if(playerBehaviour.attackDirection.x < 0f)
        	AttackX = -1f;
        else
        	AttackX = 0f;

    	if(playerBehaviour.attackDirection.z > 0f)
        	AttackY = 1f;
        else if(playerBehaviour.attackDirection.z < 0f)
        	AttackY = -1f;
        else
        	AttackY = 0f;
*/

    AttackX = normalizedAttackDirectionOnClick.x * Mathf.Cos(-Mathf.PI/4) - normalizedAttackDirectionOnClick.z * Mathf.Sin(-Mathf.PI/4);
    AttackY = normalizedAttackDirectionOnClick.x * Mathf.Sin(-Mathf.PI/4) + normalizedAttackDirectionOnClick.z * Mathf.Cos(-Mathf.PI/4);

       // if(everyOtherFrame)
        
        //if(newPosition != oldPosition)

    //Debug.Log("newPosition: " + newPosition + " oldPosition: " + oldPosition);
        if ((Mathf.Abs(newPosition.x - oldPosition.x) > 0.01) || (Mathf.Abs(newPosition.z - oldPosition.z) > 0.01))
        {
            isMoving = 1f;
            oldPosition = newPosition;
        }
        else
        {
            isMoving = 0f;
        }
        

        // ten if usuwa odgrywanie jednej klatki biegu w lewo po tym, jak przestanie się wciskać klawisz (bez tego flaga isMoving jest jeszcze 
        //przez chwilę true, przez co zamiast animacji idle'a nadal jest odgrywana animacja biegu. A ponieważ nie wciskamy już klawisza, to wtedy 
        //odgrywana jest pierwsza animacja biegu w blend tree, czyli bodajże biegu w lewo :v )
        if ( ((Input.GetAxisRaw("Horizontal") == 0f) && (Input.GetAxisRaw("Vertical") == 0f)) && ((Input.GetAxisRaw("GamepadHorizontal") == 0f) && (Input.GetAxisRaw("GamepadVertical") == 0f)) )
                isMoving = 0f;
            
           // everyOtherFrame = !everyOtherFrame;

        if (!gamepad)
        {
            axisX = Input.GetAxisRaw("Horizontal");
            axisY = Input.GetAxisRaw("Vertical");

            if (playerBehaviour.isAttacking) {
                if (AttackX > 0f && AttackY >= 0f)               //up
                    lastMove = new Vector3(0f, 0f, 1f);

                else if (AttackX < 0f && AttackY <= 0f)          //down
                    lastMove = new Vector3(0f, 0f, -1f);

                else if (AttackX >= 0f && AttackY < 0f)          //right   
                    lastMove = new Vector3(1f, 0f, 0f);

                else if (AttackX <= 0f && AttackY > 0f)          //left
                    lastMove = new Vector3(-1f, 0f, 0f);
            }

            else{
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.3f)
                    lastMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.3f)
                    lastMove = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));
            }

            
            
        }

        else        //GAMEPAD PART -- naprawić
        {
            axisX = Input.GetAxisRaw("GamepadHorizontal");
            axisY = Input.GetAxisRaw("GamepadVertical");
            lastAxisX = Input.GetAxisRaw("GamepadHorizontal");
            lastAxisY = Input.GetAxisRaw("GamepadVertical");

            if (axisX > 0.03f)          axisX = 1f;
            if (axisX < -0.03f)         axisX = -1f;
            if (axisY > 0.03f)          axisY = 1f;
            if (axisY < -0.03f)         axisY = -1f;

            if (lastAxisX > 0.03f)      lastAxisX = 1f;
            if (lastAxisX < -0.03f)     lastAxisX = -1f;
            if (lastAxisY > 0.03f)      lastAxisY = 1f;
            if (lastAxisY < -0.03f)     lastAxisY = -1f;

            if (Mathf.Abs(Input.GetAxisRaw("GamepadHorizontal")) > 0.03f)
                lastMove = new Vector3(lastAxisX, 0f, 0f);
                //anim.SetFloat("LastMoveX", lastMove.x);

            if (Mathf.Abs(Input.GetAxisRaw("GamepadVertical")) > 0.03f)
                lastMove = new Vector3(0f, 0f, lastAxisY);
                //anim.SetFloat("LastMoveY", lastMove.y);

        }


        anim.SetFloat("MoveX", axisX);
        anim.SetFloat("MoveY", axisY);
        anim.SetFloat("isMoving", isMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.z);
        anim.SetFloat("AttackX", AttackX);
        anim.SetFloat("AttackY", AttackY);
        anim.SetBool("isAttacking", playerBehaviour.isAttacking);
        anim.SetInteger("numberOfAttack", playerBehaviour.numberOfAttack);


    }
}
