using UnityEngine;

public class TextScript : MonoBehaviour
{

    public Transform player;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 target = player.position;
        target.y = transform.position.y;

        transform.LookAt(target);
    }
}
