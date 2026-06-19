using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private float _openPos;
    [SerializeField] private float _closePos;
    private RectTransform _rectTransform;
    [SerializeField] private float _transitionDuration;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    //private RectTransform _startTransform;
    //private RectTransform _settingsTransform;



    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _closePos = -_rectTransform.rect.width;
        _openPos = 0;
    }

    public void Open()
    {
        _rectTransform.DOAnchorPosX(_openPos, _transitionDuration).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        });
    }

    public void Close()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        _rectTransform.DOAnchorPosX(_closePos, _transitionDuration).SetEase(Ease.InQuad).OnComplete(() =>
        {

        });

    }
}
