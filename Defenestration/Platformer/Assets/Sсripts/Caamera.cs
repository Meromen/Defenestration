using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caamera : MonoBehaviour
{

    public float dumpling = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    bool isleft;
    private int lastx;
    private Transform player;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isleft);

    }

    public void FindPlayer(bool playerIsleft )
    {
        player =GameObject.FindGameObjectWithTag("Player").transform;
        lastx = Mathf.RoundToInt(player.position.x);
        if (playerIsleft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    
    
    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastx) isleft = false;
            else isleft |= currentX < lastx;
            lastx = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isleft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
            }

        else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumpling * Time.deltaTime);
            transform.position = currentPosition;    

        }
    }
}
