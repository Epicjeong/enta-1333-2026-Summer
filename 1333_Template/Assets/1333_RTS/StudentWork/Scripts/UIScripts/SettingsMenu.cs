using DG.Tweening;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private float _openPos;
    [SerializeField] private float _closePos;
    private RectTransform _rectTransform;
    [SerializeField] private float _transitionDuration;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _openPos = -_rectTransform.rect.width;
        _closePos = 0;
    }

    public void OpenSettings()
    {
        _rectTransform.DOAnchorPosX(_openPos, _transitionDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            _rectTransform.DOShakeAnchorPos(.5f, 33, 33, 7);
        }); ;
    }

    public void CloseSettings()
    {
        _rectTransform.DOAnchorPosX(_closePos, _transitionDuration).SetEase(Ease.InQuad);
    }
}

