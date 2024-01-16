using UnityEngine;
public class Pause : MonoBehaviour
{
    public bool _paused = false;
    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Test");
            if (_paused == false)
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
                _paused = true;
            }
            else
            {
                Time.timeScale = 1;
                canvas.SetActive(false);
                _paused = false;
            }
        }
    
    }
}
