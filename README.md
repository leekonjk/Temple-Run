# 🏃 Temple Run Clone – Unity 3D Endless Runner

This is a **Temple Run–style 3D endless runner game** developed using the **Unity Engine**.
Built as a semester/final project by **Mustafa Riaz** from **COMSATS University Islamabad, Wah Campus**, the game focuses on chunk-based level generation, collectibles, and player movement logic.

---

## 🎮 Game Description

The player runs forward through an infinite track while avoiding obstacles, collecting coins 🍎 and apples 🍏, and trying to survive as long as possible.
Each section of the path is spawned in chunks using procedural generation, ensuring replayability.

---

## 🔥 Features

* ✅ Endless world generation using reusable chunk prefabs
* ✅ Player auto-runner mechanic with swipe or keyboard controls
* ✅ Coins, apples, and other pickups
* ✅ Obstacles that appear randomly
* ✅ Modular and scalable design
* ✅ Clean C# scripts with easy-to-edit values
* ✅ Ready for mobile, PC, or WebGL deployment

---

## 🛠️ Technologies Used

| Tool / Language    | Purpose                  |
| ------------------ | ------------------------ |
| Unity 2022+        | Game engine              |
| C#                 | Game logic & scripting   |
| Git + GitHub       | Version control          |
| Blender (optional) | 3D models and animations |

---

## 📁 Folder Structure

```
Temple-Run/
│
├── Assets/
│   ├── Scenes/               # Contains MainLevel.unity and other scenes
│   ├── Scripts/              # Player, LevelSpawner, ChunkManager, etc.
│   ├── Prefabs/              # Chunks, Coins, Obstacles
│   ├── Materials/            # Basic materials used in level
│   └── Textures/             # (optional) Textures for models
│
├── Packages/                # Unity package configs
├── ProjectSettings/         # Unity settings
├── .gitignore               # Ignores Library/, Temp/, etc.
└── README.md                # This file
```

---

## 🚀 How to Play

1. Clone the repository:

   ```bash
   git clone https://github.com/leekonjk/Temple-Run.git
   ```
2. Open the project in **Unity Hub**
3. Load the scene: `Assets/Scenes/MainLevel.unity`
4. Click **Play** in Unity Editor
5. Controls:

   * ← / → or A/D: Move left/right
   * Spacebar: Jump (if implemented)
   * Down Arrow: Slide (if implemented)

---

## 💪 To-Do (Upcoming Features)

* [ ] Add Score UI and distance tracking
* [ ] Implement power-ups (e.g., magnet, double coins)
* [ ] Create a main menu and game over screen
* [ ] Add sound effects and background music
* [ ] Save high scores using PlayerPrefs or Firebase
* [ ] Improve obstacle variety and placement logic

---

## 🏛️ Deployment

1. Go to `File > Build Settings`
2. Choose target platform (Windows, Android, WebGL, etc.)
3. Click **Build**, choose output folder

---

## 📷 Screenshots (Coming Soon)

> You can add gameplay screenshots or GIFs to showcase the game.

---

## 👋 Author

**Mustafa Riaz**
COMSATS University Islamabad, Wah Campus
BS Software Engineering (Final Year Student)
GitHub: [leekonjk](https://github.com/leekonjk)

---

## 📄 License

This project is for **educational and portfolio use only**.
Feel free to fork and use it, but give credit where due.

---

## 🔗 Helpful Resources

* Unity Documentation: [https://docs.unity3d.com/](https://docs.unity3d.com/)
* Unity Learn: [https://learn.unity.com/](https://learn.unity.com/)
* GitHub Student Pack: [https://education.github.com/pack](https://education.github.com/pack)

---

Happy Running! 🏃‍♂️🌿🎮
