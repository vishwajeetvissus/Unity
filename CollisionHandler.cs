using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Crash;

    AudioSource audioSource;

   void Start() 
        {
            audioSource = GetComponent<AudioSource>();
        }
    
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("This this is friendly");
                break;
            case "Finish":
             
             StartSucessSequece();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSucessSequece()
    {
        audioSource.PlayOneShot(Success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",levelLoadDelay);
    }

    void StartCrashSequence()
    {
        audioSource.PlayOneShot(Crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex== SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }   
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
