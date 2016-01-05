using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class BackendProxy : MonoBehaviourEx
{
    private bool _userAuthenticated;
    private bool _authenticationDone;
    private bool _scorePosted;
    private bool _postingDone;
#if UNITY_STANDALONE
    public IEnumerator LogUser()
    {
        _userAuthenticated = true;
        _authenticationDone = true;
        yield return null;
    }

    public IEnumerator PublishScore(int score)
    {
        _scorePosted = true;
        _postingDone = true;
        yield return null;
    }

    public IEnumerator ShowLeaderboard()
    {
        yield break;
    }

    public bool UserAuthenticated()
    {
        return _userAuthenticated;
    }

    public bool AuthenticationDone()
    {
        return _authenticationDone;
    }

    public bool ScorePosted()
    {
        return _scorePosted;
    }

    public bool PostingDone()
    {
        return _postingDone;
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

    public IEnumerator PublishScore(int score)
    {
        Social.ReportScore(score, SpaceRoachesGID.leaderboard_best_roach_killer, (bool success) =>
       {
           if (success)
           {
              _scorePosted = true;
           }
           _postingDone = true;
       });
        while(!_postingDone){
            _postingDone = false;
            yield return null;
        }
    }
    
    public IEnumerator ShowLeaderboard()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(SpaceRoachesGID.leaderboard_best_roach_killer);
        yield break;
    }

    public bool UserAuthenticated()
    {
        return _userAuthenticated;
    }

    public bool AuthenticationDone()
    {
        return _authenticationDone;
    }

     public bool ScorePosted()
    {
        return _scorePosted;
    }

    public bool PostingDone()
    {
        return _postingDone;
    }

    public BackendProxy Initialize()
    {
        PlayGamesPlatform.Activate();
        return this;
    }


    public void Handle(NewScoreMessage message)
    {

    }
  
#endif

}
