using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class BackendProxy : MonoBehaviourEx
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
        return _userAuthenticated;
    }

    public bool AuthenticationDone()
    {
        return _authenticationDone;
    }

    public BackendProxy ShowLeaderboard()
    {
        return this;
    }

    public BackendProxy SetScore(int score)
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

    }

    public BackendProxy SetScore(int score)
    {
        Social.ReportScore(score, SpaceRoachesGID.leaderboard_best_roach_killer, (bool success) =>
       {
           if (success)
           {
               ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(SpaceRoachesGID.leaderboard_best_roach_killer);
           }
       });
        return this;
    }

    public BackendProxy ShowLeaderboard()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(SpaceRoachesGID.leaderboard_best_roach_killer);
        return this;
    }
#endif

}
