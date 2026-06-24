using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SlidePanel : MonoBehaviour
{
    [SerializeField] private float _openPos;
    [SerializeField] private float _closePos;
    private RectTransform _rectTransform;
    [SerializeField] private float _transitionDuration;

    [SerializeField] private StartMenu _startMenu;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _unpauseButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _settingsButton;
    private RectTransform _pauseTransform;
    private RectTransform _unpauseTransform;
    private RectTransform _mainMenuTransform;
    private RectTransform _settingsTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _pauseTransform = _pauseButton.GetComponent<RectTransform>();
        _unpauseTransform = _unpauseButton.GetComponent<RectTransform>();
        _mainMenuTransform = _mainMenuButton.GetComponent<RectTransform>();
        _settingsTransform = _settingsButton.GetComponent<RectTransform>();
        _closePos = -_rectTransform.rect.width;
        _openPos = 0;
    }

    public void Open()
    {
        HidePauseButton();
        _rectTransform.DOAnchorPosX(_openPos, _transitionDuration).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            _unpauseTransform.DOAnchorPosX(0f, .5f).SetEase(Ease.InQuad).OnComplete(() =>
            {
                _settingsTransform.DOAnchorPosX(0f, .5f).SetEase(Ease.InQuad).OnComplete(() =>
                {
                    _mainMenuTransform.DOAnchorPosX(0f, .5f).SetEase(Ease.InQuad);
                });
            });
        });
    }

    public void Close()
    {
        //GetComponent<CanvasGroup>().blocksRaycasts = false;
        _rectTransform.DOAnchorPosX(_closePos, _transitionDuration).SetEase(Ease.InQuad).OnComplete(() =>
        {
            _unpauseTransform.anchoredPosition = new Vector3(-330, _unpauseTransform.position.y);
            _mainMenuTransform.anchoredPosition = new Vector3(-330, _mainMenuTransform.position.y);
            _settingsTransform.anchoredPosition = new Vector3(-330, _settingsTransform.position.y);
            ShowPauseButton();

        });

    }

    public void MainMenu()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        _rectTransform.DOAnchorPosX(_closePos, _transitionDuration).SetEase(Ease.InQuad);
        _startMenu.ReturnToMenu();
    }

    public void ShowPauseButton()
    {
        _pauseTransform.DOAnchorPosY(490f, .5f).SetEase(Ease.InQuad);
    }
    public void HidePauseButton()
    {
        _pauseTransform.DOAnchorPosY(570f, .5f).SetEase(Ease.InQuad);
    }
}
