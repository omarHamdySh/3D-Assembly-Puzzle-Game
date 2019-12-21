using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    MainUI,
    VRTutorial,
    ShooterScene,
    AssemblyDissassemlbyScene,
    Testing
}
public class SceneMappingManager : MonoBehaviour
{
    private static SceneMappingManager _Instance;

    public static SceneMappingManager Instance                             //Getter Method.
    {
        get { return _Instance; }

    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    public SceneName sceneName;

    /// <summary>
    /// This Method is made to be used from inside the code not from the inspector since it doesn't take a primitive datatype
    /// as a paramter, instead it takes enum which will make the method unable to appear at any unity event in inspector.
    /// </summary>
    /// <param name="sceneName"></param>
    public void changeScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
    public void changeScene()
    {
        SceneManager.LoadScene(this.sceneName.ToString());
    }
}
