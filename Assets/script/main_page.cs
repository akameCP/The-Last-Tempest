using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main_page : MonoBehaviour
{
    
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

   
}