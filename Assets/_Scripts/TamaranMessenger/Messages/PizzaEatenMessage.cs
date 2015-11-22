using UnityEngine;

public class PizzaEatenMessage
{
    public GameObject Pizza { get; set; }

    public PizzaEatenMessage(GameObject pizza)
    {
        this.Pizza = pizza;
    }
}
