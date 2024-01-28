using UnityEngine;
public class Pause : MonoBehaviour
{
    public bool _paused = false;
    public GameObject canvas;
    public GameObject over;

    void Start()
    {
        canvas.SetActive(false);
    }
    void Update()
    {
        if (over.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
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
}
