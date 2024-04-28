using UnityEngine;

public class EndGame : MonoBehaviour
{
    private int tanksAlive;
    public int startTanks;

    public GameObject winPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        tanksAlive = startTanks;
    }

    private void OpenPanel()
    {
        Cursor.visible = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        
        //SFX
        Debug.Log("Win");
        AudioManager.Instance.PlaySFX("Win");
        AudioManager.Instance.StopMusic("Theme");
    }

    public void TankDied()
    {
        tanksAlive--;

        if (tanksAlive <= 0)
        {
            OpenPanel();
        }
    }
}