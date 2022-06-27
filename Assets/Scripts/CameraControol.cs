using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControol : MonoBehaviour
{
    public float dumping = 2f;
    public Vector2 offest = new Vector2(2f, 1f);
    public bool isleft;
    private Transform player;
    private int lastx;


    // Start is called before the first frame update
    void Start()
    {
        offest = new Vector2(Mathf.Abs(offest.x), offest.y);
        FindPlayer(isleft);
    }

    // Update is c11alled once per frame
    void Update()
    {
        if (player)
        {
            int currentx = Mathf.RoundToInt(player.position.x);
            if (currentx > lastx)
            {
                isleft = false;
            }
            else if (currentx < lastx)
            {
                isleft = true;
            }

            lastx = Mathf.RoundToInt(player.position.x);
            Vector3 target;
            if (isleft)
            {
                target = new Vector3(player.position.x - offest.x, player.position.y + offest.y, transform.position.z);

            }
            else
            {
                target = new Vector3(player.position.x + offest.x, player.position.y + offest.y, transform.position.z);

            }

            Vector3 currentpos = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentpos;

        }
    }

    public void FindPlayer(bool playerisleft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        lastx = Mathf.RoundToInt(player.position.x);

        if (playerisleft)
        {
            transform.position = new Vector3(player.position.x - offest.x, player.position.y - offest.y , transform.position.z);

        }
        else
        {
            transform.position = new Vector3(player.position.x + offest.x, player.position.y + offest.y, transform.position.z);

        }

    }
}
