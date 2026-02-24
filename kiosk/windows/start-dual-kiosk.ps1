param(
  [int]$Port = 8000,
  [string]$BrowserPath = ""
)

Add-Type -AssemblyName System.Windows.Forms

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$kioskDir = Resolve-Path (Join-Path $scriptDir "..")

$pythonCmd = $null
if (Get-Command py -ErrorAction SilentlyContinue) {
  $pythonCmd = "py -3"
} elseif (Get-Command python -ErrorAction SilentlyContinue) {
  $pythonCmd = "python"
}

if (-not $pythonCmd) {
  Write-Error "找不到 Python（py 或 python）。請先安裝 Python。"
  exit 1
}

$serverCmd = "cd /d `"$kioskDir`" && $pythonCmd -m http.server $Port"
Start-Process -FilePath "cmd.exe" -ArgumentList "/c", "start", "`"kiosk-server`"", "cmd", "/k", $serverCmd | Out-Null
Start-Sleep -Milliseconds 900

if ([string]::IsNullOrWhiteSpace($BrowserPath)) {
  $browserCandidates = @(
    "C:\Program Files\Microsoft\Edge\Application\msedge.exe",
    "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
    "C:\Program Files\Google\Chrome\Application\chrome.exe",
    "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
  )
  foreach ($candidate in $browserCandidates) {
    if (Test-Path $candidate) {
      $BrowserPath = $candidate
      break
    }
  }
}

if (-not (Test-Path $BrowserPath)) {
  Write-Error "找不到瀏覽器。請用 -BrowserPath 指定 msedge.exe 或 chrome.exe"
  exit 1
}

$screens = [System.Windows.Forms.Screen]::AllScreens
$screenA = ($screens | Where-Object { $_.Primary })[0]
$screenB = if ($screens.Count -ge 2) { ($screens | Where-Object { -not $_.Primary })[0] } else { $screenA }

$indexUrl = "http://127.0.0.1:$Port/index.html"
$displayUrl = "http://127.0.0.1:$Port/display.html"

function Open-KioskWindow($screen, $url) {
  $x = $screen.Bounds.X
  $y = $screen.Bounds.Y
  $w = $screen.Bounds.Width
  $h = $screen.Bounds.Height

  $args = @(
    "--new-window",
    "--kiosk", $url,
    "--window-position=$x,$y",
    "--window-size=$w,$h"
  )

  Start-Process -FilePath $BrowserPath -ArgumentList $args | Out-Null
}

Open-KioskWindow -screen $screenA -url $indexUrl
Start-Sleep -Milliseconds 450
Open-KioskWindow -screen $screenB -url $displayUrl

Write-Host "已啟動："
Write-Host "- 控制端（螢幕 A）: $indexUrl"
Write-Host "- 展示端（螢幕 B）: $displayUrl"
if ($screens.Count -lt 2) {
  Write-Warning "目前只偵測到 1 個螢幕，兩個視窗會開在同一個螢幕。"
}
