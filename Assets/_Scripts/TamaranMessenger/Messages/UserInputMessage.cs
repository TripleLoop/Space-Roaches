using UnityEngine;

public class UserInputMessage
{
    public Vector2 Location { get; set; }

    public UserInputMessage(Vector2 location)
    {
        this.Location = location;
    }
}
