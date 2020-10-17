using System.Collections;       
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InterfaceCore : SoundControler
{


    //Tudo relacionado a interface e seus componentes.
    [SerializeField] private InputField username;
    [SerializeField] private float playerPositionX;
    [SerializeField] private float playerPositionY;
    [SerializeField] private float playerPositionZ;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject levelClear;
    [SerializeField] private GameObject _nextStage;

    public Animator loadingScreen;
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        //username.text = PlayerPrefs.GetString("username");
        //DontDestroyOnLoad(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F5))
        {
            saveGame();
        }
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape))
        {
            menuPause();

        }

    }
    //Botão para salvar o Jogo;
    public void saveGame()
    {
        PlayerPrefs.SetFloat("PlayerPosition", playerPositionX);
        PlayerPrefs.SetString("User", username.text);
        PlayerPrefs.Save();

    }
    //Botões dentro do Jogo e suas respectivas funções;
    public void backMenu()
    {
        SceneManager.LoadScene("menuInicial");
    }
    public void menuPause()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);

    }
    public void backToGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        //1 para tela rodando 0 para não está ativa;
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void playGame()
    {
        SceneManager.LoadScene("FirstScene");
        //loadScreen();
    }
    public void restartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public void options()
    {
        SceneManager.LoadScene("Options");
    }
    public void loadScreen()
    {
        loadingScreen.SetTrigger("Vai");
        Invoke("CarregaDeVerdade", 2);
    }
    
    public void NextStage(){
        SceneManager.LoadScene("Fase2");
    }

    void CarregaDeVerdade()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        loadingScreen.SetTrigger("Vai");
        Invoke("DestroyMe", 2);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    //Metódos para realizar ações dentro dos botões;
    private void pauseFunction()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
}
