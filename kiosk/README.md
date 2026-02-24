# Windows 一體機展示頁（HTML 雙頁同步）

## 檔案
- `index.html`：右側控制端（選區 / 行政區 / 議員按鈕）
- `display.html`：左側展示端（首頁 / 選區名單 / 議員介紹）
- `assets/data.js`：13 選區 + 57 位議員資料
- `windows/start-dual-kiosk.bat`：一鍵啟動（控制端 + 展示端）
- `windows/start-dual-kiosk.ps1`：雙螢幕 kiosk 啟動邏輯

## 最小測試（Windows 一鍵）
1. 雙螢幕先接好，並在「顯示設定」中確認延伸桌面。
2. 雙擊：`windows/start-dual-kiosk.bat`
3. 腳本會自動：
   - 啟動本機伺服器 `http://127.0.0.1:8000`
   - 開 `index.html` 到螢幕 A（主螢幕）
   - 開 `display.html` 到螢幕 B（副螢幕）
   - 兩頁都以瀏覽器 kiosk 模式全螢幕

> 若只偵測到 1 個螢幕，兩頁會開在同一個螢幕（腳本會提示警告）。

## 手動模式（備用）
1. 在 `kiosk/` 啟動：
   ```bash
   python3 -m http.server 8000
   ```
2. 開兩個頁面：
   - `http://localhost:8000/index.html`
   - `http://localhost:8000/display.html`

## 素材命名規則
- 地圖：`assets/map_base.png`
- 照片：`assets/photos/{member.id}.jpg`（例：`assets/photos/m1_1.jpg`）
- 影片：`assets/videos/{member.id}.mp4`（例：`assets/videos/m1_1.mp4`）
- 預設照片：`assets/photos/default.jpg`
