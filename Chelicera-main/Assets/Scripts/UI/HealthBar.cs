using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private BasicHealthSystem _player;
    [SerializeField] private Sprite[] _heartImages;
    [SerializeField] private Sprite[] _emptyHeartImages;
    [SerializeField] private Sprite[] _halfOfHeartImages;
    [SerializeField] private GameObject _parentPanel;

    private GameObject[] _healthBar;
    private int currentHeart = 0;


    private void Awake()
    {
        _healthBar = new GameObject[_player.MaxHealth];
    }

    private void Update()
    {
        UpdateHealthAmount(_player.Health);
        currentHeart = 0;
    }

    private void UpdateHealthAmount(int health) {
        int numberOfFullHearts = health / 2;
        int numberOfHalfHearts = health % 2;
        int numberOfEmptyHearts = (_player.MaxHealth - health)/2;

        DeleteImages();

        DrawFullHearts(numberOfFullHearts);
        DrawHalfOfHeart(numberOfHalfHearts);
        DrawEmptyHearts(numberOfEmptyHearts);
    }

    private void DrawFullHearts(int numberOfHearts) {
        for (int heart = 0; heart < numberOfHearts; heart++)
        {
            DrawHeart(_heartImages[0]);
        }
    }
    private void DrawHalfOfHeart(int numberOfHearts) {
        for (int heart = 0; heart < numberOfHearts; heart++)
        {
            DrawHeart(_halfOfHeartImages[0]);
        }
    }
    private void DrawEmptyHearts(int numberOfHearts) {
        for (int heart = 0; heart < numberOfHearts; heart++)
        {
            DrawHeart(_emptyHeartImages[0]);
        }
    }

    private void DrawHeart(Sprite heartImage) {
        GameObject NewObj = new GameObject();
        Image NewImage = NewObj.AddComponent<Image>();
        NewImage.sprite = heartImage;
        NewImage.rectTransform.sizeDelta = new Vector2(50, 50);
        NewObj.GetComponent<RectTransform>().SetParent(_parentPanel.transform);
        NewObj.transform.position = _parentPanel.transform.position + new Vector3(50 * currentHeart, 0, 0);
        NewObj.SetActive(true);
        currentHeart++;
    }

    private void DeleteImages() {
        foreach (Transform child in _parentPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
