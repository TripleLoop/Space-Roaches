using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class BackendProxy : MonoBehaviourEx
{
    private bool _userAuthenticated;
    private bool _authenticationDone;

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
        });

        while(!_authenticationDone)
        {
            yield return null;
        }
    }

}
