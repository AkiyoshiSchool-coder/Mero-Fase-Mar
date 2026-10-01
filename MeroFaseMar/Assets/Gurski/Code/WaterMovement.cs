using UnityEngine;

/// <summary>
/// Anima os reflexos da agua com ondas sobrepostas. O movimento acontece apenas
/// neste objeto, portanto areia, pedras e colisores permanecem parados.
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]
public class WaterMovement : MonoBehaviour
{
    [Header("Deslocamento das ondas")]
    [SerializeField, Min(0f)] private float amplitude = 0.22f;
    [SerializeField, Min(0f)] private float velocidade = 0.35f;
    [SerializeField, Range(0f, 1f)] private float ondaSecundaria = 0.35f;
    [SerializeField] private float speed;

    [Header("Variacao visual")]
    [SerializeField, Range(0f, 0.1f)] private float pulsacaoDaEscala = 0.012f;
    [SerializeField, Range(0f, 0.5f)] private float pulsacaoDaTransparencia = 0.12f;

    private Transform transformacao;
    private SpriteRenderer renderizador;
    private Vector3 posicaoInicial;
    private Vector3 escalaInicial;
    private Color corInicial;

    private void Awake()
    {
        transformacao = transform;
        renderizador = GetComponent<SpriteRenderer>();
        GuardarEstadoInicial();
    }

    private void OnEnable()
    {
        // Tambem funciona corretamente quando o objeto e reativado durante o jogo.
        if (transformacao == null)
        {
            transformacao = transform;
            renderizador = GetComponent<SpriteRenderer>();
        }

        GuardarEstadoInicial();
    }

    private void Update()
    {
        float tempo = Time.time * velocidade;

        // Duas ondas com frequencias diferentes evitam um movimento circular mecanico.
        float deslocamentoX = (Mathf.Sin(tempo) + Mathf.Sin(tempo * 2.17f + 1.3f) * ondaSecundaria)*speed;
        float deslocamentoY = (Mathf.Cos(tempo * 0.73f) + Mathf.Sin(tempo * 1.61f + 2.1f) * ondaSecundaria)*speed;
        Vector3 deslocamento = new Vector3(deslocamentoX, deslocamentoY, 0f) * amplitude;
        transformacao.localPosition = posicaoInicial + deslocamento;

        float ondaVisual = Mathf.Sin(tempo * 0.83f + 0.5f);
        float fatorEscala = 1f + ondaVisual * pulsacaoDaEscala;
        transformacao.localScale = new Vector3(
            escalaInicial.x * fatorEscala,
            escalaInicial.y * (1f - ondaVisual * pulsacaoDaEscala * 0.6f),
            escalaInicial.z);

        Color cor = corInicial;
        cor.a = corInicial.a * (1f - pulsacaoDaTransparencia * 0.5f +
                               ondaVisual * pulsacaoDaTransparencia * 0.5f);
        renderizador.color = cor;
    }

    private void OnDisable()
    {
        // Nao deixa o objeto deslocado caso a animacao seja desligada no Inspector.
        if (transformacao != null)
        {
            transformacao.localPosition = posicaoInicial;
            transformacao.localScale = escalaInicial;
        }

        if (renderizador != null)
        {
            renderizador.color = corInicial;
        }
    }

    private void GuardarEstadoInicial()
    {
        posicaoInicial = transformacao.localPosition;
        escalaInicial = transformacao.localScale;
        corInicial = renderizador.color;
    }
}
