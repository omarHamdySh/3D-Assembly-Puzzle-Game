using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneMappingNode : MonoBehaviour
{
    public SceneMappingManager.SceneName sceneName;
    public void ChangeScene()
    {
        SceneMappingManager.Instance.changeScene(sceneName);
    }
    public void setSceneToChangeTo()
    {
        SceneMappingManager.Instance.sceneName = sceneName;
    }
}
