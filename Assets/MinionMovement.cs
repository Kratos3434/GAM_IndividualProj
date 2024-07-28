using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovement : MonoBehaviour
{
    //[SerializeField] private Transform player;
    private GameObject m_obj;
    [SerializeField] private Rigidbody2D rb;
    private bool playerInRanged = false;
    private Vector2 movement;
    private bool canMove = true;
    private bool minionInRange = false;
    private GameObject minionObj;
    private Vector2 minionMovement;

    private void Awake()
    {
        if (gameObject.tag != "ally minion")
        {
            m_obj = GameObject.FindWithTag("Player");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (minionObj != null)
        {
            Vector3 direction = minionObj.transform.position - transform.position;
            minionMovement = direction;
        }
        else if (m_obj != null)
        {
            Vector3 direction = m_obj.transform.position - transform.position;
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        if (minionObj != null)
        {
            MoveCharacter(minionMovement);
        } else
        {
            MoveCharacter(movement);
        }
        if (!minionInRange && playerInRanged)
        {
            Flip();
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        //rb.MovePosition((Vector2)transform.position + (direction * .5f * Time.deltaTime));
        if (m_obj == null && canMove)
        {
            rb.MovePosition((Vector2)transform.position + (new Vector2(1f, transform.position.y) * 2f * Time.deltaTime));
            Vector3 localScale = transform.localScale;
            localScale.x = 1f;
            transform.localScale = localScale;
        }
        else if (minionObj != null && canMove)
        {
            rb.MovePosition((Vector2)transform.position + (direction * 1f * Time.deltaTime));
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
            transform.localScale = localScale;
        }
        else if (playerInRanged && canMove)
        {
            //print("Can move");
            rb.MovePosition((Vector2)transform.position + (direction * 0.8f * Time.deltaTime));
        } else if (canMove)
        {
            rb.MovePosition((Vector2)transform.position + (new Vector2(-1f, transform.position.y) * 2f * Time.deltaTime));
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
            transform.localScale = localScale;
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        if (m_obj.transform.position.x > transform.position.x)
        {
            localScale.x = 1f;
        } else
        {
            localScale.x = -1f;
        }
        transform.localScale = localScale;
        
    }

    public void SetPlayerInRange(bool isInRanged)
    {
        playerInRanged = isInRanged;
    }


    public void SetCanMove(bool move)
    {
        canMove = move;
    }

    public void SetMinionInRange(bool inRange)
    {
        minionInRange = inRange;
    }

    public bool IsMinionInRange()
    {
        return minionInRange;
    }

    public void SetMinionRB(GameObject r)
    {
        minionObj = r;
    }
}
