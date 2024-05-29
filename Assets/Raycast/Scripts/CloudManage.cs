using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManage : MonoBehaviour
{
    [SerializeField] private Renderer cloud;
    [SerializeField] private Transform startPos;

    private void Update()
    {
        int layerMask = LayerMask.GetMask("Cloud");

        RaycastHit2D hit = Physics2D.Raycast(startPos.position, Vector2.down, 1.25f, layerMask);

        if (hit.collider != null)
            if (hit.collider.gameObject == cloud.gameObject)
                cloud.material.color = new Color(0.8676071f, 0.8679245f, 0.741011f, 1f);
            else
                cloud.material.color = new Color(0.8676071f, 0.8679245f, 0.741011f, 0.3137255f);
        else
            cloud.material.color = new Color(0.8676071f, 0.8679245f, 0.741011f, 0.3137255f);
    }
}
