/*
 Enemy (Imer) movement behaviour

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 20/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //Defined constants for strings
    const string LEFT = "left";
    const string RIGHT = "right";
     
    [SerializeField]
    Transform castPos;

    [SerializeField]
    float baseCastDist;

    string facingDirection;

    Vector3 baseScale;

    Rigidbody2D enemyRigidBody;
    float speed = 2;
    
    void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vx = speed;

        if(facingDirection == LEFT)
        {
            vx = -speed;
        }
       
        enemyRigidBody.velocity = new Vector2(vx, enemyRigidBody.velocity.y);

        //Detects wall or end of platform and changes direction
        if (IsHittingWall() || IsNearEdge())
        {
            if(facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else
            {
                ChangeFacingDirection(LEFT);
            }
        }
    }

    //Function to change facing direction of Enemy
    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if(newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;

        facingDirection = newDirection;
    }

    //
    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDist;

        //define the cast distance for left and right
        if(facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }
        else
        {
            castDist = baseCastDist;
        }

        //determine the target destination based on the cast distance
        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        //Debug.DrawLine(castPos.position, targetPos, Color.yellow);

        if(Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    bool IsNearEdge()
    {
        bool val = true;

        float castDist = baseCastDist;

        //determine the target destination based on the cast distance
        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        //Debug.DrawLine(castPos.position, targetPos, Color.red);

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }
}
