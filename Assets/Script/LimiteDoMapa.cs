using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteDoMapa : MonoBehaviour
{
    private Camera mainCamera;
    private Transform jogadorTransform;
    private SpriteRenderer jogadorSpriteRenderer;

    private void Awake()
    {
        mainCamera = Camera.main;
        jogadorTransform = transform;
        jogadorSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 jogadorPosicao = jogadorTransform.position;
        Vector3 limiteEsquerdoInferior = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 limiteDireitoSuperior = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        float jogadorLargura = jogadorSpriteRenderer.bounds.size.x;
        float jogadorAltura = jogadorSpriteRenderer.bounds.size.y;

        limiteEsquerdoInferior.x += jogadorLargura / 2f;
        limiteDireitoSuperior.x -= jogadorLargura / 2f;
        limiteEsquerdoInferior.y += jogadorAltura / 2f;
        limiteDireitoSuperior.y -= jogadorAltura / 2f;

        jogadorPosicao.x = Mathf.Clamp(jogadorPosicao.x, limiteEsquerdoInferior.x, limiteDireitoSuperior.x);
        jogadorPosicao.y = Mathf.Clamp(jogadorPosicao.y, limiteEsquerdoInferior.y, limiteDireitoSuperior.y);

        jogadorTransform.position = jogadorPosicao;
    }
}
