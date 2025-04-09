## Prefabs
- **Itens coletáveis**:
  - Esses itens podem ser feitos para poder ajustar mais facilmente os itens de acordo com a configuração necessária, por exemplo:
    - Configuração de tag ("item colecionável")
    - Configuração de contato (para poder realizar o contato para o player ter no inventário)

---

### Personagem Principal

- **Descrição:** Protagonista controlado pelo jogador
- **Quando é utilizada:** Durante a exploração da fazenda.
- **Componentes:**
  - **Sprites:** idle, walk, slash
      - Idle <br>
        ![Character_Idle](https://github.com/user-attachments/assets/d2beea12-59fe-483c-8348-beed7e19be69) <br>
      - Walk <br>
        ![Character_Walk](https://github.com/user-attachments/assets/80025853-65c5-49cd-95a0-2bf28b0b3633) <br>
      - Slash <br>
        ![Character_Slash](https://github.com/user-attachments/assets/be6d1f70-341e-4c83-82fc-55511e6a287d) <br>

  - **Colisor:** `BoxCollider2D`
  - **Fonte de Áudio:** ``
  - **Scripts:**
    - `PlayerController.cs`: Movimentação, interação, coleta.

---

### Background

- **Descrição:** Cenário do jogo, define toda a ambientação do momento.
- **Quando é utilizada:** Durante a exploração da fazenda, quando não está dentro dos puzzles.
- **Componentes:**
  - **Sprites:** tileset ground, tileset water, tileset road, tileset rock, buildings.
      - Groud <br>
        ![Tileset_Ground](https://github.com/user-attachments/assets/8535d754-b699-42d4-aea7-9387c093709c) <br>
      - Water <br>
        ![Tileset_Water](https://github.com/user-attachments/assets/56d2f1d6-3f71-4a31-a1fd-4eed165032a0) <br>
      - Road <br>
        ![Tileset_Road](https://github.com/user-attachments/assets/356d78a1-6c95-427e-b971-e462ef0c52b4) <br>
      - Rock <br>
        ![Tileset_RockSlope](https://github.com/user-attachments/assets/0bb0a0fd-5ec4-4941-96ce-3399a8d52760) <br>
      - Buildings <br>
        ![Buildings](https://github.com/user-attachments/assets/bedc55a1-acf5-4617-86b7-84b860e075a6) <br>
  - **Colisor:** `None`
  - **Fonte de Áudio:** `None`
  - **Scripts:**
    - `ParallaxController.cs`: Efeito de paralaxe para dar profundidade no cenário.

---
