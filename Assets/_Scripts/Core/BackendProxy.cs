using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class BackendProxy : MonoBehaviourEx, IHandle<NewScoreMessage>
{
    private bool _userAuthenticated;
    private bool _authenticationDone;
#if UNITY_STANDALONE
    public IEnumerator LogUser()
    {
        _userAuthenticated = true;
        _authenticationDone = true;
        yield return null;
    }

    public bool UserAuthenticated()
    {
        return _userAuthenticated && _authenticationDone;
    }

    public BackendProxy PostScore()
    {
        return this;
    }

    public BackendProxy Initialize()
    {
        return this;
    }
#endif

#if UNITY_ANDROID
    public IEnumerator LogUser()
    {
        Debug.LogError("hello");

        // authenticate user:
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                _userAuthenticated = true;
            }
            _authenticationDone = true;
            // handle success or failure
            Debug.Log(success ? "sucessful posting" : "failed posting");
        });

        while (!_authenticationDone)
        {
            yield return null;
        }
    }

    public bool UserAuthenticated()
    {
        return _userAuthenticated && _authenticationDone;
    }

   

    public BackendProxy Initialize()
    {
        PlayGamesPlatform.Activate();
        return this;
    }

    public void Handle(NewScoreMessage message)
    {
        Social.ReportScore(message.Score, SpaceRoachesGID.leaderboard_best_roach_killer, (bool success) =>
        {
            Debug.Log(success ? "sucessful posting" : "failed posting");
            if (success)
            {
                ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(SpaceRoachesGID.leaderboard_best_roach_killer);
            }
        });
    }
#endif

}
