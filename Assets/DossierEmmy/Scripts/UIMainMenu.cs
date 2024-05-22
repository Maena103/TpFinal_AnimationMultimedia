using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    
    [SerializeField] Button _quiteGame;

    private LevelManager _levelManager;
    // Start is called before the first frame update
    void Start()
    {
        _levelManager = LevelManager.Instance;
      
        _quiteGame.onClick.AddListener(QuiteGame);
    }

  private void OnTriggerEnter(Collider other)
    {
        //_levelManager.LoadNewGame();
        _levelManager.LoadAsyncScene(LevelManager.Scene.Salle1);
    }

    private void QuiteGame()
    {
      _levelManager.QuiteGame();
    }
   
}
