using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlidePanel : MonoBehaviour
{
    [SerializeField] private float _openPos;
    [SerializeField] private float _closePos;
    private RectTransform _rectTransform;
    [SerializeField] private float _transitionDuration;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _unpauseButton;
    private RectTransform _pauseTransform;
    private RectTransform _unpauseTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _pauseTransform = _pauseButton.GetComponent<RectTransform>();
        _unpauseTransform = _unpauseButton.GetComponent<RectTransform>();
        _closePos = -_rectTransform.rect.width;
        _openPos = 0;
    }

    public void Open()
    {
        _pauseTransform.DOAnchorPosY(80, .5f).SetEase(Ease.InQuad);
        _rectTransform.DOAnchorPosX(_openPos, _transitionDuration).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            _unpauseTransform.DOAnchorPosX(0f, .5f).SetEase(Ease.InQuad);
        });
    }

    public void Close()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        _rectTransform.DOAnchorPosX(_closePos, _transitionDuration).SetEase(Ease.InQuad).OnComplete(() =>
        {
            _unpauseTransform.anchoredPosition = new Vector3(-330, _unpauseTransform.position.y);
            _pauseTransform.DOAnchorPosY(0, .5f).SetEase(Ease.InQuad);

        });

    }


}
