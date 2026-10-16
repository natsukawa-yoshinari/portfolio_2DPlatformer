using UnityEngine;
using UniRx;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private CameraManager _cameraManager;
    [SerializeField]
    private TextMeshProUGUI _cameraYText;

    private void Start()
    {
        _player.HighestY.Subscribe(x =>
        {
            _cameraManager.SetCameraY(x);
            _cameraYText.text = $"Height = {x.ToString("000.00")}m";
        }).AddTo(this);
    }
}
