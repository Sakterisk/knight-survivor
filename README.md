# ⚔️ Knight Survivor

A top-down 2D survivor-style game built in Unity where you play as a knight fighting off endless waves of enemies. Inspired by the *Vampire Survivors* genre — survive as long as possible, defeat enemies, and stay alive.

---

## 🎮 Gameplay

- Control a knight character from a top-down perspective
- Enemies spawn in waves and chase the player
- Player attacks automatically using equipped weapons
- Survive as long as possible against increasingly difficult enemy waves

---

## 🛠️ Tech Stack

| Tool | Purpose |
|---|---|
| **Unity** | Game engine (URP — Universal Render Pipeline) |
| **C#** | All gameplay scripting |
| **TextMesh Pro** | In-game UI text rendering |
| **Tilemaps** | Level/world design |
| **Unity Animator** | Player & enemy animations |

**Asset packs used:**
- *Top Down Adventure Assets* — environment sprites
- *Thaleah Pixel Font* — pixel art UI font

---

## 📁 Project Structure

```
Assets/
├── Player/         # Player controller, animations, sprites
├── Enemies/        # Enemy AI and prefabs
├── Weapons/        # Weapon logic and prefabs
├── Tilemap/        # Level tiles and maps
├── UI/             # HUD, health bar, score display
└── Scenes/         # Game scenes
```

---

## 💡 What I Learned

- Implementing **enemy AI** with chase behaviour using Unity's transform system
- Structuring a **component-based architecture** in Unity (MonoBehaviour patterns)
- Working with **Unity's Animator** state machines for directional movement animations
- Using **Tilemaps** to build and iterate on level design efficiently
- Managing **prefabs** for reusable enemy and weapon instances
- Setting up Unity's **Universal Render Pipeline (URP)** for a 2D project

---

## 🚀 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/Sakterisk/knight-survivor.git
   ```
2. Open the project in **Unity 2022.3 LTS** or newer
3. Open the scene from `Assets/Scenes/`
4. Press **Play** in the Unity Editor

> ⚠️ This project uses the Universal Render Pipeline. Make sure URP is installed via the Package Manager.

---

## 📸 Screenshots

<!-- Add screenshots or a GIF here once available -->
> *Screenshots coming soon*

---

## 📄 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.
