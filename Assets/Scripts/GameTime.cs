using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameTime : ScriptableObject
{
    public float timeTreshold;
    [SerializeField] private float passedTime;

    [SerializeField] private Sprite[] gameTimeSprites;

    public void UpdateTime(GameTimeController _controller)
    {
        passedTime += Time.deltaTime;
        if (passedTime >= timeTreshold)
        {
            passedTime -= timeTreshold;

            Sprite nextSprite = GetNextGameTimeSprite(_controller.gameTimeImage.sprite);
            _controller.gameTimeImage.sprite = nextSprite;
        }
    }

    private Sprite GetNextGameTimeSprite(Sprite _currentSprite)
    {
        int current = 0;

        for (int i = 0; i < gameTimeSprites.Length; ++i)
        {
            if (gameTimeSprites[i] == _currentSprite)
            {
                current = i;
                break;
            }
        }

        int next = current + 1;
        if (next >= gameTimeSprites.Length) next = 0;

        return gameTimeSprites[next];
    }
}
