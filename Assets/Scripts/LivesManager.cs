using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    //Add the healthFX panel here so we can turn it off when we show info.
    public GameObject FXPanel;
    //Add the score panel here, instead of using it for rounds.
    public GameObject infoPanel;
    //Set up these variables so we can use them in our script.
    private int health;
    private MouseLook mouseLook;
    private PlayerHealth playerHealth;
    private Text panelText;

    // Start is called before the first frame update
    void Start()
    {
        //Disable the information panel.
        infoPanel.SetActive(false);
        //Get the text element in the panel.
        panelText = infoPanel.GetComponentInChildren<Text>();
        //Get the mouse look script on the main camera.
        mouseLook = Camera.main.GetComponent<MouseLook>();
        //Get the player health.
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        //Set timescale in case it's not 1.
        Time.timeScale = 1;
    }

   void LateUpdate()
    {
        health = playerHealth.health;
        //If the player health is 0 (or somehow less)
        if (health <= 0)
        {
            //Stop the game and freeze camera control.
            Time.timeScale = 0;
            mouseLook.enabled = false;
            //Print a failure message.
            panelText.text = string.Format("You failed to make it!");
            FXPanel.SetActive(false);
            infoPanel.SetActive(true);
            //Wait for the player to restart.
            if (Input.GetButton("Fire2"))
            {
                //Reload the scene.
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            //If the mouselook is disabled as the game ended.
            if (!mouseLook.isActiveAndEnabled)
            {
                //Enable the mouse look
                mouseLook.enabled = true;
                //and hide the information panel.
                infoPanel.SetActive(false);
            }
        }
    }
}
