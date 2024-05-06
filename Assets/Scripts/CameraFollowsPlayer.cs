using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPosition;
    private float offsetX = 0f;
    private float offsetY = 1.25f;
    private float smoothness = 4f;

    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offsetX, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offsetX, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, smoothness * Time.deltaTime);
    }
}
