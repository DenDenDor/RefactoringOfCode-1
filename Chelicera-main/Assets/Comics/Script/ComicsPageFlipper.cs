using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComicsPageFlipper : MonoBehaviour
{
    [SerializeField] private float _coldownLimit = 10f;
    [SerializeField] private Sprite[] _comicsImages;

    private int _currentImage = 0;
    private float _coldown;

    private void Start()
    {
        _coldown = _coldownLimit;
    }

    private void Update()
    {
        if (_coldown > 0.1)
        {
            _coldown -= Time.deltaTime;
            return;
        }

        GoToNextPage();
    }

    public void GoToNextPage()
    {
        _currentImage++;
        if (_currentImage >= _comicsImages.Length) {
            GoToNextScene();
            return;
        }

        SetImage();
    }
    public void GoToPreviousPage()
    {
        _currentImage--;
        if (_currentImage < 0)
            _currentImage = 0;
        SetImage();
    }
    private void SetImage()
    {
        _coldown = _coldownLimit;
        gameObject.GetComponent<Image>().sprite = _comicsImages[_currentImage];
    }

    private void GoToNextScene()
    {
        SceneManager.LoadScene(2);
    }
}
