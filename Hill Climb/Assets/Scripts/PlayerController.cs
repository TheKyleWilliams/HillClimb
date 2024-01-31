using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 12.0f;
    private float boostSpeed = 24.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;
    private int currentLevel;
    private bool boostUsed = false; // To check if boost is used in this level

    // Start is called before the first frame update
    void Start()
    {
        // load level
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }

        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    // Update is called once per frame
    void Update()
    {
        // get user input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Forward / backward movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Right / left movement
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        // Activate boost
        if (Input.GetKeyDown(KeyCode.E) && !boostUsed)
        {
            StartCoroutine(Boost());
        }

        // check if player died
        if (transform.position.y < -10) {
            ResetLevel();
            SceneManager.LoadScene("GameOver");
        }

        // check if player won
        if (transform.position.y > 37 && currentLevel == 10) {
            ResetLevel();
            SceneManager.LoadScene("YouWin");
        }

        // level up
        if (transform.position.y > 37)
        {
            LevelUp();
            SceneManager.LoadScene("MainGame");
        }
    }

    IEnumerator Boost()
    {
        boostUsed = true;
        float originalSpeed = speed;
        speed = boostSpeed; // Increase speed

        yield return new WaitForSeconds(3);

        speed = originalSpeed; // Revert to original speed
    }

    void ResetLevel()
    {
        currentLevel = 1;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        boostUsed = false; // Reset boost
    }

    void LevelUp()
    {
        currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        boostUsed = false; // Reset boost
    }
}