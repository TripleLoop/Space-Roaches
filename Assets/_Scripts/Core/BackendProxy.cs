using System;
using UnityEngine;
using System.Collections;
using GooglePlayGames;
using LocalConfig = Config.BackendProxy;

public class BackendProxy : MonoBehaviourEx
{
#if UNITY_STANDALONE
    public void LogUser(Action<bool> callback)
    {
        callback(true);
    }

    public void PublishScore(int score, Action<bool> callback)
    {
        callback(true);
    }

    public void ShowLeaderboard()
    {
    }

    public BackendProxy Initialize()
    {
        return this;
    }
#endif

#if UNITY_ANDROID
    public void LogUser(Action<bool> callback)
    {
        Social.localUser.Authenticate(callback);
    }

    public void PublishScore(int score, Action<bool> callback)
    {
        Social.ReportScore(score, SpaceRoachesGID.leaderboard_best_roach_killer, callback);
    }

    public void ShowLeaderboard()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(SpaceRoachesGID.leaderboard_best_roach_killer);
    }

    public BackendProxy Initialize()
    {
        PlayGamesPlatform.Activate();
        return this;
    }

#endif

}
