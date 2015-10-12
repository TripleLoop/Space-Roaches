using UnityEngine;

public class UserTouchMessage  {

    public Vector2 UserInput { get; set; }

    public UserTouchMessage(Vector2 userInput)
    {
        UserInput = userInput;
    }
}
