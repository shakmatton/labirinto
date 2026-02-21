using UnityEngine;
using TMPro;
public class Chegada : MonoBehaviour
{
    public TextMeshProUGUI TextoFinal;
    public GameObject Reset;
    
    void Start()                                    // faz a primeira configuração inicial dos objetos e componentes
    {
        TextoFinal.enabled = false;                 // no início, o componente TextoFinal tem que ficar escondido 
        Reset.SetActive(false);                     // no início, o objeto Reset inteiro não pode existir  
    }
    void OnTriggerEnter()                           // quando personagem atinge Chegada, esse evento dispara
    {
        TextoFinal.enabled = true;                  // personagem na Chegada significa: mostrar mensagem de fim/vitória na tela
        Reset.SetActive(true);                      // personagem na Chegada significa: mostrar objeto Reset na tela, pro personagem voltar ao início do labirinto
    }
    public void ResetUI()                           // controla a visibilidade do objeto Reset  
    {
        TextoFinal.enabled = false;                 // botão Reset clicado significa: remova mensagem de fim/vitória na tela
        Reset.SetActive(false);                     // botão Reset clicado significa: objeto Reset já foi clicado e cumpriu sua função, e já pode desaparecer da tela.
    }
}



/*  =======  Versão 2, mais enxuta  =======
 
 public class Chegada : MonoBehaviour
{
    public TextMeshProUGUI TextoFinal;
    public GameObject Reset;

    void Start()
    {
        OcultarUI();                                // OcultarUI(): método elimina redundância, aparecendo no Start() e no ResetUI()
    }

    public void ResetUI()
    {
        OcultarUI();                                // OcultarUI(): método elimina redundância, aparecendo no Start() e no ResetUI()
    }

    void OnTriggerEnter()
    {
        MostrarUI();                                // MostrarUI(): método elimina redundância, aparecendo no onTriggerEnter()
    }

    private void OcultarUI()                        // método chamado por Start() e ResetUI()
    {
        TextoFinal.enabled = false;
        Reset.SetActive(false);
    }

    private void MostrarUI()                        // método chamado por onTriggerEnter()
    {
        TextoFinal.enabled = true;
        Reset.SetActive(true);
    }
}

 */


/*  =======  Versão 3, ainda mais enxuta e com parâmetro bool =======

using UnityEngine;
using TMPro;

public class Chegada : MonoBehaviour
{
    public TextMeshProUGUI TextoFinal;
    public GameObject Reset;

    void Start()
    {
        ControlarUI(false);                         // Start() envia valor FALSO para o método único ControlarUI(bool mostrar).
    }

    public void ResetUI()
    {
        ControlarUI(false);                         // ResetUI() envia valor FALSO para o método único ControlarUI(bool mostrar).
    }

    void OnTriggerEnter()                           
    {
        ControlarUI(true);                          // onTriggerEnter() envia valor VERDADEIRO para o método único ControlarUI(bool mostrar).
    }

    private void ControlarUI(bool mostrar)          // ControlarUI(bool mostrar): método único que vai receber um valor booleano (verdadeiro ou falso) de Start(), ResetUI() ou onTriggerEnter(). 
    {
        TextoFinal.enabled = mostrar;               // A variável mostrar é como um "valor coringa": ela assume o valor que foi passado para o parâmetro do método ControlarUI(bool mostrar).
        Reset.SetActive(mostrar);                   // A variável mostrar é o que vai configurar o estado dos nossos objetos e componentes (no caso, Reset e TextoFinal).
    }
}
 

 */