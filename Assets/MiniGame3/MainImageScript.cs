using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject image_unknown;
    [SerializeField] private GameControllerScript gameController;
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;

    // ���� ī�忡 �Ҵ�� ��������Ʈ�� ���� ���̵�
    private int _spriteId;
    public int spriteId
    {
        get { return _spriteId; }
    }

    private void Start()
    {
        // ����� �ҽ� �ʱ�ȭ�ϱ�
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.clip = clickSound;
        audioSource.volume = 0.3f;
    }

    // ī�� Ŭ�� �� ȣ��
    public void OnMouseDown()
    {
        // ī�尡 Ȱ��ȭ, ������ ���� ����, �� ���� ī�尡 ���� �������� �ʾ��� ��
        if (gameObject.activeInHierarchy && image_unknown.activeSelf && gameController.canOpen)
        {
            // �޸� �̹��� ��Ȱ��ȭ, �÷��̾�� �ش� ī�尡 �������ٴ� ���� �˸�
            image_unknown.SetActive(false);
            gameController.imageOpened(this);

            // Ŭ�� ���� ����ϱ�
            if (clickSound != null && audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    // ī�� ��������Ʈ�� ����
    public void ChangeSprite(int id, Sprite image)
    {
        // ī�忡 ���� ���̵�� ��������Ʈ ����
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    // ī�� �޸� �̹����� Ȱ��ȭ�Ͽ� ������
    public void Close()
    {
        image_unknown.SetActive(true);
    }
}
