using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision == null) return;
    //     Vector3 otherPos = collision.gameObject.transform.position;
    //     Vector3 myPos = this.gameObject.transform.position;

    //     if (otherPos.y > myPos.y)
    //     {
    //         _collider.isTrigger = false;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision == null) return;
    //     Vector3 otherPos = collision.gameObject.transform.position;
    //     Vector3 myPos = this.gameObject.transform.position;

    //     if (otherPos.y > myPos.y)
    //     {
    //         _collider.isTrigger = false;
    //     }
    // }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision == null) return;
    //     Vector3 otherPos = collision.gameObject.transform.position;
    //     Vector3 myPos = this.gameObject.transform.position;

    //     if (otherPos.y < myPos.y)
    //     {
    //         _collider.isTrigger = true;
    //     }
    // }
}
