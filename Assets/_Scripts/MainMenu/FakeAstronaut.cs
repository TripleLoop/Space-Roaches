using System;
using UnityEngine;
using System.Collections;

public class FakeAstronaut : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Action astronautCallback;

    public FakeAstronaut Initialize(Action callback)
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        astronautCallback = callback;
        return this;
    }

    public FakeAstronaut SetPosition(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, transform.position.z);
        return this;
    }

    public FakeAstronaut Push(float force, Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        return this;
    }

    void OnBecameInvisible()
    {
        //astronautCallback();
    }

}
