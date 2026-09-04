using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variáveis de Pontuação
    public static int ScoreBlue = 0;
    public static int ScoreRed = 0;

    [Header("UI & Design")]
    public GUISkin layout;

    [Header("Referências da Cena")]
    public Transform ball;
    private Rigidbody2D ballRb;

    // Resolução de Referência (1014 x 1555)
    private const float nativeWidth = 1014f;
    private const float nativeHeight = 1555f;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (ball == null)
        {
            GameObject ballObj = GameObject.FindGameObjectWithTag("ball");
            if (ballObj != null) ball = ballObj.transform;
        }

        if (ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody2D>();
        }

        ResetarBola();
    }

    // Chamado pelo script do Gol
    public void ScorePoint(bool isBluePoint)
    {
        if (isBluePoint)
        {
            ScoreBlue++;
        }
        else
        {
            ScoreRed++;
        }

        ResetarBola();
    }

    public void ResetarBola()
    {
        if (ball != null)
        {
            ball.position = Vector3.zero;

            if (ballRb != null)
            {
                ballRb.linearVelocity = Vector2.zero;
                ballRb.angularVelocity = 0f;
            }
        }
    }

    public void RestartGame()
    {
        ScoreBlue = 0;
        ScoreRed = 0;
        ResetarBola();
    }

    void OnGUI()
    {
        if (layout != null) GUI.skin = layout;

        // Escala a matriz da GUI proporcionalmente para a tela 1014x1555
        float rx = Screen.width / nativeWidth;
        float ry = Screen.height / nativeHeight;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(rx, ry, 1f));

        // --- PLACAR AZUL (Topo) ---
        GUIStyle blueStyle = layout != null && layout.FindStyle("score_blue") != null ? 
            layout.GetStyle("score_blue") : new GUIStyle(GUI.skin.label);
        
        if (blueStyle.fontSize == 0) blueStyle.fontSize = 80;
        blueStyle.normal.textColor = Color.red;
        blueStyle.alignment = TextAnchor.MiddleCenter;

        GUI.Label(new Rect(nativeWidth / 2 - 150, 60, 300, 120), ScoreBlue.ToString(), blueStyle);

        // --- PLACAR VERMELHO (Base) ---
        GUIStyle redStyle = layout != null && layout.FindStyle("score_red") != null ? 
            layout.GetStyle("score_red") : new GUIStyle(GUI.skin.label);

        if (redStyle.fontSize == 0) redStyle.fontSize = 80;
        redStyle.normal.textColor = Color.blue;
        redStyle.alignment = TextAnchor.MiddleCenter;

        GUI.Label(new Rect(nativeWidth / 2 - 150, nativeHeight - 180, 300, 120), ScoreRed.ToString(), redStyle);

        // --- BOTÃO DE RESTART (Meio / Borda Direita) ---
        GUI.skin.button.fontSize = 28;
        if (GUI.Button(new Rect(nativeWidth - 220, nativeHeight / 2 - 40, 180, 80), "RESTART"))
        {
            RestartGame();
        }
    }
}