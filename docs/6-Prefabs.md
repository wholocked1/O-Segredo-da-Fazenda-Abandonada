## Prefabs
### **Itens coletáveis**
- **Descrição:** 
  - Itens utilizados para interação do jogador.
  - **Quando é utilizada:** Durante a interação.
- **Sprites:** engranagem, chaves
    - Engrenagem <br>
        ![Engrenagem](https://github.com/user-attachments/assets/d8405afe-49af-4a8a-948f-da2b11cae856) <br>
    - Chaves <br>
        ![Chaves](https://github.com/user-attachments/assets/0fa03992-177f-4700-b29d-a919ea4ab9f1) <br>
- **Colisor**: ``
- **Fonte de Áudio:** `pickup.mp3`
- **Scripts:**
    - `ItensController.cs`: Coleta e contagem dos itens.
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
  - **Fonte de Áudio:** `stepsSound.mp3`
  - **Scripts:**
    - `PlayerController.cs`: Movimentação, interação, coleta.

---

## Casas:
- **Descrição:** Prédios para onde o player vai explorar, quando o player colidir em suas portas passará para outra cena ”dentro” da casa.
- **Quando é utilizada:** Durante a exploração da fazenda, quando não está dentro dos puzzles.
- **Componentes:**
  - **Sprites:** casas
    - Casas <br>
      ![Buildings](https://github.com/user-attachments/assets/bedc55a1-acf5-4617-86b7-84b860e075a6) <br>
  - **Colisor:** `BoxCollider.cs`
  - **Fonte de Áudio:** `None`
  - **Scripts:**
    - `ScenesManager.cs`: Controle de cenas.
---

### Background

- **Descrição:** Cenário do jogo, define toda a ambientação do momento.
- **Quando é utilizada:** Durante a exploração da fazenda, quando não está dentro dos puzzles.
- **Componentes:**
  - **Sprites:** tileset ground, tileset water, tileset road, tileset rock, trator, moinho.
      - Groud <br>
        ![Tileset_Ground](https://github.com/user-attachments/assets/8535d754-b699-42d4-aea7-9387c093709c) <br>
      - Water <br>
        ![Tileset_Water](https://github.com/user-attachments/assets/56d2f1d6-3f71-4a31-a1fd-4eed165032a0) <br>
      - Road <br>
        ![Tileset_Road](https://github.com/user-attachments/assets/356d78a1-6c95-427e-b971-e462ef0c52b4) <br>
      - Rock <br>
        ![Tileset_RockSlope](https://github.com/user-attachments/assets/0bb0a0fd-5ec4-4941-96ce-3399a8d52760) <br>
      - Trator <br>
        url <br>
      - Moinho <br>
        url <br>
  - **Colisor:** `None`
  - **Fonte de Áudio:** `None`
  - **Scripts:**
    - `ParallaxController.cs`: Efeito de paralaxe para dar profundidade no cenário.
