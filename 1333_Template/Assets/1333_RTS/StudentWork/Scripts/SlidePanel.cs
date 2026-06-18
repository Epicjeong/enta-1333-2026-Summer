using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlidePanel : MonoBehaviour
{
    [SerializeField] private float _openPos;
    [SerializeField] private float _closePos;
    private RectTransform _rectTransform;
    [SerializeField] private float _transitionDuration;

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
            GetComponentInChildren<Button>().GetComponent<RectTransform>().DOAnchorPosY(0f, 0.5f).SetEase(Ease.InQuad);
        });
    }

    public void Close()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        _rectTransform.DOAnchorPosX(_closePos, _transitionDuration).SetEase(Ease.InQuad).OnComplete(() =>
        {
            GetComponentInChildren<Button>().GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -160);

        });

    }
}
