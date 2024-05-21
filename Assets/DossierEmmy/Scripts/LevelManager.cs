using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static  LevelManager Instance; 

    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _barreProgression;
    
  
    private void Awake()
    {
        if(Instance == null){
            Instance  = this;
            DontDestroyOnLoad(gameObject); 
        }
        else{
            Destroy(gameObject);
        }
        
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.Accueil.ToString());
        
    }

    public void QuiteGame()
    {
        Application.Quit();
    }


    public async void LoadAsyncScene(Scene sceneName)
    {
        var sceneLoad = SceneManager.LoadSceneAsync(sceneName.ToString());
       // sceneLoad.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);
          
        do {
            await Task.Delay(800);
            if(_barreProgression != null){
                _barreProgression.fillAmount = sceneLoad.progress;  
            }
          
        } while (sceneLoad.progress < 0.9f);

        sceneLoad.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }

    public enum Scene{
        Accueil,
        Salle1,
        Salle2

    }
}
