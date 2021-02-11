namespace Game.UI_UX
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class UI_MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Lobby");
        }
        public void Options()
        {

        }
        public void Exit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
