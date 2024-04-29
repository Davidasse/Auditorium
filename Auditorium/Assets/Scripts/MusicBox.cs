using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{

    public AudioSource _audioSource;
    public Color _offColor;
    public Color _onColor;
    public SpriteRenderer[] _bars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // en fonction de la propriété audiosource.volume, le bon nombre de barre s'allume
        switch (_audioSource.volume)
        {
            case <0.2f:
                _bars[0].color = _offColor;
                _bars[1].color = _offColor;
                _bars[2].color = _offColor;
                _bars[3].color = _offColor;
                _bars[4].color = _offColor;
                break;
            case < 0.4f :
                _bars[0].color = _onColor;
                _bars[1].color = _offColor;
                _bars[2].color = _offColor;
                _bars[3].color = _offColor;
                _bars[4].color = _offColor;
                break;
            case < 0.6f:
                _bars[0].color = _onColor;
                _bars[1].color = _onColor;
                _bars[2].color = _offColor;
                _bars[3].color = _offColor;
                _bars[4].color = _offColor;
                break;
            case < 0.8f:
                _bars[0].color = _onColor;
                _bars[1].color = _onColor;
                _bars[2].color = _onColor;
                _bars[3].color = _offColor;
                _bars[4].color = _offColor;
                break;
            case < 1f:
                _bars[0].color = _onColor;
                _bars[1].color = _onColor;
                _bars[2].color = _onColor;
                _bars[3].color = _onColor;
                _bars[4].color = _offColor;
                break;
            case >= 1f:
                _bars[0].color = _onColor;
                _bars[1].color = _onColor;
                _bars[2].color = _onColor;
                _bars[3].color = _onColor;
                _bars[4].color = _onColor;
                break;
            default:
                break;
        }

    }
}
