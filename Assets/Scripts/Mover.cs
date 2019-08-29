using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;

    public void Move(Vector3 newPos)
    {
        if(newPos.x != 0 && newPos.y != 0)
        {
            transform.position += newPos * (speed / 1.5f) * Time.deltaTime;
        }
        else
        {
            transform.position += newPos * speed * Time.deltaTime;
        }
    }
}