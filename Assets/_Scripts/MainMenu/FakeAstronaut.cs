using UnityEngine;
using System.Collections;

public class FakeAstronaut : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public FakeAstronaut Initialize()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        return this;
    }

    public FakeAstronaut SetPosition(Vector3 position)
    {
        transform.position = position;
        return this;
    }

    public FakeAstronaut Push(float force, Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        return this;
    }

}
