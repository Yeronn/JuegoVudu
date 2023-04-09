using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject munecoPrefab, monstruoPrefab;
    public static string previousScene;
    private enum Scenes
    {
        Menu,
        Inventario,
        BattleScene1,
        BattleScene2,
        BattleScene3,
        Fight1,
        Fight2,
        Fight3
    }
    public void LoadScene(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

        if (sceneName.Equals(Scenes.Menu.ToString()))
        {
            Destroy(GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()));
        }

        if (sceneName.Equals(Scenes.Inventario.ToString()))
        {
            if (!GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()))
            {
                Instantiate(munecoPrefab);
            }
        }
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void FightScene()
    {
        if (previousScene.Equals(Scenes.BattleScene1.ToString()))
        {
            SceneManager.LoadScene(Scenes.Fight1.ToString());
        }
        else if (previousScene.Equals(Scenes.BattleScene2.ToString()))
        {
            SceneManager.LoadScene(Scenes.Fight2.ToString());
        }
        else if (previousScene.Equals(Scenes.BattleScene3.ToString()))
        {
            SceneManager.LoadScene(Scenes.Fight3.ToString());
        }
    }
}
