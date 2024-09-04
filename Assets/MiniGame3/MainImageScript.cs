using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameControllerScript gameController;
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;

    // 현재 카드에 할당된 스프라이트의 고유 아이디
    private int _spriteId;
    public int spriteId
    {
        get { return _spriteId; }
    }

    private void Start()
    {
        // 오디오 소스 초기화하기
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.clip = clickSound;
        audioSource.volume = 0.3f;
    }

    // 카드 클릭 시 호출
    public void OnMouseDown()
    {
        // 카드가 활성화, 뒤집지 않은 상태, 두 장의 카드가 아직 뒤집히지 않았을 때
        if (gameObject.activeInHierarchy && image_unknown.activeSelf && gameController.canOpen)
        {
            // 뒷면 이미지 비활성화, 플레이어에게 해당 카드가 뒤집혔다는 것을 알림
            image_unknown.SetActive(false);
            gameController.imageOpened(this);

            // 클릭 사운드 재생하기
            if (clickSound != null && audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    // 카드 스프라이트를 변경
    public void ChangeSprite(int id, Sprite image)
    {
        // 카드에 고유 아이디와 스프라이트 설정
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    // 카드 뒷면 이미지를 활성화하여 뒤집기
    public void Close()
    {
        image_unknown.SetActive(true);
    }
}
