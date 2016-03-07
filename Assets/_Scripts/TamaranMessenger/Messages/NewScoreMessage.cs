public class NewScoreMessage
{
    public int Score { get; set; }
    public int SpaceCoins { get; set; }

    public NewScoreMessage(int score, int spaceCoins)
    {
        this.Score = score;
        this.SpaceCoins = spaceCoins;
    }
}
