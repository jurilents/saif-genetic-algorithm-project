using Saif.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Saif.Behaviours
{
    public class PlayButtonBehaviour : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Sprite playSprite;
        [SerializeField] private Sprite pauseSprite;

        public bool Play { get; private set; }

        private void Start()
        {
            button.onClick.AddListener(OnClick);
            SetButtonSprite();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Play = !Play;
            EventManager.SetPlatState(Play);
            SetButtonSprite();
        }

        private void SetButtonSprite()
        {
            button.image.sprite = Play ? playSprite : pauseSprite;
        }
    }
}