using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOrSlowFruit : MonoBehaviour
{
    [SerializeField] float percent = 1.1f;

    [SerializeField] Sprite speed;
    [SerializeField] Sprite slow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMoveScript>().SetSpeed(percent);
            gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        setSprite();
    }

    private void setSprite()
    {
        if (percent > 1.0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = speed;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = slow;
        }
    }
}
