using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -3f;
    public float maxX = 3f;

    private float direction = 1f; // 1 = phải, -1 = trái

    void Update()
    {
        // Di chuyển bóng
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        // Kiểm tra và đổi hướng khi chạm biên
        Vector3 pos = transform.position;

        if (pos.x >= maxX)
        {
            pos.x = maxX;
            direction = -1f;
        }
        else if (pos.x <= minX)
        {
            pos.x = minX;
            direction = 1f;
        }

        transform.position = pos;

        // Input đổi hướng từ người chơi
        HandleInput();
    }

    void HandleInput()
    {
        Vector2 inputPos;
        bool hasInput = false;

        // Chuột (Editor / PC)
        if (Input.GetMouseButtonDown(0))
        {
            inputPos = Input.mousePosition;
            hasInput = true;
        }
        // Touch (Android / iOS)
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            inputPos = Input.GetTouch(0).position;
            hasInput = true;
        }
        else
        {
            return;
        }

        // Chia đôi màn hình: bên trái / bên phải
        if (inputPos.x < Screen.width / 2f)
        {
            // Bấm nửa trái màn hình → đi sang trái
            direction = -1f;
        }
        else
        {
            // Bấm nửa phải màn hình → đi sang phải
            direction = 1f;
        }
    }
}