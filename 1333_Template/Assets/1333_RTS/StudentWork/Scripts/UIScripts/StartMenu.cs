using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private float _openPos;
    [SerializeField] private float _closePos;
    private RectTransform _rectTransform;
    [SerializeField] private float _transitionDuration;

    [SerializeField] private SlidePanel _pauseMenu;
    [SerializeField] private SettingsMenu _settingsMenu;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _settingsButton;
    //private RectTransform _startTransform;
    //private RectTransform _settingsTransform;



    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _closePos = -_rectTransform.rect.height;
        _openPos = 0;
    }

    public void StartButton()
    {
        _rectTransform.DOAnchorPosY(_closePos, _transitionDuration).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            _pauseMenu.ShowPauseButton();
        });
    }

    public void ReturnToMenu()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        _rectTransform.DOAnchorPosY(_openPos, _transitionDuration).SetEase(Ease.InCirc).OnComplete(() =>
        {

        });

    }
}
