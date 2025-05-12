using UnityEngine;

public class Bilhete : MonoBehaviour
{
    private bool jaFoiLido = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (jaFoiLido) return;

        if (collision.CompareTag("Player"))
        {
            Dialog dialog = new Dialog();
            dialog.sentences = new string[] {
                "O que é isso? Parece uma matéria de jornal...",
                "Você lê a folha amarelada com atenção.",
                "\"Operário de fazenda perde o braço ao movimentar moinho.\"",
                "\"A fazenda não se responsabiliza pelo acidente.\"",
                "O papel está rasgado e o restante do texto é ilegível..."
            };

            DialogManager.instance.StartDialog(dialog);
            jaFoiLido = true;

            // Se quiser que ele desapareça depois:
            Destroy(gameObject, 0.5f);
        }
    }
}
