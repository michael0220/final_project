using UnityEngine;

public class UFOcontroller : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;

    public float fixedX;
    public float minY, maxY;

    public Transform attachPoint;
    private Hero_Base attachHero = null;
    void Start()
    {
        mainCamera = Camera.main;
        transform.position = new Vector3(fixedX, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleControl();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("attach hero");
        if (attachHero == null && collision.CompareTag("hero"))
        {
            Debug.Log("attach hero");
            Hero_Base hero = collision.GetComponent<Hero_Base>();
            if (hero != null)
            {
                AttachHeroControl(hero);
            }
        }
    }

    void AttachHeroControl(Hero_Base hero)
    {
        attachHero = hero;
        hero.AttachToUFO(attachPoint, this);
    }
    public void DetachUFO()
    {
        attachHero = null;
    }

    void HandleControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mouseWorldPos))
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            float clampedY = Mathf.Clamp(mouseWorldPos.y, minY, maxY);
            transform.position = new Vector3(fixedX, clampedY, 0);
        }
    }


}
